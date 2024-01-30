using Microsoft.AspNetCore.Builder;
using SafeView;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<SafeViewWebTestModule>();

public partial class Program
{
}
