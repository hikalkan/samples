using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace ComplexTypeDemo.Data;

public class ComplexTypeDemoEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public ComplexTypeDemoEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the ComplexTypeDemoDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ComplexTypeDemoDbContext>()
            .Database
            .MigrateAsync();
    }
}
