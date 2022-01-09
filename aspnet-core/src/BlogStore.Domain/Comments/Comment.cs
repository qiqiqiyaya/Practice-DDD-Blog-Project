using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BlogStore.Comments
{
    public class Comment: FullAuditedAggregateRoot<long>,IMultiTenant
    {
        public string Title { get; set; }

        public bool Published { get; set; }

        public DateTime? PublishedAt { get; set; }

        public string Content { get; set; }

        public Guid? TenantId { get; }
    }
}
