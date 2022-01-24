using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogStore.Categories;
using BlogStore.Posts;
using BlogStore.Tags;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Xunit;

namespace BlogStore.Post
{
    [Collection(BlogStoreTestConsts.CollectionDefinitionName)]
    public sealed class PostServiceTest : BlogStoreApplicationTestBase
    {
        private IPostAppService _postAppService;
        private ITagAppService _tagAppService;
        private ICategoryAppService _categoryAppService;
        private readonly IGuidGenerator _guidGenerator;

        public PostServiceTest()
        {
            _postAppService = GetRequiredService<IPostAppService>();
            _tagAppService = GetRequiredService<ITagAppService>();
            _categoryAppService = GetRequiredService<ICategoryAppService>();
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public async Task Create_Post_Test()
        {
            var tags = await _tagAppService.GetListAsync(new GetTagListDto());
            var categories= await _categoryAppService.GetListAsync(new GetCategoryListDto());
            var dto = new CreatePostDto();
            dto.AuthorId = _guidGenerator.Create();
            dto.AutoSetSlug = true;
            dto.Categories = categories.Select(c => c.Id).ToList();
            dto.Tags = tags.Select(s => s.Id).ToList();

            dto.PostDetail = new CreatePostDetailDto()
            {
                Content = "fdasfdadfasdfads",
                MetaTitle = "fdasfdsa",
                Summary = "fdsafdsa",
                Title = "fdasfdsa"
            };

            dto.Published = true;
        }
    }
}
