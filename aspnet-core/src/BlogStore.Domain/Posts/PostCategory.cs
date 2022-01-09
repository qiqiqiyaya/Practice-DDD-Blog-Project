using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;
using Volo.Abp.Validation;

namespace BlogStore.Posts
{
    /// <summary>
    /// 文章分类，值对象
    /// </summary>
    public class PostCategory : ValueObject
    {
        public long CategoryId { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CategoryId;
        }

        protected PostCategory()
        {

        }

        public static PostCategory Create(long categoryId)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentException("the id of category can not less than or equal zero.");
            }

            return new PostCategory()
            {
                CategoryId = categoryId
            };
        }
    }
}
