using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Validation;

namespace BlogStore.Posts
{
    public class Post : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public Guid AuthorId { get; private set; }

        public long? ParentId { get; private set; }

        /// <summary>
        /// the post slug to from the URL.
        /// </summary>
        public string Slug { get; private set; }

        /// <summary>
        /// it can be used to identity whether the post is publicly available .
        /// </summary>
        public bool Published { get; private set; }

        public DateTime? PublishedAt { get; private set; }

        public Guid? TenantId { get; }

        /// <summary>
        /// detail
        /// </summary>
        public PostDetail PostDetail { get; private set; }

        /// <summary>
        /// tag of post
        /// </summary>
        public ICollection<PostTag> Tags { get; private set; }

        public ICollection<PostCategory> Categories { get; set; }

        /// <summary>
        /// The Post Meta Table can be used to store additional information of a post including the post banner URL etc. 
        /// </summary>
        public PostMeta PostMeta { get; private set; }

        protected Post()
        {

        }

        #region create
        public static Post Create(Guid authorId)
        {
            Check.NotNull(authorId, nameof(authorId));
            return new Post()
            {
                AuthorId = authorId,
            };
        }

        public static Post Create(Guid authorId, long parentId)
        {
            var post = Create(authorId);
            post.SetParentId(parentId);
            return post;
        }

        public static Post Create(Guid authorId, long parentId, [NotNull] string slug)
        {
            var post = Create(authorId);
            post.SetParentId(parentId);
            post.SetSlug(slug);
            return post;
        }
        #endregion

        public void SetParentId(long parentId)
        {
            if (parentId <= 0)
            {
                throw new ArgumentException("the id of parent post can not less than or equal zero.");
            }
            ParentId = parentId;
        }

        public void SetSlug([NotNull] string slug)
        {
            Check.NotNullOrWhiteSpace(slug, nameof(slug));
            Slug = slug;
        }

        /// <summary>
        /// publish the post
        /// </summary>
        public void Publishing()
        {
            if (Published || PublishedAt.HasValue)
            {
                throw new BusinessException(BlogStoreDomainErrorCodes.PostAlreadyPublished, "The post has already published.");
            }

            Published = true;
            PublishedAt = DateTime.Now;
        }

        public void SetDetail([NotNull] PostDetail detail)
        {
            Check.NotNull(detail, nameof(detail));
            PostDetail = detail;
        }

        public void SetTags(ICollection<PostTag> tags)
        {
            if (tags == null || tags.Count == 0)
            {
                throw new BusinessException(BlogStoreDomainErrorCodes.PostTagMustHaveOne, "The tag of post must have one.");
            }
            Tags = tags;
        }

        public void SetCategories(ICollection<PostCategory> categories)
        {
            if (categories == null || categories.Count == 0)
            {
                throw new BusinessException(BlogStoreDomainErrorCodes.PostCategoryMustHaveOne, "The category of post must have one.");
            }
            Categories = categories;
        }

        public void SetPostMeta(PostMeta postMeta)
        {
            Check.NotNull(postMeta, nameof(postMeta));
            PostMeta = postMeta;
        }
    }
}
