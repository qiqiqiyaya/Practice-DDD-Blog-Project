using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogStore.Posts;
using Xunit;

namespace BlogStore.Post
{
    public class PostServiceTest
    {
        private IPostAppService _postAppService;
        public PostServiceTest(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        [Fact]
        public async Task Create_Post_Test()
        {
            //_postService.CreateAsync();

        }
    }
}
