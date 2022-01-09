using System.ComponentModel.DataAnnotations;

namespace BlogStore.Posts
{
    public class CreatePostDetailDto
    {
        [Required(AllowEmptyStrings = !PostDetailConsts.TitleRequired)]
        [StringLength(PostDetailConsts.TitleMaxStringLength)]
        public string Title { get; set; }

        /// <summary>
        /// the mete title to be used for browser title and SEO 
        /// </summary>
        [StringLength(PostDetailConsts.MetaTitleMaxStringLength)]
        public string MetaTitle { get; set; }

        /// <summary>
        /// the summary of the post to mention the key highlight.
        /// </summary>
        [StringLength(PostDetailConsts.SummaryMaxStringLength)]
        public string Summary { get; set; }

        [Required(AllowEmptyStrings = !PostDetailConsts.ContentRequired)]
        [StringLength(PostDetailConsts.ContentMaxStringLength)]
        public string Content { get; set; }
    }
}
