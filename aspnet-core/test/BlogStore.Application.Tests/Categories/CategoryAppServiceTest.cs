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
        private readonly IRepository<Category, long> _categoryRepository;
        private readonly ICategoryAppService _userAppService;

        public CategoryAppServiceTest()
        {
            _userAppService = GetRequiredService<ICategoryAppService>();
            _categoryRepository = GetRequiredService<IRepository<Category, long>>();
        }

        [Fact]
        public async Task Create_Test()
        {
            var category = new CreateCategoryDto();
            category.Title = DateTime.UtcNow.ToString();
            category.Content = null;
            category.MetaTitle = null;
            category.Slug = null;
            
            var result = await _userAppService.CreateAsync(category);
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
