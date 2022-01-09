using BlogStore.MongoDB;
using Xunit;

namespace BlogStore
{
    [CollectionDefinition(BlogStoreTestConsts.CollectionDefinitionName)]
    public class BlogStoreApplicationCollection : BlogStoreMongoDbCollectionFixtureBase
    {

    }
}
