using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogStore.Tags
{
    public interface ITagAppService
    {
        Task<TagDto> CreateAsync([NotNull] TagDto input);

        Task<TagDto> UpdateAsync([NotNull] TagDto input);

        Task<TagDto> GetAsync(Guid id);

        Task<List<TagDto>> GetListAsync([NotNull] GetTagListDto input);
    }
}
