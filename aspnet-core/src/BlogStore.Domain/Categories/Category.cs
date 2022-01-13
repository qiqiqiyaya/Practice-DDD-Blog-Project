using JetBrains.Annotations;
using System;
using BlogStore.Domain.Utils;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BlogStore.Categories
{
    public class Category : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? ParentId { get; private set; }

        /// <summary>
        /// The category must have title.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// The meta title to be used for browser title and SEO .
        /// </summary>
        /// <remarks>
        /// if not exists value , then will automatic set value.
        /// </remarks>
        public string MetaTitle { get; private set; }

        /// <summary>
        /// The category slug to from the url .
        /// A URL slug is the part of the URL after the last backslash.
        /// </summary>
        /// <remarks>
        /// if not exists value , then will automatic set value.
        /// </remarks>
        public string Slug { get; private set; }

        /// <summary>
        /// can be null.
        /// </summary>
        public string Content { get; private set; }

        public Guid? TenantId { get; private set; }

        protected Category()
        {

        }


        public static Category Create(Guid id, [NotNull] string title, bool autoSetMetaTitle = true, bool autoSetSlug = true)
        {
            Check.NotNull(id, nameof(id));
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.CategoryMustHaveTitle, "The category must have title.");
            }

            var entity = new Category()
            {
                Title = title,
                Id = id,
            };

            if (autoSetMetaTitle)
            {
                entity.AutoSetMetaTitle();
            }

            if (autoSetSlug)
            {
                entity.AutoSetSlug();
            }

            return entity;
        }

        public static Category Create(Guid id, [NotNull] string title, Guid parentId, bool autoSetMetaTitle = true, bool autoSetSlug = true)
        {
            var entity = Create(id, title,autoSetMetaTitle,autoSetSlug);
            entity.SetParentId(parentId);
            return entity;
        }

        public void SetParentId(Guid parentId)
        {
            ParentId = parentId;
        }

        public void SetTitle(string title)
        {
            Check.NotNull(title, nameof(title));
            Title = title;
        }

        public void SetMetaTitle(string metaTitle)
        {
            MetaTitle = metaTitle;
        }

        /// <summary>
        /// if not exists value , then will automatic set value.
        /// </summary>
        /// <remarks>
        /// default is Title.
        /// </remarks>
        public void AutoSetMetaTitle()
        {
            MetaTitle = Title;
        }

        public void SetSlug(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.CategorySlugRequired, "The slug is required.");
            }
            
            Slug = SlugHelper.GenerateSlug(slug);
        }

        /// <summary>
        /// if not exists value , then will automatic set value.
        /// </summary>
        /// <remarks>
        /// default is Title.
        /// </remarks>
        public void AutoSetSlug()
        {
            Slug = SlugHelper.GenerateSlug(Title);
        }

        public void SetContent(string content)
        {
            Content = content;
        }
    }
}
