using EntityFrameworkCore.CreatedUpdatedDate.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.CreatedUpdatedDate.Extensions;

public static class DbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder AddCreatedUpdatedInterceptor(this DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.AddInterceptors(new EntityFrameworkCoreCreatedUpdatedInterceptor());
}