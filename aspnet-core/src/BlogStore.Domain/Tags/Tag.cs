using JetBrains.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using BlogStore.Domain.Utils;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BlogStore.Tags
{
    public class Tag : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        [Required]
        [StringLength(TagConsts.TitleMaxStringLength)]
        public string Title { get; private set; }

        /// <summary>
        /// The meta title to be used for browser title and SEO.
        /// </summary>
        public string MetaTitle { get; private set; }

        /// <summary>
        /// The tag slug to form the URL.
        /// </summary>
        public string Slug { get; private set; }

        public string Content { get; private set; }

        public Guid? TenantId { get; private set; }

        public Tag(Guid id, [NotNull] string title)
        {
            Id = id;
            SetTitle(title);
            SetSlug(title);
            SetMetaTitle(title);
        }

        public Tag(Guid id, string title, [NotNull] string metaTitle, [NotNull] string slug)
        {
            Id = id;
            Title = title;
            SetSlug(slug);
            SetMetaTitle(metaTitle);
        }

        public void SetMetaTitle(string metaTitle)
        {
            MetaTitle = metaTitle;
        }

        public void SetSlug(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.TagSlugRequired, "The slug is required.");
            }
            Slug = SlugHelper.GenerateSlug(slug);
        }

        public void SetContent(string content)
        {
            Content = content;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.TagTitleRequired, "The title is required.");
            }

            Title = title;
        }
    }
}
