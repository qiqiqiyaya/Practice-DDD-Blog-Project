using System;
using System.Collections.Generic;
using System.Text;
using BlogStore.Localization;
using Volo.Abp.Application.Services;

namespace BlogStore
{
    /* Inherit your application services from this class.
     */
    public abstract class BlogStoreAppService : ApplicationService
    {
        protected BlogStoreAppService()
        {
            LocalizationResource = typeof(BlogStoreResource);
        }
    }
}
