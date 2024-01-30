using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace SafeView.Web;

[Dependency(ReplaceServices = true)]
public class SafeViewBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SafeView";
}
