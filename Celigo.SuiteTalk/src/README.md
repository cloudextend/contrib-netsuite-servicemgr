In order to generate the SuiteTalk stub, run the following command:

1. Install `dotnet-svcutil` globally

   ```bash
   dotnet tool install --global dotnet-svcutil --version 2.0.3
   ```

NuGet URL: https://www.nuget.org/packages/dotnet-svcutil


2. Run (e.g. for 2018.2 WSDL)

   ```bash
   mkdir -p 2018.2
   ```

   ```bash
   dotnet svcutil https://webservices.netsuite.com/wsdl/v2018_2_0/netsuite.wsdl -n "*,SuiteTalk"
   ```

3. This will generate a Reference.cs file in `2018.2/ServiceReference`. Move this file to
   `Celigo.SuiteTalk/src/Connected\ Services/SuiteTalk` folder overwriting the existing file.

4. Open `Celigo.SuiteTalk/src/Connected\ Services/SuiteTalk` file and do a Find & Replace and replace the following regex patterns with empty strings:

   **Pattern #1**
   ```
      \(Order=[0-9]+\)
   ```

   **Pattern #2**
   ```
      \,\sOrder=[0-9]+
   ```

5. Ensure that all `Order` attributes have been removed from XmlElementAttribute annotations by searching for the text    `Order=`. If there are any ordering left, remove them as well. This is done to address the following WCF issue: https://github.com/dotnet/wcf/issues/3073

6. Update the references to the SuiteTalk version:
	- Update the namesapce URLs in `Celigo.SuiteTalk/src/Connected\ Services/SuiteTalk/SuiteTalkSchemas.cs`.
	- Update `SuiteTalkVersion` in `Celigo.SuiteTalk/src/Connected\ Services/SuiteTalk/INetSuiteClient.cs`

8. Delete contents of the `Celigo.SuiteTalk/src/SuiteTalk/Generated` folder.

9. Unload the `UnitTests` project.

10. Perform the build.


The steps listed here are scripted in `update-wsdl.sh` script.