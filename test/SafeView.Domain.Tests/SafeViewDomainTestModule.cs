using Volo.Abp.Modularity;

namespace SafeView;

[DependsOn(
    typeof(SafeViewDomainModule),
    typeof(SafeViewTestBaseModule)
)]
public class SafeViewDomainTestModule : AbpModule
{

}
