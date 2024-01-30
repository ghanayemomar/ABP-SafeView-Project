using Volo.Abp.Settings;

namespace SafeView.Settings;

public class SafeViewSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SafeViewSettings.MySetting1));
    }
}
