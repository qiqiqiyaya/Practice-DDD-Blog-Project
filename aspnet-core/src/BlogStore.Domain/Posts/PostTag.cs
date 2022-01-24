using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace BlogStore.Posts
{
    public class PostTag : ValueObject
    {
        public Guid PostId { get; set; }

        public Guid TagId { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return TagId;
        }

        public PostTag(Guid tagId,Guid postId)
        {
            Check.NotNull(tagId,nameof(tagId));
            Check.NotNull(postId,nameof(postId));
            TagId = tagId;
            PostId = postId;
        }

    }
}
