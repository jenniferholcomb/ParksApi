# National and State Parks Api

#### By: Jennifer Holcomb

#### API contains information about State and National Parks, with authentication using token and authorization in Swagger.

### Technologies Used

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

### Description

This API holds details about state and national parks, including park name, location, US state the park is located in, type of park, terrain, and other features relevant to park. There is CRUD functionality with API (GET, POST, PUT, DELETE). Application launches in Swagger, with capability to turn on Authorization (uncomment in ParksController) thus requiring a user to login in Swagger, get a token, then Authorize with token to view API. See below for more information on Authorization.

## Setup/Installation Requirements

* Clone this repo to your workspace.
* Navigate to project directory  (ParksApi)
  * add .gitignore file to this directory
    * in .gitignore, add the following to file, 
    ```
    obj
    bin
    appsettings.json
    ```
    * push this file to GitHub first
* Create file appsettings.json in project directory
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
    * In this appsettings.json file, replace '[YOUR-USERNAME-HERE]' with your SQL username, and '[YOUR-PASSWORD-HERE]' with your SQL password
* In project directory, on command line run ```dotnet restore``` to install all packages for project listed within launchSettings.json.
* To load application database with migrations.
    * In project directory, run ```dotnet ef database update```.
* In project directory, run ```dotnet watch run ``` to  
  start project in development mode in watcher.
* Browser should launch automatically. If not, open browser and type in URL https://localhost:5001/swagger/index.html

## API Documentation
Explore API endpoints through Swagger, or use base URL: `https://localhost:5001` with endpoints outlined below.
  * Optionally, you may use Postman to view API [Download and install Postman](https://www.postman.com/downloads/)

#### Example Query
```
https://localhost:5000/api/parks
```
### Endpoints
Base URL: `https://localhost:5000`

### Parks
Access information about state and national parks.

#### HTTP Request Structure
```
GET /api/parks
POST /api/parks
GET /api/parks/{id}
PUT /api/parks/{id}
DELETE /api/parks/{id}
```

#### Example Query
```
https://localhost:5000/api/parks/1
```

#### Sample JSON Response
```
  {
    "parkId": 1,
    "name": "Cape Lookout State Park",
    "location": "Tillamook County",
    "state": "Oregon",
    "type": "coast",
    "terrain": "coastal, old-growth forest, high cliffs, rugged",
    "features": "beach, hiking, lookouts, camping"
  }
```
## API Documentation with Authentication

To use Authorization, first uncomment ```//[Authorize]``` in ParksController.cs file. Code should like the following,
```
    ...
namespace ParksApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class ParksController : ControllerBase
  {
    ... 
```
#### Launch project
Same as above, run project with by typing ```dotnet watch run``` in command line.

#### Get token in Swagger
Project will launch in swagger. 
  1. Click on ```token``` ```POST```. Then click on ```Try it out```.
  2. Scroll down and in ```Request body``` copy the following,
  ```
  {
  "email": "test@test.com",
  "password": "Test1234"
  }
  ```
  Then click ```Execute```.
  3. Scroll down more (within Token), and copy token that was created and is displayed in ```Response body```.
  4. Scroll to top of page and click ```Authorize```.
  5. In pop-up box, paste token into ```Value``` box. Then click ```Authorize```. Then click ```Close```.
  6. Now you have been authorized to use GET, POST, PUT, DELETE within Swagger to view API. To logout, click ```Authorize``` and ```Logout```.
  

### Known Bugs

* No known bugs. 
* If any issues are discovered, please email jenniferlholcomb@gmail.com


### License

MIT License

Copyright (c) 2023 Jennifer Holcomb

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.