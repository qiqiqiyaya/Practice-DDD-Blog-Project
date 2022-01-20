using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace BlogStore.Posts
{
    public interface IPostManager : IDomainService
    {
        Task<Post> CreateAsync(Post post);
    }
}
