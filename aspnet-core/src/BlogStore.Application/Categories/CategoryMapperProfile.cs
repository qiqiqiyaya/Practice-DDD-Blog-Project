using AutoMapper;

namespace BlogStore.Categories
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
