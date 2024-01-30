using System.Threading.Tasks;

namespace SafeView.Data;

public interface ISafeViewDbSchemaMigrator
{
    Task MigrateAsync();
}
