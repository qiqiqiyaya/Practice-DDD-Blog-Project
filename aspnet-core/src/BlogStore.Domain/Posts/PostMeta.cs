using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace BlogStore.Posts
{
    /// <summary>
    /// The Post Meta can be used to store additional information of a post including the post banner URL etc.
    /// Below mentioned is the description of all the columns of the Post Meta Table.
    /// </summary>
    public class PostMeta : Entity<Guid>
    {
        public string Key { get; private set; }

        public string Content { get; private set; }

        public PostMeta(Guid id, [NotNull] string key, [NotNull] string content)
            : base(id)
        {
            Check.NotNull(id, nameof(id));
            Check.NotNullOrWhiteSpace(key, nameof(key));
            Check.NotNullOrWhiteSpace(content, nameof(content));

            Key = key;
            Content = content;
        }
    }
}
