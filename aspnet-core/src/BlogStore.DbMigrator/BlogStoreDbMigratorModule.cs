using BlogStore.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace BlogStore.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BlogStoreMongoDbModule),
        typeof(BlogStoreApplicationContractsModule)
        )]
    public class BlogStoreDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
