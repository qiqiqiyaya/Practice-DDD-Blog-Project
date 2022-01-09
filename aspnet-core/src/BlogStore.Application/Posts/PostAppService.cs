using System.Linq;
using System.Threading.Tasks;

namespace BlogStore.Posts
{
    public class PostAppService : BlogStoreAppService, IPostAppService
    {
        private IPostManager _manager;
        public PostAppService(IPostManager manager)
        {
            _manager = manager;
        }

        public async Task<bool> CreateAsync(CreatePostDto dto)
        {
            var detail = GetPostDetail(dto.PostDetail);
            var post = dto.ParentId.HasValue ?
                Post.Create(dto.AuthorId, dto.ParentId.Value)
                : Post.Create(dto.AuthorId);

            post.SetDetail(detail);
            if (dto.Published)
            {
                post.Publishing();
            }

            var categories = dto.PostCategories.Select(PostCategory.Create).ToList();
            post.SetCategories(categories);

            var tags = dto.PostTags.Select(PostTag.Create).ToList();
            post.SetTags(tags);

            post.SetSlug(dto.Slug);
            return await _manager.CreateAsync(post);
        }

        protected PostDetail GetPostDetail(CreatePostDetailDto dto)
        {
            var detail = PostDetail.Create(dto.Title, dto.Content);
            detail.SetMetaTitle(dto.MetaTitle);
            detail.SetSummary(dto.Summary);

            return detail;
        }
    }
}
