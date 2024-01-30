using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SafeView.Data;

/* This is used if database provider does't define
 * ISafeViewDbSchemaMigrator implementation.
 */
public class NullSafeViewDbSchemaMigrator : ISafeViewDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
