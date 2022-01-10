﻿using Volo.Abp.Application.Dtos;

namespace BlogStore.Categories
{
    public class CategoryDto : ExtensibleFullAuditedEntityDto<long>
    {
        public long? ParentId { get; set; }

        public string Title { get; set; }

        public string MetaTitle { get; set; }

        public string Slug { get; set; }

        public string Content { get; set; }
    }
}
