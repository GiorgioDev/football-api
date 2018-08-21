## Football API
A simple api to access football-data.org

#### Stack
-.Net Core 2.1.
-EF Core. 
-DDD architecture.
-Units testing.
-Moq.
-Swagger using NSwag.
-Repository Pattern.
-MS SQL.
-CI/CD Using VSTS and Azure.
-Includes a init-script.sql to populate a blank Database.

#### Usage

##### Using Sandbox 

This has the latest commit from master branch

[Using Swagger UI](https://football-api-dev.azurewebsites.net/swagger)


##### Running locally

You need .NET Core 2.1+

[You need a valid League Code](http://www.football-data.org/docs/v1/index.html#league_codes) You can use the 2 method availables:




| Swagger | Import-League | Total-Players | Clean UP | 
| ------- |:-----------|:-----------------:|:-----------------:|
| /swagger | /import-leagues/CL | /import-leagues/total-players/CL |/import-leagues/clean-up
| http://localhost:62020/swagger | http://localhost:62020/import-league/BL1 | http://localhost:62020/import-league/total-players/BL1 |http://localhost:62020/import-league/clean-up | 
| https://football-api-dev.azurewebsites.net/swagger | https://football-api-dev.azurewebsites.net/import-league/BL1 | https://football-api-dev.azurewebsites.net/import-league/total-players/BL1 | https://football-api-dev.azurewebsites.net/import-league/clean-up | 

