using SafeView.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SafeView.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SafeViewController : AbpControllerBase
{
    protected SafeViewController()
    {
        LocalizationResource = typeof(SafeViewResource);
    }
}
