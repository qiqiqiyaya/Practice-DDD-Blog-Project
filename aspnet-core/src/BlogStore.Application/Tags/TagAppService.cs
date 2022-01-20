using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Guids;

namespace BlogStore.Tags
{
    public class TagAppService : BlogStoreAppService, ITagAppService
    {
        private readonly ITagManager _tagManager;
        private readonly IGuidGenerator _guidGenerator;

        public TagAppService(ITagManager tagManager,
            IGuidGenerator guidGenerator)
        {
            _tagManager = tagManager;
            _guidGenerator = guidGenerator;
        }

        public async Task<TagDto> CreateAsync([NotNull] TagDto input)
        {
            var tag = new Tag(_guidGenerator.Create(), input.Title);
            SetValue(input, tag);

            var result = await _tagManager.CreateAsync(tag);
            return ObjectMapper.Map<Tag, TagDto>(result);
        }

        public async Task<TagDto> UpdateAsync([NotNull] TagDto input)
        {
            if (!input.Id.HasValue)
            {
                throw new ArgumentNullException(nameof(input.Id));
            }

            var tag = await _tagManager.GetAsync(input.Id.Value);
            SetValue(input, tag);
            tag.SetTitle(input.Title);

            var result = await _tagManager.UpdateAsync(tag);
            return ObjectMapper.Map<Tag, TagDto>(result);
        }

        public async Task<TagDto> GetAsync(Guid id)
        {
            var result = await _tagManager.GetAsync(id);
            return ObjectMapper.Map<Tag, TagDto>(result);
        }

        public async Task<List<TagDto>> GetListAsync([NotNull] GetTagListDto input)
        {
            var result = await _tagManager.GetListAsync(input.SkipCount, input.MaxResultCount, input.Filter);
            return ObjectMapper.Map<List<Tag>, List<TagDto>>(result);
        }

        private void SetValue([NotNull] TagDto input, [NotNull] Tag tag)
        {
            if (!string.IsNullOrWhiteSpace(input.Slug))
            {
                tag.SetSlug(input.Slug);
            }

            if (!string.IsNullOrWhiteSpace(input.MetaTitle))
            {
                tag.SetMetaTitle(input.MetaTitle);
            }

            tag.SetContent(input.Content);
        }
    }
}
