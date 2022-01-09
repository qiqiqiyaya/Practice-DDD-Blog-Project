using BlogStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BlogStore.Permissions
{
    public class BlogStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BlogStorePermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(BlogStorePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BlogStoreResource>(name);
        }
    }
}
