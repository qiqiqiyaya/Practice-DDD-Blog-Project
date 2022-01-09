using Volo.Abp.Settings;

namespace BlogStore.Settings
{
    public class BlogStoreSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(BlogStoreSettings.MySetting1));
        }
    }
}
