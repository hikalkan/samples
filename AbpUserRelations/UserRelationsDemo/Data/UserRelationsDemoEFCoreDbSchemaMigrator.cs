using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace UserRelationsDemo.Data;

public class UserRelationsDemoEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public UserRelationsDemoEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the UserRelationsDemoDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<UserRelationsDemoDbContext>()
            .Database
            .MigrateAsync();
    }
}
