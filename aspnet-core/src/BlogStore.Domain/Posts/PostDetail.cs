using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace BlogStore.Posts
{
    public class PostDetail : Entity<long>, IMultiTenant
    {
        public string Title { get; private set; }

        /// <summary>
        /// the mete title to be used for browser title and SEO 
        /// </summary>
        public string MetaTitle { get; private set; }

        /// <summary>
        /// the summary of the post to mention the key highlight.
        /// </summary>
        public string Summary { get; private set; }

        public string Content { get; private set; }

        public Guid? TenantId { get; }

        public PostDetail([NotNull] string title, [NotNull] string content)
        {
            SetTitle(title);
            SetContent(content);
        }

        public void SetTitle([NotNull] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.PostDetailMustHaveTitle, "The title is required.");
            }

            Title = title;
        }

        public void SetMetaTitle(string metaTitle)
        {
            MetaTitle = metaTitle;
        }

        public void SetSummary(string summary)
        {
            Summary = summary;
        }

        public void SetContent([NotNull] string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new UserFriendlyException(BlogStoreDomainErrorCodes.PostDetailMustHaveContent, "The content is required.");
            }

            Content = content;
        }
    }
}
