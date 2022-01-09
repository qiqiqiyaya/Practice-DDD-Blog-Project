using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace BlogStore.Posts
{
    public class PostComment : ValueObject
    {
        public long PostId { get; set; }

        public ICollection<long> Comments { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
