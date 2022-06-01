# NetSuite Three Step Authentication Demo with Celigo ServiceManager
## (.NET 6.0)

> This MVC application is to demonstrate the Three step authentication process of NetSuite along with Celigo Service Manager

### Configuration in NetSuite
1) Create an Integration in NetSuite: 
    1) After login to NetSuite, from top menu choose SetUp -> Integration -> Manage Integration -> New.
    2) Follow the steps to create integration
       1) Provide Name & description.
       2) Tick all 3 options (TOKEN-BASED AUTHENTICATION, TBA: ISSUETOKEN ENDPOINT, TBA: AUTHORIZATION FLOW) in Token bases authentication.
       3) Provide `Callback Url`. Example: `https://localhost:5001/Home/Authorize`.
       4) Click on `Save` button. Once details saved NetSuite will provide `ConsumerKey` and `ConsumerSecret`.  
2) AppSettings configuration in MVC application:
   1)  In `appsettings.json` file, in `ThreeStepAuthMVC` application. Replace `Variable`  with `Value` as provided in below table.

Variable | Value
---|---
NetSuite_ConsumerKey | CONSUMER KEY / CLIENT ID
NetSuite_ConsumerSecret | CONSUMER SECRET / CLIENT SECRET


3) Build and Run the application.

