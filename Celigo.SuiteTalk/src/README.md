# Regenerating the SuiteTalk stub

Use the script. It performs every step below and refuses to install a bad
generation:

```
scripts/regen-suitetalk.sh 2025_2
```

Then update the version constants by hand (the script does not touch them):

- namespace URNs in `SuiteTalkSchemas.cs`
- `SuiteTalkVersion` in `INetSuiteClient.cs`
- `<Version>` in `Celigo.SuiteTalk.csproj` and `Celigo.ServiceManager.NetSuite.csproj`

Finally rerun [app-generator-netsuite-servicemgr](https://github.com/cloudextend/app-generator-netsuite-servicemgr)
to repopulate `Celigo.SuiteTalk/src/SuiteTalk/Generated`, and run the tests in
`Celigo.ServiceManager.NetSuite/test/UnitTest`.

## Why the script exists

`dotnet svcutil <wsdl> -n "*,SuiteTalk"` flattens every NetSuite XML namespace
into one C# namespace. Three NetSuite types collide on name under that
flattening, and svcutil breaks each tie by suffixing `1` onto whichever of the
pair it emits second.

**That choice is not stable.** Repeated runs of the same WSDL with the same
svcutil produce different assignments. A wrong assignment still compiles, and
the SOAP wire format stays correct, so nothing here fails. It breaks
downstream instead: `feature-metadata` stores the type name as the literal
string `"SiteCategory1"` in committed JSON, so a bad draw silently binds item
uploads to the website-category record rather than the item line.

The canonical mapping, which every current consumer is built against:

| C# type | NetSuite schema |
| --- | --- |
| `SiteCategory` | `urn:website_*` |
| `SiteCategory1` | `urn:accounting_*` |
| `CustomerSalesTeam` | `urn:common_*` |
| `CustomerSalesTeam1` | `urn:relationships_*` |
| `CurrencyRate` | `urn:accounting_*` |
| `CurrencyRate1` | `urn:core_*` |

The script regenerates until it draws this mapping. `SuiteTalkTypeBindingTests`
asserts it, so a hand-run svcutil that lands the other way fails the build.

## Manual steps, if you cannot run the script

1. Install `dotnet-svcutil` globally: `dotnet tool install --global dotnet-svcutil`
2. Run (on .NET 8, set `DOTNET_ROLL_FORWARD=Major`):

   ```
   dotnet svcutil https://webservices.netsuite.com/wsdl/v2025_2_0/netsuite.wsdl -n "*,SuiteTalk"
   ```

3. Move the generated `ServiceReference/Reference.cs` over
   `Celigo.SuiteTalk/src/Connected Services/SuiteTalk/Reference.cs`.
4. Delete every `Order=` on `XmlElementAttribute` — replace the regexes
   `\(Order=[0-9]+\)` and `,\sOrder=[0-9]+` with empty strings, then confirm a
   search for `Order=` returns nothing.

   Positional ordering is why this matters: NetSuite frequently returns elements
   out of schema order, and the serializer then leaves inherited fields empty
   with no error raised. See [dotnet/wcf#3073](https://github.com/dotnet/wcf/issues/3073).
5. Comment out every `System.ComponentModel.DefaultValueAttribute`. Left in,
   explicit `false` and zero values are dropped from outgoing requests.
6. Check the collision mapping in the table above and regenerate if it differs.
7. Add any types NetSuite omits from the WSDL to `SuiteTalk/MissingReferences`
   (currently `TransactionStatus`).
8. Delete the contents of `Celigo.SuiteTalk/src/SuiteTalk/Generated` and rerun
   the app-generator.
