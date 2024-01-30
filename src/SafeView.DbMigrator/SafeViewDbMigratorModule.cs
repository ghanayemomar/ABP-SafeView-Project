using SafeView.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SafeView.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SafeViewEntityFrameworkCoreModule),
    typeof(SafeViewApplicationContractsModule)
    )]
public class SafeViewDbMigratorModule : AbpModule
{
}
