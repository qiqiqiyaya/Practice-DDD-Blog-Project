using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogStore.Tags
{
    public interface ITagManager
    {
        Task<Tag> CreateAsync(Tag tag);

        Task<Tag> GetAsync(Guid id);

        Task<Tag> UpdateAsync(Tag tag);

        Task<List<Tag>> GetListAsync(List<Guid> guids);

        Task<List<Tag>> GetListAsync(int skipCount, int maxResultCount, string filter = null);

        /// <summary>
        /// is exists?
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> IsExistsAsync(params Guid[] ids);
    }
}
