using BlogStore.Categories;
using BlogStore.Comments;
using BlogStore.Posts;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace BlogStore.MongoDB
{
    [ConnectionStringName("Default")]
    public class BlogStoreMongoDbContext : AbpMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        public IMongoCollection<Post> Posts => Collection<Post>();
        
        public IMongoCollection<Category> Categories => Collection<Category>();

        public IMongoCollection<Tags.Tag> Tags => Collection<Tags.Tag>();

        public IMongoCollection<Comment> Comments => Collection<Comment>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);
            //modelBuilder.Entity<Post>(b =>
            //{
            //});
        }
    }
}
