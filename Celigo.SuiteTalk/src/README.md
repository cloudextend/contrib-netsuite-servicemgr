In order to generate the SuiteTalk stub, run the following command:

1. Install `dotnet-svcutil` globally
   `dotnet tool install --global dotnet-svcutil`

2. Run (e.g. for 2018.2 WSDL)

   ```
   dotnet svcutil https://webservices.netsuite.com/wsdl/v2018_2_0/netsuite.wsdl -n "*,SuiteTalk"
   ```

3. This will generate a `Reference.cs file in `<SolutionDir>\2018.2\ServiceReference`. Move this file to 
   `<SolutionDir>\Celigo.SuiteTalk\src\Connected Services\SuiteTalk` folder overwriting the existing file. Build the project.