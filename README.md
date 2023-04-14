# National and State Parks API

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
Use base URL: `https://localhost:5001` with endpoints outlined below.
  * Project runs with launch url as ```https://localhost:5001/swagger/index.html```. You may use Swagger to explore endpoints, or optionally you may use Postman to view API [Download and install Postman](https://www.postman.com/downloads/)

#### HTTP Request Structure
```
GET /api/parks
POST /api/parks
GET /api/parks/{id}
PUT /api/parks/{id}
DELETE /api/parks/{id}
```

### Endpoints

### GET - Response returns all parks in database
Within your browser, enter the following in the URL, ```https://localhost:5000/api/parks```. 
Or, navigate to ```GET``` in Swagger. Click execute to view JSON response. In Postman, enter ```https://localhost:5000/api/parks``` in URL and click send.

#### Sample JSON Response 
```
[
{
"parkId": 1,
"name": "Cape Lookout State Park",
"location": "Tillamook County",
"state": "Oregon",
"type": "coast",
"terrain": "coastal, old-growth forest, high cliffs, rugged",
"features": "beach, hiking, lookouts, camping"
},
{
"parkId": 2,
"name": "Tyron Creek State Natural Area",
"location": "Portland",
"state": "Oregon",
"type": "city",
"terrain": "woodsy ravine, creek",
"features": "hiking, springtime wildflowers, wheelchair access loops"
},
...
```

### GET by Id - Response returns only the body containing value equal to "parkId" 
Enter the following in the URL, ```https://localhost:5000/api/parks/{id}```, and replace ```{id}``` with the "parkId" of the entry you wish to view. Within Swagger, navigate to GET by id, enter the "parkId" within the box labeled "id" and click execute.  In Postman, enter the url ```https://localhost:5000/api/parks/{id}``` replacing {id} with "parkId" and click send.

#### Sample endpoint by Id - ```https://localhost:5000/api/parks/3```

#### Sample JSON Response for parkId = 3
```
{
"parkId": 3,
"name": "Mt St Helens National Volcanic Monument",
"location": "Gifford Pinchot National Forest",
"state": "Washington",
"type": "mountain",
"terrain": "volcanic, old-growth forest, lakes, waterfalls in canyon",
"features": "hiking, wheelchair access loops, viewpoints"
}
```

### POST - Add an entry to ParksApi database
Within Swagger or Postman, navigate to ```POST```. In the request body, fill-in the following values for each key and click execute. If using Postman, enter URL ```https://localhost:5000/api/parks```, set request body to be "raw JSON". Click send.
```
{
  "name": "string",
  "location": "string",
  "state": "string",
  "type": "string",
  "terrain": "string",
  "features": "string"
}
```

### PUT - Update an entry in ParksApi database
Within Swagger or Postman, navigate to ```PUT```. In the request body, update whichever values need to be changed. It's important to include the whole body when using PUT. All keys must be within request body. If using Swagger, enter "parksId" in box labeled "id". If using Postman, enter URL ```https://localhost:5000/api/parks/{id}```, replace {id} with the "parksId" of the body to be updated. Set request body to be raw text. 

When finished click execute or send.

#### Example PUT JSON Response for parksId = 3
Change "features" to include "visitor center"
```
{
"parkId": 3,
"name": "Mt St Helens National Volcanic Monument",
"location": "Gifford Pinchot National Forest",
"state": "Washington",
"type": "mountain",
"terrain": "volcanic, old-growth forest, lakes, waterfalls in canyon",
"features": "hiking, wheelchair access loops, viewpoints, visitor center"
}
```

### DELETE - Delete an entry in ParksApi database
Within Swagger or Postman, navigate to ```DELETE```. If using Swagger, enter "parksId" in box labeled "id" that you wish to delete from database. If using Postman, enter URL ```https://localhost:5000/api/parks/{id}```, replace {id} with the "parksId" of the body to be deleted. 

When finished click execute or send.


## API Documentation with Authentication

To use Authorization, first uncomment ```//[Authorize]``` in ParksController.cs file. Code should look like the following,
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
### Launch project
Run project by typing ```dotnet watch run``` in command line.

### Get token in Swagger
Project will launch in swagger (https://localhost:5001/swagger/index.html) 
  1. On Swagger index page, scroll down and click on 'token' ```POST```. Then click on ```Try it out```.
  2. Scroll down, in ```Request body``` box, add the following 'email' and 'password' into the empty box,
  ```
  {
  "email": "test@test.com",
  "password": "Test1234"
  }
  ``` 
  3. Click ```Execute```.
  4. Scroll down again (within Token), and copy token that was created and is displayed in ```Response body```.
  5. Scroll to top of page and click ```Authorize```.
  6. In pop-up box, paste token into ```Value``` box. Then click ```Authorize```. Then click ```Close```.
  7. Now you are authorized to use GET, POST, PUT, DELETE within Swagger to view API. To logout, click ```Authorize``` and ```Logout```.
  

### Known Bugs

* No known bugs. 
* If any issues are discovered, please email jenniferlholcomb@gmail.com


### License

MIT License

Copyright (c) 2023 Jennifer Holcomb

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
