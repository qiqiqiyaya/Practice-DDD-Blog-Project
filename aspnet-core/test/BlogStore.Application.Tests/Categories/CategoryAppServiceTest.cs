using System;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogStore.Categories
{
    [Collection(BlogStoreTestConsts.CollectionDefinitionName)]
    public class CategoryAppServiceTest : BlogStoreApplicationTestBase
    {
        private readonly ICategoryAppService _userAppService;

        public CategoryAppServiceTest()
        {
            _userAppService = GetRequiredService<ICategoryAppService>();
        }

        [Fact]
        public async Task Create_Test()
        {
            var category = new CreateCategoryDto();
            category.Title = DateTime.UtcNow.ToString();
            category.Content = null;
            category.MetaTitle = null;
            category.Slug = null;

            Assert.True(await _userAppService.CreateAsync(category));
        }

    }
}
