using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace BlogStore.Tags
{
    public class TagManager : DomainService, ITagManager
    {
        private readonly IRepository<Tag, Guid> _tagRepository;

        public TagManager(IRepository<Tag, Guid> repository)
        {
            _tagRepository = repository;
        }

        public async Task<Tag> CreateAsync(Tag tag)
        {
            if (await _tagRepository.AnyAsync(x => x.Title == tag.Title))
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.TagAlreadyExistsSameTitle, "There is a tag with same title.");
            }

            return await _tagRepository.InsertAsync(tag);
        }

        public async Task<Tag> GetAsync(Guid id)
        {
            return await _tagRepository.GetAsync(id);
        }

        public async Task<Tag> UpdateAsync(Tag tag)
        {
            return await _tagRepository.UpdateAsync(tag);
        }

        public async Task<List<Tag>> GetListAsync(List<Guid> guids)
        {
            return await _tagRepository.GetListAsync(x => guids.Contains(x.Id));
        }

        public async Task<List<Tag>> GetListAsync(int skipCount,
            int maxResultCount,
            string filter = null)
        {
            var query = await _tagRepository.GetQueryableAsync();

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
