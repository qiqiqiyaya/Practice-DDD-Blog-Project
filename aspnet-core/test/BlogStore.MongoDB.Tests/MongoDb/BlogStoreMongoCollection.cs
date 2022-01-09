using Xunit;

namespace BlogStore.MongoDB
{
    [CollectionDefinition(BlogStoreTestConsts.CollectionDefinitionName)]
    public class BlogStoreMongoCollection : BlogStoreMongoDbCollectionFixtureBase
    {

    }
}
