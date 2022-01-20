using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogStore.Categories
{
    public interface ICategoryManager
    {
        Task<Category> CreateAsync(Category category);

        Task<Category> GetAsync(Guid id);

        Task<Category> UpdateAsync(Category category);

        Task<List<Category>> GetListAsync(List<Guid> guids);

        Task<List<Category>> GetListAsync(int skipCount, int maxResultCount, string filter = null);
    }
}
