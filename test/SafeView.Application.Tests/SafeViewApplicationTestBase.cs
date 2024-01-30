using Volo.Abp.Modularity;

namespace SafeView;

public abstract class SafeViewApplicationTestBase<TStartupModule> : SafeViewTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
