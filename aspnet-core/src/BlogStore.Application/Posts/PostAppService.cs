using System.Linq;
using System.Threading.Tasks;
using BlogStore.PostDetails;
using BlogStore.Tags;
using Volo.Abp.Guids;

namespace BlogStore.Posts
{
    public class PostAppService : BlogStoreAppService, IPostAppService
    {
        private readonly IPostManager _manager;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ITagManager _tagManager;

        public PostAppService(IPostManager manager,
            ITagManager tagManager,
            IGuidGenerator guidGenerator)
        {
            _tagManager = tagManager;
            _manager = manager;
            _guidGenerator = guidGenerator;
        }

        public async Task CreateAsync(CreatePostDto dto)
        {
            var detail = CreatePostDetail(dto.PostDetail);

            var tags = dto.Tags.Select(s => new PostTag(s)).ToList();
            var categories = dto.Categories.Select(s => new PostCategory(s)).ToList();

            var post = dto.AutoSetSlug
                ? new Post(_guidGenerator.Create(), dto.AuthorId, tags, categories, detail, true)
                : new Post(_guidGenerator.Create(), dto.AuthorId, tags, categories, detail);

            if (dto.Published)
            {
                post.Publishing();
            }

            await _manager.CreateAsync(post);
        }

        protected PostDetail CreatePostDetail(CreatePostDetailDto dto)
        {
            var detail = new PostDetail(dto.Title, dto.Content);
            detail.SetMetaTitle(dto.MetaTitle);
            detail.SetSummary(dto.Summary);

            return detail;
        }
    }
}
