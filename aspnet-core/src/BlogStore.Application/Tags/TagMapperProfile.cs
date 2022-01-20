using AutoMapper;

namespace BlogStore.Tags
{
    public class TagMapperProfile: Profile
    {
        public TagMapperProfile()
        {
            CreateMap<Tag, TagDto>();
        }
    }
}
