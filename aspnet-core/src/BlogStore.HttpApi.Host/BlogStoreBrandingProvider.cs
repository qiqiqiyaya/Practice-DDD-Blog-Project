using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BlogStore
{
    [Dependency(ReplaceServices = true)]
    public class BlogStoreBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "BlogStore";
    }
}
