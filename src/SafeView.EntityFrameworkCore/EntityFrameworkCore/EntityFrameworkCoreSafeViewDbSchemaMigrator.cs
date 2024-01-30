using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SafeView.Data;
using Volo.Abp.DependencyInjection;

namespace SafeView.EntityFrameworkCore;

public class EntityFrameworkCoreSafeViewDbSchemaMigrator
    : ISafeViewDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSafeViewDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the SafeViewDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SafeViewDbContext>()
            .Database
            .MigrateAsync();
    }
}
