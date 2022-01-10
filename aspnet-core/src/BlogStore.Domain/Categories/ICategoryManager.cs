using System.Threading.Tasks;

namespace BlogStore.Categories
{
    public interface ICategoryManager
    {
        Task<Category> CreateAsync(Category category);

        Task<Category> GetAsync(long id);
    }
}
