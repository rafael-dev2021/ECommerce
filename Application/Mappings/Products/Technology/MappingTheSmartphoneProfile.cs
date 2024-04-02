using Application.Dtos.Products.Technology.Smartphones;
using Application.Dtos.Products.Technology.Smartphones.ObjectValues;
using AutoMapper;
using Domain.Entities.Products.Technology.Smartphones;
using Domain.Entities.Products.Technology.Smartphones.ObjectValues;

namespace Application.Mappings.Products.Technology;

public class MappingTheSmartphoneProfile : Profile
{

    public MappingTheSmartphoneProfile()
    {
        CreateMap<Smartphone, SmartphoneDto>().ReverseMap();
        CreateMap<BatteryObjectValue, BatteryDtoObjectValue>().ReverseMap();
        CreateMap<CameraObjectValue, CameraDtoObjectValue>().ReverseMap();
        CreateMap<DimensionObjectValue, DimensionDtoObjectValue>().ReverseMap();
        CreateMap<DisplayObjectValue, DisplayDtoObjectValue>().ReverseMap();
        CreateMap<FeatureObjectValue, FeatureDtoObjectValue>().ReverseMap();
        CreateMap<PlatformObjectValue, PlatformDtoObjectValue>().ReverseMap();
        CreateMap<StorageObjectValue, StorageDtoObjectValue>().ReverseMap();
    }
}