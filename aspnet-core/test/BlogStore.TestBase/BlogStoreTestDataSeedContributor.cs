using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace BlogStore
{
    public class BlogStoreTestDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        public async Task SeedAsync(DataSeedContext context)
        {
            /* Seed additional test data... */
        }
    }
}