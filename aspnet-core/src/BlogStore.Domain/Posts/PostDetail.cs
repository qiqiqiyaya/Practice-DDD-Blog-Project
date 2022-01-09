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

        protected PostDetail()
        {

        }

        public static PostDetail Create([NotNull]string title,[NotNull] string content)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new BusinessException(BlogStoreDomainErrorCodes.PostDetailMustHaveTitle, "Detail of post must have title.");
            }
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new BusinessException(BlogStoreDomainErrorCodes.PostDetailMustHaveContent, "Detail of post must have content.");
            }

            var detail = new PostDetail();
            detail.SetTitle(title);
            detail.SetContent(content);
            return detail;
        }

        public void SetTitle([NotNull] string title)
        {
            Check.NotNull(title, nameof(title));
            Title = title;
        }

        public void SetMetaTitle(string metaTitle)
        {
            Title = metaTitle;
        }

        public void SetSummary(string summary)
        {
            Summary = summary;
        }

        public void SetContent([NotNull] string content)
        {
            Check.NotNull(content, nameof(content));
            Content = content;
        }
    }
}
