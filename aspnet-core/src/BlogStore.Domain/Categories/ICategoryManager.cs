using System.Threading.Tasks;

namespace BlogStore.Categories
{
    public interface ICategoryManager
    {
        Task<bool> CreateAsync(Category category);
    }
}
