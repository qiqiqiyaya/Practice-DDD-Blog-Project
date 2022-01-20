namespace BlogStore
{
    public static class BlogStoreDomainErrorCodes
    {
        /* You can add your business exception error codes here, as constants */

        public const string ParentPostNotExists = "BlogStore.Posts:00001";
        public const string PostAlreadyPublished = "BlogStore.Posts:00002";
        public const string PostTagMustHaveOne = "BlogStore.Posts:00003";
        public const string PostCategoryMustHaveOne = "BlogStore.Posts:00004";

        public const string PostDetailMustHaveContent = "BlogStore.Posts:00005";
        public const string PostDetailMustHaveTitle = "BlogStore.Posts:00006";

        public const string CategoryMustHaveTitle = "BlogStore.Category:00007";
        public const string CategoryAlreadyExistsSameTitle = "BlogStore.Category:00008";
        public const string CategoryNotExistsParent = "BlogStore.Category:00009";
        public const string CategorySlugRequired = "BlogStore.Category:000010";

        public const string TagSlugRequired = "BlogStore.Tag:000011";
        public const string TagTitleRequired = "BlogStore.Tag:000012";
        public const string TagAlreadyExistsSameTitle = "BlogStore.Tag:000013";

    }
}
