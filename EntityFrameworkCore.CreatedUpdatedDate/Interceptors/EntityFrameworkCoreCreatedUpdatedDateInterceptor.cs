using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EntityFrameworkCore.CreatedUpdatedDate.Interceptors;

public sealed class EntityFrameworkCoreCreatedUpdatedInterceptor : ISaveChangesInterceptor
{
    public ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = new())
    {
        var entries = eventData.Context!.ChangeTracker
            .Entries()
            .Where(e => e is { Entity: IEntityWithCreatedUpdatedDate, State: EntityState.Added or EntityState.Modified });

        foreach (var entityEntry in entries)
        {
            var entity = (IEntityWithCreatedUpdatedDate)entityEntry.Entity;
            entity.UpdatedDate = DateTimeOffset.UtcNow;
            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedDate = DateTimeOffset.UtcNow;
            }
        }

        return new ValueTask<InterceptionResult<int>>(result);
    }
}