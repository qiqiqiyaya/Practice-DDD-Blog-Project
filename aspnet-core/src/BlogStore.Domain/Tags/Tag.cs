using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BlogStore.Tags
{
    public class Tag : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public string Title { get; set; }

        /// <summary>
        /// The meta title to be used for browser title and SEO.
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// The tag slug to form the URL.
        /// </summary>
        public string Slug { get; set; }

        public string Content { get; set; }

        public Guid? TenantId { get; }
    }
}
