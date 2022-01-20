using System;
using Volo.Abp.Application.Dtos;

namespace BlogStore.Categories
{
    public class CategoryDto : EntityDto<Guid>
    {
        public Guid? ParentId { get; set; }

        public string Title { get; set; }

        public string MetaTitle { get; set; }

        public string Slug { get; set; }

        public string Content { get; set; }
    }
}
