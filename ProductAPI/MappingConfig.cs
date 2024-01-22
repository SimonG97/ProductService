using AutoMapper;
using ProductAPI.Dto;
using ProductAPI.Models;

namespace ProductAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductDto, Product>().ReverseMap();

        });
        return mappingConfig;
    }
}
