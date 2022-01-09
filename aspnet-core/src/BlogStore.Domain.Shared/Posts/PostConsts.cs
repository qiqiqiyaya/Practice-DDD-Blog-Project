using System;
using System.Collections.Generic;
using System.Text;

namespace BlogStore.Posts
{
    public class PostConsts
    {
        public const bool AuthorIdRequired = true;
        public const bool PostDetailRequired = true;
        public const bool PublishedRequired = true;
        public const bool PostTagsRequired = true;
        public const bool PostCategoriesRequired = true;

        public const int SlugMaxStringLength = 20;
    }
}
