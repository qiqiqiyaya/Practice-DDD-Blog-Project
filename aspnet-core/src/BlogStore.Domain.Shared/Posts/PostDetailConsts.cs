using System;
using System.Collections.Generic;
using System.Text;

namespace BlogStore.Posts
{
    public class PostDetailConsts
    {
        public const bool TitleRequired = true;
        public const int TitleMaxStringLength = 100;

        public const bool ContentRequired = true;
        public const int ContentMaxStringLength = 50000;

        public const int MetaTitleMaxStringLength = 50;
        public const int SummaryMaxStringLength = 50;
    }
}
