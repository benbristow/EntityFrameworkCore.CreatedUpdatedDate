# EntityFrameworkCore.CreatedUpdatedDate

[![Build project](https://github.com/benbristow/EntityFrameworkCore.CreatedUpdatedDate/actions/workflows/main.yml/badge.svg)](https://github.com/benbristow/EntityFrameworkCore.CreatedUpdatedDate/actions/workflows/main.yml)

Add CreatedDate/UpdatedDate to your entities and have them automatically updated when saving to the database.

## Usage

Register the interceptor in your `DbContext`:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.AddCreatedUpdatedInterceptor();
}
```

Implement `IEntityWithCreatedUpdatedDate` on your entities:

```csharp
public class MyEntity : IEntityWithCreatedUpdatedDate
{
    public int Id { get; set; }
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}
```
