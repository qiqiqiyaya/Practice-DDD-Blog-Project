using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BlogStore.Posts
{
    public interface IPostAppService : IApplicationService
    {
        Task CreateAsync(CreatePostDto dto);
    }
}
