using System;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Xunit;
using System.Linq;

namespace BlogStore.Categories
{
    [Collection(BlogStoreTestConsts.CollectionDefinitionName)]
    public class CategoryAppServiceTest : BlogStoreApplicationTestBase
    {
        private readonly IRepository<Category, Guid> _categoryRepository;
        private readonly ICategoryAppService _categoryAppService;

        public CategoryAppServiceTest()
        {
            _categoryAppService = GetRequiredService<ICategoryAppService>();
            _categoryRepository = GetRequiredService<IRepository<Category, Guid>>();
        }

        [Fact]
        public async Task Create_Test()
        {
            var category = new CreateCategoryDto();
            category.Title = DateTime.UtcNow.ToString();
            category.Content = null;
            category.MetaTitle = null;
            category.Slug = null;
            
            var result = await _categoryAppService.CreateAsync(category);
            result.MetaTitle.ShouldNotBeNull();
            result.Slug.ShouldNotBeNull();
            result.Title.ShouldNotBeNull();
            result.Content.ShouldBeNull();
        }
        
        [Fact]
        public async Task TakeTop1_Test()
        {
            var query = await _categoryRepository.GetQueryableAsync();
            var entity= query.Take(1).SingleOrDefault();
            entity.ShouldNotBeNull();
        }
    }
}
