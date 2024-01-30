using SafeView.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SafeView.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class SafeViewPageModel : AbpPageModel
{
    protected SafeViewPageModel()
    {
        LocalizationResourceType = typeof(SafeViewResource);
    }
}
