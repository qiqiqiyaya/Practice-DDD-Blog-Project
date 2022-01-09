using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace BlogStore.Categories
{
    public class CategoryManager : DomainService, ICategoryManager
    {
        private readonly IRepository<Category, long> _categoryRepository;
        public CategoryManager(IRepository<Category, long> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> CreateAsync(Category category)
        {
            // Whether there is a category with same title.
            if (await _categoryRepository.AnyAsync(x => x.Title == category.Title))
            {
                throw new BusinessException(BlogStoreDomainErrorCodes.CategoryAlreadyExistsSameTitle, "There is a category with same title.");
            }

            // Whether there is a category with give id.
            if (await _categoryRepository.AnyAsync(x => x.Id == category.ParentId))
            {
                throw new BusinessException(BlogStoreDomainErrorCodes.CategoryNotExistsParent, "The parent category does not exists.");
            }

            await _categoryRepository.InsertAsync(category);
            return true;
        }
    }
}
