using AutoMapper;
using ProductService.Dto;
using ProductService.Models;

namespace ProductService;

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
