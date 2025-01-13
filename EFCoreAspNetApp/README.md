# ASP.NET Core Web App With EF Core

## Store configurations in a secret store

Initialize a secret store:

```shell
dotnet user-secrets init
```

Add the database connection string to the secret store:

```shell
dotnet user-secrets set "ConnectionStrings:PizzaStore" "Data Source=../EFCoreForBeginners/Pizza.db"
```

## Scaffold CRUD pages

```shell
dotnet 
```
