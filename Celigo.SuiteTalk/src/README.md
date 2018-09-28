In order to generate the SuiteTalk stub, run the following command:

1. Add `dotnet-svcutil` to the SuiteTalk project (as specified in https://docs.microsoft.com/en-us/dotnet/core/additional-tools/dotnet-svcutil-guide)

   ```xml
   <ItemGroup>
     <DotNetCliToolReference Include="dotnet-svcutil" Version="1.0.*" />
   </ItemGroup>
   ```

2. Run `dotnet-restore` from Package Manager Console

3. Run (e.g. for 2018.2 WSDL)

   ```
   dotnet svcutil https://webservices.netsuite.com/wsdl/v2018_2_0/netsuite.wsdl -n "*,SuiteTalk"
   ```

4. This will generate a folder inside the project with a name like "ServiceReference1". Rename this to `Conencted Services`. You may want to move the`Reference.cs` file in to a subfolder named `SuiteTalk` as well.

