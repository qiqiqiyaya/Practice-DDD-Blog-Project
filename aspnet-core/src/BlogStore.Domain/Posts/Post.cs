using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using BlogStore.Domain.Utils;
using BlogStore.PostDetails;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BlogStore.Posts
{
    public class Post : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid AuthorId { get; private set; }

        public Guid? ParentId { get; private set; }

        /// <summary>
        /// the post slug to from the URL.
        /// </summary>
        public string Slug { get; private set; }

        /// <summary>
        /// it can be used to identity whether the post is publicly available .
        /// </summary>
        public bool Published { get; private set; }

        public DateTime? PublishedAt { get; private set; }

        public Guid? TenantId { get; private set; }

        /// <summary>
        /// post detail
        /// </summary>
        public Guid PostDetail { get; private set; }

        /// <summary>
        /// tag of post
        /// </summary>
        public ICollection<PostTag> Tags { get; private set; }

        public ICollection<PostCategory> Categories { get; set; }

        /// <summary>
        /// The Post Meta Table can be used to store additional information of a post including the post banner URL etc. 
        /// </summary>
        public PostMeta PostMeta { get; private set; }

        public Post(Guid id, Guid authorId, [NotNull] List<PostTag> tags, [NotNull] List<PostCategory> categories, [NotNull] PostDetail detail)
            : this(id, authorId, tags, categories, detail, false)
        {

        }

        public Post(Guid id, Guid authorId, [NotNull] List<PostTag> tags, [NotNull] List<PostCategory> categories, [NotNull] PostDetail detail, bool autoSetSlug)
            : base(id)
        {
            Check.NotNull(authorId, nameof(authorId));
            AuthorId = authorId;
            SetTags(tags);
            SetCategories(categories);
            SetDetail(detail);
            if (autoSetSlug)
            {
                SetSlug(detail.Title);
            }
        }

        public void SetParentId(Guid parentId)
        {
            Check.NotNull(parentId, nameof(parentId));
            ParentId = parentId;
        }

        public void SetSlug([NotNull] string slug)
        {
            Check.NotNullOrWhiteSpace(slug, nameof(slug));
            Slug = SlugHelper.GenerateSlug(slug);
        }

        /// <summary>
        /// publish the post
        /// </summary>
        public void Publishing()
        {
            if (Published || PublishedAt.HasValue)
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.PostAlreadyPublished, "The post had already published.");
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
