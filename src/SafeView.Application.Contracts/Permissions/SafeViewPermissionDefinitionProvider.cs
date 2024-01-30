using SafeView.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SafeView.Permissions;

public class SafeViewPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SafeViewPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SafeViewPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SafeViewResource>(name);
    }
}
