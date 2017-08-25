# API-Mock

This is an early version API for a fictional online store. It resolves queries for products found by their idenification number as well as the category the product belongs to. It also returns products based on their category affiliation, found using the category name.  

## Getting Started

-Clone this repository and save in local directory.
-Use DatabaseSeed.sql and TestDatabaseSeed.sql to create tables and data in your choice of SQL server.
-Change the server name in the connection string Server='DESKTOP-GC3DC7B\\SQLEXPRESS' to your local server name. The connection strings can be found in appsettings.json, src/API-4TELL/Models/ApplicationContext.cs, and API-4TELL.Tests/ModelTests/TestDbContext

### Prerequisites

Visual Studio 2015 or above. 
SQL Server, MSSQL used for development.
Web Browser, Chrome prefered

### Running

In your home terminal, navigate to directory where you wish to store this project. Clone the repository. Navigate into .\src\API-4TELL\.
run 'dotnet run'. Browser window should open at localhost:5000, manually navigate to localhost:5000/api.


## Running the tests

Tests are currently not passing. However, to run tests, navigate to  .\API-4TELL.Tests\ and run 'dotnet test'.


## Built With
* ASP.NET Core (https://docs.microsoft.com/en-us/aspnet/core/)
* MSSQL (https://www.microsoft.com/en-us/sql-server/sql-server-2016)

## Versioning
Version 1.0.0

## Authors

* **Daniel Munger** -(https://github.com/DanielMunger)


## License

This project is licensed under the MIT License - 

Copyright <2017> <Daniel Munger>

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

## Acknowledgments

*Thanks to 4-TELL for allowing me the opportunity to showcase my web development skills with this project!
