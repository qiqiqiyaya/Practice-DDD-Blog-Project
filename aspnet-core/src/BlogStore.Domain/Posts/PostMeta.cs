using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace BlogStore.Posts
{
    public class PostMeta : Entity<long>
    {
        public string Key { get; private set; }

        public string Content { get; private set; }

        protected PostMeta()
        {

        }

        public static PostMeta Create([NotNull] string key, [NotNull] string content)
        {
            Check.NotNullOrWhiteSpace(key, nameof(key));
            Check.NotNullOrWhiteSpace(content, nameof(content));

            return new PostMeta()
            {
                Key = key,
                Content = content,
            };
        }
    }
}
