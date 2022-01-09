using BlogStore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BlogStore.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BlogStoreController : AbpControllerBase
    {
        protected BlogStoreController()
        {
            LocalizationResource = typeof(BlogStoreResource);
        }
    }
}