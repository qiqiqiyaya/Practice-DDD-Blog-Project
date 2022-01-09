using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace BlogStore.Posts
{
    public class PostManager : DomainService, IPostManager
    {
        private readonly IRepository<Post, long> _repository;
        public PostManager(IRepository<Post, long> repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(Post post)
        {
            await _repository.InsertAsync(post);
            return true;
        }
    }
}
