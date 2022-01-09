using Volo.Abp.Modularity;

namespace BlogStore
{
    [DependsOn(
        typeof(BlogStoreApplicationModule),
        typeof(BlogStoreDomainTestModule)
        )]
    public class BlogStoreApplicationTestModule : AbpModule
    {

    }
}