using System.Threading.Tasks;

namespace BlogStore.Categories
{
    public class CategoryAppService : BlogStoreAppService, ICategoryAppService
    {
        private ICategoryManager _categoryManager;
        public CategoryAppService(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public async Task<bool> CreateAsync(CreateCategoryDto dto)
        {
            var category = dto.ParentId.HasValue
                ? Category.Create(dto.Title, dto.ParentId.Value)
                : Category.Create(dto.Title);

            category.SetContent(dto.Content);
            category.SetMetaTitle(dto.MetaTitle);
            category.SetSlug(dto.Slug);

            return await _categoryManager.CreateAsync(category);
        }
    }
}
