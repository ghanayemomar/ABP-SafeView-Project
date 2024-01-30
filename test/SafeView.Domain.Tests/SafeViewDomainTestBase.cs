using Volo.Abp.Modularity;

namespace SafeView;

/* Inherit from this class for your domain layer tests. */
public abstract class SafeViewDomainTestBase<TStartupModule> : SafeViewTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
