using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Guids;

namespace BlogStore.Categories
{
    public class CategoryAppService : BlogStoreAppService, ICategoryAppService
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IGuidGenerator _guidGenerator;
        public CategoryAppService(ICategoryManager categoryManager,
            IGuidGenerator guidGenerator)
        {
            _categoryManager = categoryManager;
            _guidGenerator = guidGenerator;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = dto.ParentId.HasValue
                ? Category.Create(_guidGenerator.Create(), dto.Title, dto.ParentId.Value, dto.AutoSetMetaTitle, dto.AutoSetSlug)
                : Category.Create(_guidGenerator.Create(), dto.Title, dto.AutoSetMetaTitle, dto.AutoSetSlug);

            category.SetContent(dto.Content);
            if (!string.IsNullOrWhiteSpace(dto.MetaTitle))
            {
                category.SetMetaTitle(dto.MetaTitle);
            }

            if (!string.IsNullOrWhiteSpace(dto.Slug))
            {
                category.SetSlug(dto.Slug);
            }

            var result = await _categoryManager.CreateAsync(category);
            return ObjectMapper.Map<Category, CategoryDto>(result);
        }

        public async Task<CategoryDto> UpdateAsync(UpdateCategoryDto dto)
        {
            var category = await _categoryManager.GetAsync(dto.Id);
            category.SetTitle(dto.Title);
            category.SetContent(dto.Content);
            if (dto.AutoSetMetaTitle)
            {
                category.AutoSetMetaTitle();
            }
            else
            {
                category.SetMetaTitle(dto.MetaTitle);
            }

            if (dto.AutoSetSlug)
            {
                category.AutoSetSlug();
            }
            else
            {
                category.SetSlug(dto.Slug);
            }

            if (dto.ParentId.HasValue)
            {
                category.SetParentId(dto.ParentId.Value);
            }

            var result = await _categoryManager.UpdateAsync(category);
            return ObjectMapper.Map<Category, CategoryDto>(result);
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var result = await _categoryManager.GetAsync(id);
            return ObjectMapper.Map<Category, CategoryDto>(result);
        }

        public async Task<List<CategoryDto>> GetListAsync(GetCategoryListDto input)
        {
            var result = await _categoryManager.GetListAsync(input.SkipCount, input.MaxResultCount, input.Filter);
            return ObjectMapper.Map<List<Category>, List<CategoryDto>>(result);
        }
    }
}
