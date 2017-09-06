# .net-core-Database-First
Using database first approach with magicDraw and .net core 2.0
--Testing Project how works DDL sql code with .net core--
### functionality
```
Using scaffolding system generated cruds : 
CRUD studentas in http://localhost:50663/studentas
CRUD destytojas in http://localhost:50663/destytojas
```
### Installing

1.Open cmd and copy this : 
```
git clone https://github.com/martasp/.net-core-Database-First
cd .net-core-Database-First
dotnet restore
dotnet ef database update
dotnet publish
dotnet run 

```
2.Open browser http://localhost:50663/
