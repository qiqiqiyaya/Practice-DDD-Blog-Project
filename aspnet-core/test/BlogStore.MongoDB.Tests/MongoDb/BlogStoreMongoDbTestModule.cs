using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace BlogStore.MongoDB
{
    [DependsOn(
        typeof(BlogStoreTestBaseModule),
        typeof(BlogStoreMongoDbModule)
        )]
    public class BlogStoreMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var stringArray = BlogStoreMongoDbFixture.ConnectionString.Split('?');
            var connectionString = stringArray[0].EnsureEndsWith('/') +
                                       "Db_" +
                                   Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}
