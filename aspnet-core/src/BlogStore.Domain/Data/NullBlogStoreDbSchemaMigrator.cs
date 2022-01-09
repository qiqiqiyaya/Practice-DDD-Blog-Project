using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BlogStore.Data
{
    /* This is used if database provider does't define
     * IBlogStoreDbSchemaMigrator implementation.
     */
    public class NullBlogStoreDbSchemaMigrator : IBlogStoreDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}