using SafeView.Samples;
using Xunit;

namespace SafeView.EntityFrameworkCore.Applications;

[Collection(SafeViewTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SafeViewEntityFrameworkCoreTestModule>
{

}
