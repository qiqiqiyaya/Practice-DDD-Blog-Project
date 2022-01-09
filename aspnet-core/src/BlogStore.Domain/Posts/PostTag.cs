using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Values;
using Volo.Abp.Validation;

namespace BlogStore.Posts
{
    public class PostTag : ValueObject
    {
        public long TagId { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return TagId;
        }

        protected PostTag()
        {

        }

        public static PostTag Create(long tagId)
        {
            if (tagId<=0)
            {
                throw new ArgumentException("the id of tag can not less than or equal zero.");
            }

            return new PostTag()
            {
                TagId = tagId
            };
        }
    }
}
