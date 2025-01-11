# Working with an Existing Database

Install dependencies:

```shell
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

## Reverse-engineering an existing database

```shell
dotnet \
    ef dbcontext scaffold "Data Source=../EFCoreForBeginners/Pizza.db" \
    Microsoft.EntityFrameworkCore.Sqlite --context-dir Data --output-dir Models
```

or with `-DataAnnotations` option to include data annotations into models:

```shell
dotnet \
    ef dbcontext scaffold "Data Source=../EFCoreForBeginners/Pizza.db" \
    Microsoft.EntityFrameworkCore.Sqlite --context-dir Data --output-dir Models --data-annotations
```

## Adding business logic

Use partial classes and extension methods to separate business logic from the generated code.

## What to do when the database schema changes

### Manual Approach

Manually adjust the models to match the database schema.

### Re-scaffolding

Delete models and context classes and run the scaffold command again.
