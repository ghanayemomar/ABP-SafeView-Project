using SafeView.Samples;
using Xunit;

namespace SafeView.EntityFrameworkCore.Domains;

[Collection(SafeViewTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<SafeViewEntityFrameworkCoreTestModule>
{

}
