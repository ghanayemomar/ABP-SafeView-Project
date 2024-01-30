using System;
using System.Collections.Generic;
using System.Text;
using SafeView.Localization;
using Volo.Abp.Application.Services;

namespace SafeView;

/* Inherit your application services from this class.
 */
public abstract class SafeViewAppService : ApplicationService
{
    protected SafeViewAppService()
    {
        LocalizationResource = typeof(SafeViewResource);
    }
}
