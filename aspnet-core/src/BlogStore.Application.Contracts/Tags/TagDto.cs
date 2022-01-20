using System;
using System.ComponentModel.DataAnnotations;

namespace BlogStore.Tags
{
    public class TagDto
    {
        public Guid? Id { get; set; }

        [Required]
        [StringLength(TagConsts.TitleMaxStringLength)]
        public string Title { get; set; }

        [StringLength(TagConsts.MetaTitleMaxStringLength)]
        public string MetaTitle { get; set; }

        [StringLength(TagConsts.SlugMaxStringLength)]
        public string Slug { get; set; }

        [StringLength(TagConsts.ContentMaxStringLength)]
        public string Content { get; set; }
    }
}
