﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogStore.Posts
{
    public class CreatePostDto
    {
        [Required(AllowEmptyStrings = !PostConsts.AuthorIdRequired)]
        public Guid AuthorId { get; set; }

        public long? ParentId { get; set; }

        /// <summary>
        /// the post slug to from the URL.
        /// </summary>
        [StringLength(PostConsts.SlugMaxStringLength)]
        public string Slug { get; set; }

        /// <summary>
        /// detail
        /// </summary>
        [Required(AllowEmptyStrings = !PostConsts.PostDetailRequired)]
        public CreatePostDetailDto PostDetail { get; set; }

        /// <summary>
        /// Is publishing?
        /// </summary>
        [Required(AllowEmptyStrings = !PostConsts.PublishedRequired)]
        public bool Published { get; set; }
        
        [Required(AllowEmptyStrings = !PostConsts.PostTagsRequired)]
        public List<long> PostTags { get; set; }
        
        [Required(AllowEmptyStrings = !PostConsts.PostCategoriesRequired)]
        public List<long> PostCategories { get; set; }
    }
}
