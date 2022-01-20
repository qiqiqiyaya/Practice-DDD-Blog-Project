using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using System.Linq;
using Volo.Abp;

namespace BlogStore.Posts
{
    public class PostManager : DomainService, IPostManager
    {
        private readonly IRepository<Post, Guid> _repository;
        public PostManager(IRepository<Post, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<Post> CreateAsync(Post post)
        {
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
