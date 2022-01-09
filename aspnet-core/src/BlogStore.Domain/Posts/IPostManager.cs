using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace BlogStore.Posts
{
    public interface IPostManager : IDomainService
    {
        Task<bool> CreateAsync(Post post);
    }
}
