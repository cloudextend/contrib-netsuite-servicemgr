In order to generate the SuiteTalk stub, run the following command:

1. Install `dotnet-svcutil` globally
   `dotnet tool install --global dotnet-svcutil`

2. Run (e.g. for 2018.2 WSDL)

   ```
   dotnet svcutil https://webservices.netsuite.com/wsdl/v2018_2_0/netsuite.wsdl -n "*,SuiteTalk"
   ```

   This will generate a `Reference.cs file in `<SolutionDir>\2018.2\ServiceReference`. 
   
3. Open `Reference.cs` file and do a Find & Replace and replace the following regex patterns with empty strings:
    `\(Order=[0-9]+\)`
    `\,\sOrder=[0-9]+`

4. Ensure that all `Order` attributes have been removed from XmlElementAttribute annotations by searching for the text `Order=`.
   If there are any ordering left, remove them as well.

5. Update the references to the SuiteTalk version:
	6.1 Update the namesapce URLs in `SuiteTalkSchemas.cs`. 
	6.2 Update `SuiteTalkVersion` in `INetSuiteClient.cs`

6. Delete contents of the `<SolutionDir>\Celigo.SuiteTalk\src\SuiteTalk\Generated` folder.

7. Unload the `UnitTests` project. 

8. Perform the build.