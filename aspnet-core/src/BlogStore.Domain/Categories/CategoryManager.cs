using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using System.Linq;

namespace BlogStore.Categories
{
    public class CategoryManager : DomainService, ICategoryManager
    {
        private readonly IRepository<Category, Guid> _categoryRepository;
        public CategoryManager(IRepository<Category, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            // Whether there is a category with same title.
            if (await _categoryRepository.AnyAsync(x => x.Title == category.Title))
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.CategoryAlreadyExistsSameTitle, "There is a category with same title.");
            }

            // if not exists parent category.
            if (category.ParentId.HasValue &&
                !await _categoryRepository.AnyAsync(x => x.Id == category.ParentId))
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.CategoryNotExistsParent, "The parent category does not exists.");
            }

            return await _categoryRepository.InsertAsync(category);
        }

        public async Task<Category> GetAsync(Guid id)
        {
            return await _categoryRepository.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            // if not exists parent category.
            if (category.ParentId.HasValue &&
                !await _categoryRepository.AnyAsync(x => x.Id == category.ParentId))
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.CategoryNotExistsParent, "The parent category does not exists.");
            }

            return await _categoryRepository.UpdateAsync(category);
        }

        public async Task<List<Category>> GetListAsync(List<Guid> guids)
        {
            return await _categoryRepository.GetListAsync(x => guids.Contains(x.Id));
        }

        public async Task<List<Category>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string filter = null)
        {
            var query = await _categoryRepository.GetQueryableAsync();

            // condition
            var entities = await AsyncExecuter.ToListAsync(
                query
                    .OrderBy(s => s.CreationTime)
                    .PageBy(skipCount, maxResultCount)
                    .WhereIf(!string.IsNullOrWhiteSpace(filter),
                        category => category.Title.Contains(filter)
                                    || category.MetaTitle.Contains(filter)
                                    || category.Slug.Contains(filter))
            );

            return entities;
        }
    }
}
