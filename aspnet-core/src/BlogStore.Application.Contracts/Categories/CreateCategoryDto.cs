using System;
using System.ComponentModel.DataAnnotations;

namespace BlogStore.Categories
{
    public class CreateCategoryDto
    {
        public Guid? ParentId { get; set; }

        [Required(AllowEmptyStrings = !CategoryConsts.TitleRequired)]
        [StringLength(CategoryConsts.TitleMaxStringLength)]
        public string Title { get; set; }

        /// <summary>
        /// The meta title to be used for browser title and SEO .
        /// </summary>
        [StringLength(CategoryConsts.MetaTitleMaxStringLength)]
        public string MetaTitle { get; set; }

        /// <summary>
        /// The category slug to from the url .
        /// </summary>
        [StringLength(CategoryConsts.SlugMaxStringLength)]
        public string Slug { get; set; }

        [StringLength(CategoryConsts.ContentMaxStringLength)]
        public string Content { get; set; }

        [Required]
        public bool AutoSetSlug { get; set; }   
        
        [Required]
        public bool AutoSetMetaTitle { get; set; }
    }
}
