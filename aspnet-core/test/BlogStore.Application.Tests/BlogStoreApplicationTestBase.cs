using System.Text;

namespace BlogStore
{
    public abstract class BlogStoreApplicationTestBase : BlogStoreTestBase<BlogStoreApplicationTestModule> 
    {
        public BlogStoreApplicationTestBase()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }
}
