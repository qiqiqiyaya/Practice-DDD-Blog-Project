using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BlogStore.Categories
{
    public interface ICategoryAppService: IApplicationService
    {
        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);

        Task<CategoryDto> UpdateAsync(UpdateCategoryDto dto);

        Task<CategoryDto> GetAsync(Guid id);

        Task<List<CategoryDto>> GetListAsync(GetCategoryListDto input);
    }
}
