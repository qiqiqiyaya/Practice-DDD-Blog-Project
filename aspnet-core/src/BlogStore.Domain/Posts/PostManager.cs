using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using System.Linq;
using BlogStore.Tags;
using Volo.Abp;
using BlogStore.Categories;

namespace BlogStore.Posts
{
    public class PostManager : DomainService, IPostManager
    {
        private readonly IRepository<Post, Guid> _repository;
        private readonly ITagManager _tagManager;
        private readonly ICategoryManager _categoryManager;

        public PostManager(IRepository<Post, Guid> repository,
            ITagManager tagManager,
            ICategoryManager categoryManager)
        {
            _repository = repository;
            _tagManager = tagManager;
            _categoryManager = categoryManager;
        }

        public async Task<Post> CreateAsync(Post post)
        {
            // Check tag
            var tags = post.Tags.Select(s => s.TagId).ToArray();
            if (!await _tagManager.IsExistsAsync(tags))
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.PostTagsOneOrMoreNotExist, "One or more tags do not exist.");
            }

            // Check category
            var categories = post.Categories.Select(s => s.CategoryId).ToArray();
            if (!await _categoryManager.IsExistsAsync(categories))
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.PostCategoriesOneOrMoreNotExist, "One or more Categories do not exist.");
            }

            // check parent
            if (post.ParentId.HasValue
                && !await _repository.AnyAsync(x => x.ParentId == post.ParentId.Value))
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.ParentPostNotExists, "The parent post does not exists.");
            }

            return await _repository.InsertAsync(post);
        }
    }
}
