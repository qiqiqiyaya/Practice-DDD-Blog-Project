using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace BlogStore.Posts
{
    /// <summary>
    /// 文章分类，值对象
    /// </summary>
    public class PostCategory : ValueObject
    {
        public Guid CategoryId { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CategoryId;
        }

        public PostCategory(Guid categoryId)
        {
            Check.NotNull(categoryId, nameof(categoryId));
            CategoryId = categoryId;
        }
    }
}
