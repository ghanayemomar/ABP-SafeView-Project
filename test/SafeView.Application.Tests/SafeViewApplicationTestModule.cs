using Volo.Abp.Modularity;

namespace SafeView;

[DependsOn(
    typeof(SafeViewApplicationModule),
    typeof(SafeViewDomainTestModule)
)]
public class SafeViewApplicationTestModule : AbpModule
{

}
