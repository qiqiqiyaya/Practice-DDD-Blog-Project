using System;
using System.Threading.Tasks;
using BlogStore.Categories;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BlogStore
{
    public class BlogStoreTestDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category, long> _categoryRepository;
        public BlogStoreTestDataSeedContributor(IRepository<Category, long> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            /* Seed additional test data... */
            await _categoryRepository.InsertAsync(Category.Create(DateTime.UtcNow.ToString()));
        }
    }
}