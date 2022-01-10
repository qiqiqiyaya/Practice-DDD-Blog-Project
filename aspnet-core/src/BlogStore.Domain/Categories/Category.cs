using System;
using BlogStore.Helper;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Validation;

namespace BlogStore.Categories
{
    public class Category : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public long? ParentId { get; private set; }

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

        public static Category Create([NotNull] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new BusinessException(BlogStoreDomainErrorCodes.CategoryMustHaveTitle, "The category must have title.");
            }

            var entity = new Category()
            {
                Title = title,
            };
            entity.SetMetaTitle(title);
            entity.SetSlug(title);
            return entity;
        }

        public static Category Create([NotNull] string title, long parentId)
        {
            var entity = Create(title);
            entity.SetParentId(parentId);
            return entity;
        }

        public void SetParentId(long parentId)
        {
            if (parentId <= 0)
            {
                throw new ArgumentException("the id of parent post can not less than or equal zero.");
            }
            ParentId = parentId;
        }

        /// <summary>
        /// if not exists value , then will automatic set value.
        /// </summary>
        /// <remarks>
        /// default is Title.
        /// </remarks>
        /// <param name="metaTitle"></param>
        public void SetMetaTitle(string metaTitle)
        {
            // if not exists value , then will automatic set value.
            if (string.IsNullOrWhiteSpace(metaTitle))
            {
                MetaTitle = Title;
                return;
            }
            MetaTitle = metaTitle;
        }

        public void SetSlug(string slug)
        {
            // if not exists value , then will automatic set value.
            if (string.IsNullOrWhiteSpace(slug))
            {
                Slug = SlugHelper.GenerateSlug(Title);
                return;
            }
            Slug = slug;
        }

        public void SetContent(string content)
        {
            Content = content;
        }
    }
}
