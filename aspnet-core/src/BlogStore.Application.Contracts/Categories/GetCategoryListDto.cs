using Volo.Abp.Application.Dtos;

namespace BlogStore.Categories
{
    public class GetCategoryListDto : PagedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
