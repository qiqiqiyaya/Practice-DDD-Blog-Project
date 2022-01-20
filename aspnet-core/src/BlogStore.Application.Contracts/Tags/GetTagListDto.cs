using Volo.Abp.Application.Dtos;

namespace BlogStore.Tags
{
    public class GetTagListDto : PagedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
