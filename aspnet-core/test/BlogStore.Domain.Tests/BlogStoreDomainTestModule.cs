using BlogStore.MongoDB;
using Volo.Abp.Modularity;

namespace BlogStore
{
    [DependsOn(
        typeof(BlogStoreMongoDbTestModule)
        )]
    public class BlogStoreDomainTestModule : AbpModule
    {

    }
}