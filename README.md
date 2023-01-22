# National and State Parks Api

#### By Jennifer Holcomb

#### API contains information about State and National Parks, with authentication using token and authorization in Swagger.

## Technologies Used

* C#
* .NET 6
* ASP.NET Core 6 MVC
* EF Core 6
* SQL
* mySQL
* LINQ
* Dotnet-ef
* Identity
* JWT authentication
* Swagger

## Description

This API holds details about state and national parks, including park name, location, US state the park is located in, type of park, terrain, and other features relevant to park. There is CRUD functionality with API (GET, POST, PUT, DELETE). Application launches in Swagger, with capability to turn on Authorization (uncomment in ParksController) thus requiring a user to login in Swagger, get a token, then Authorize with token to view API. See below for more information on Authorization.

## Setup/Installation Requirements

* Clone this repo to your workspace.
* Navigate to project directory  (ParksApi)
  * add .gitignore file to this directory
    * add bin, obj, appsettings.json to file
    * push this file to GitHub first
* Navigate to production directory (Factory)
  * Create a file appsettings.json
    * Add the following to appsettings.json,
    ```
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=factory;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
      },
      "Jwt": {
        "Key": "Mynameispiperholcomb",
        "Issuer": "JWTAuthenticationServer",
        "Audience": "JWTServicePostmanClient",
        "Subject": "JWTServiceAccessToken"
      }      
    }
    ```
    * In appsettings.json, replace '[YOUR-USERNAME-HERE]' with your SQL username, and '[YOUR-PASSWORD-HERE]' with your SQL password
* In project directory, on command line run ```$ dotnet restore```
* To load application database with migrations.
    * In project directory, run ```$ dotnet ef database updated```
* In project directory, run ```$ dotnet watch run ``` in command line to  
  start project in development mode in watcher.
* Browser should launch automatically. If not, open broswer and type in URL https://localhost:5001/swagger/index.html


## Known Bugs

* No known bugs. 
* If any issues are discovered, please email jenniferlholcomb@gmail.com


## License

MIT License

Copyright (c) 2023 Jennifer Holcomb

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
