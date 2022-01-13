using System;
using System.Threading.Tasks;
using BlogStore.Categories;
using Volo.Abp.Account;
using Volo.Abp.DependencyInjection;

namespace BlogStore.HttpApi.Client.ConsoleTestApp
{
    public class ClientDemoService : ITransientDependency
    {
        private readonly IProfileAppService _profileAppService;
        private readonly ICategoryAppService _categoryAppService;

        public ClientDemoService(IProfileAppService profileAppService,
            ICategoryAppService categoryAppService)
        {
            _profileAppService = profileAppService;
            _categoryAppService = categoryAppService;
        }

        public async Task RunAsync()
        {
            var output = await _profileAppService.GetAsync();
            Console.WriteLine($"UserName : {output.UserName}");
            Console.WriteLine($"Email    : {output.Email}");
            Console.WriteLine($"Name     : {output.Name}");
            Console.WriteLine($"Surname  : {output.Surname}");
        }

        
        public async Task CreateAsync()
        {
            var category = new CreateCategoryDto();
            category.Title = DateTime.UtcNow.ToString();
            category.Content = null;
            category.MetaTitle = null;
            category.Slug = null;
            
            var result = await _categoryAppService.CreateAsync(category);
        }
    }
}