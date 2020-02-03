using AutoMapper;
using TreeStructure.DTO;
using TreeStructure.Models;

namespace TreeStructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Directory, DirectoryDto>();
            })
               .CreateMapper();
    }
}
