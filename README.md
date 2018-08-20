[![Build status](https://giorgiodev.visualstudio.com/football-api/_apis/build/status/football-api-Azure%20Web%20App%20for%20ASP.NET-CI)](https://giorgiodev.visualstudio.com/football-api/_build/latest?definitionId=1)

## Football API
A simple api to access football-data.org


#### Usage

##### Using Sandbox 

This has the latest commit from master branch

[Using Swagger UI](https://football-api-dev.azurewebsites.net/swagger)


##### Running locally

You need .NET Core 2.1+

[You need a valid League Code](http://www.football-data.org/docs/v1/index.html#league_codes) You can use the 2 method availables:




| Swagger | Import-League | Total-Players |
| ------- |:-----------|:-----------------:|
| /swagger | /import-leagues/CL | /import-leagues/total-players/CL |
| http://localhost:62020/swagger | http://localhost:62020/import-league/BL1 | http://localhost:62020/import-league/total-players/BL1 |
| https://football-api-dev.azurewebsites.net/swagger | https://football-api-dev.azurewebsites.net/import-league/BL1 | https://football-api-dev.azurewebsites.net/import-league/total-players/BL1 |

