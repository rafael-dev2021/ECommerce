using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Dtos.Products.Technology.Smartphones;
using Application.Dtos.Products.Technology.Smartphones.ObjectValues;
using Application.Mappings;
using Application.Mappings.Products.Technology;
using AutoMapper;
using Domain.Entities.Products.Technology.Smartphones;
using FluentAssertions;
using Xunit;

namespace UnitTests.Application.Mappings.Products.Technology;

public class MappingTheSmartphoneProfileTests
{
    private readonly IMapper _mapper;

    public MappingTheSmartphoneProfileTests()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingTheSmartphoneProfile>();
            cfg.AddProfile<MappingTheProductProfile>();
        });
        _mapper = configuration.CreateMapper();
    }

    [Fact]
    public void Should_Map_SmartphoneDto_To_Smartphone()
    {
        // Arrange
        var smartphoneDto = new SmartphoneDto
        {
            Id = 1,
            Name = "Test Smartphone",
            Description = "A test smartphone description",
            ImagesUrl = new List<string> { "image1.jpg", "image2.jpg" },
            Stock = 10,
            CategoryId = 1,
            DataObjectValue = new DataDtoObjectValue("January", 2023),
            FlagsObjectValue = new FlagsDtoObjectValue(true, true, true),
            PriceObjectValue = new PriceDtoObjectValue(19.99m, 19.99m),
            SpecificationObjectValue = new SpecificationDtoObjectValue("Model1", "Brand1", "Line1", "1kg", "Type1"),
            WarrantyObjectValue = new WarrantyDtoObjectValue("1 year", "2 years"),
            CommonPropertiesObjectValue = new CommonPropertiesDtoObjectValue("Unisex", "Blue", "Adult", "No", "L"),
            BatteryObjectValue = new BatteryDtoObjectValue("Lithium-ion", 4000, true),
            CameraObjectValue = new CameraDtoObjectValue("12 MP", "Autofocus", "8 MP", "Portrait mode"),
            DimensionObjectValue = new DimensionDtoObjectValue(5.5, 2.5, 0.3),
            DisplayObjectValue = new DisplayDtoObjectValue("OLED", "1080x1920", "Gorilla Glass", 6.0),
            FeatureObjectValue = new FeatureDtoObjectValue("4G LTE", "Siri", "MPN12345"),
            PlatformObjectValue = new PlatformDtoObjectValue("iOS", "Apple A14", "Apple GPU", "Hexa-core"),
            StorageObjectValue = new StorageDtoObjectValue(128, 6)
        };

        // Act
        var smartphone = _mapper.Map<Smartphone>(smartphoneDto);

        // Assert
        smartphone.Id.Should().Be(smartphoneDto.Id);
        smartphone.Name.Should().Be(smartphoneDto.Name);
        smartphone.Description.Should().Be(smartphoneDto.Description);
        smartphone.ImagesUrl.Should().BeEquivalentTo(smartphoneDto.ImagesUrl);
        smartphone.Stock.Should().Be(smartphoneDto.Stock);
        smartphone.CategoryId.Should().Be(smartphoneDto.CategoryId);

        // Assert BatteryObjectValue
        smartphone.BatteryObjectValue.Should().NotBeNull();
        smartphone.BatteryObjectValue?.BatteryType.Should().Be(smartphoneDto.BatteryObjectValue.BatteryType);
        smartphone.BatteryObjectValue?.BatteryCapacityMAh.Should().Be(smartphoneDto.BatteryObjectValue.BatteryCapacityMAh);
        smartphone.BatteryObjectValue?.IsBatteryRemovable.Should().Be(smartphoneDto.BatteryObjectValue.IsBatteryRemovable);

        // Assert CameraObjectValue
        smartphone.CameraObjectValue.Should().NotBeNull();
        smartphone.CameraObjectValue?.MainCameraSpec.Should().Be(smartphoneDto.CameraObjectValue.MainCameraSpec);
        smartphone.CameraObjectValue?.MainCameraFeature.Should().Be(smartphoneDto.CameraObjectValue.MainCameraFeature);
        smartphone.CameraObjectValue?.SelfieCameraSpec.Should().Be(smartphoneDto.CameraObjectValue.SelfieCameraSpec);
        smartphone.CameraObjectValue?.SelfieCameraFeature.Should().Be(smartphoneDto.CameraObjectValue.SelfieCameraFeature);

        // Assert DimensionObjectValue
        smartphone.DimensionObjectValue.Should().NotBeNull();
        smartphone.DimensionObjectValue?.HeightInches.Should().Be(smartphoneDto.DimensionObjectValue.HeightInches);
        smartphone.DimensionObjectValue?.WidthInches.Should().Be(smartphoneDto.DimensionObjectValue.WidthInches);
        smartphone.DimensionObjectValue?.ThicknessInches.Should().Be(smartphoneDto.DimensionObjectValue.ThicknessInches);

        // Assert DisplayObjectValue
        smartphone.DisplayObjectValue.Should().NotBeNull();
        smartphone.DisplayObjectValue?.DisplayType.Should().Be(smartphoneDto.DisplayObjectValue.DisplayType);
        smartphone.DisplayObjectValue?.DisplayResolution.Should().Be(smartphoneDto.DisplayObjectValue.DisplayResolution);
        smartphone.DisplayObjectValue?.DisplayProtection.Should().Be(smartphoneDto.DisplayObjectValue.DisplayProtection);
        smartphone.DisplayObjectValue?.DisplaySizeInches.Should().Be(smartphoneDto.DisplayObjectValue.DisplaySizeInches);

        // Assert FeatureObjectValue
        smartphone.FeatureObjectValue.Should().NotBeNull();
        smartphone.FeatureObjectValue?.CellNetworkTechnology.Should().Be(smartphoneDto.FeatureObjectValue.CellNetworkTechnology);
        smartphone.FeatureObjectValue?.VirtualAssistant.Should().Be(smartphoneDto.FeatureObjectValue.VirtualAssistant);
        smartphone.FeatureObjectValue?.ManufacturerPartNumber.Should().Be(smartphoneDto.FeatureObjectValue.ManufacturerPartNumber);

        // Assert PlatformObjectValue
        smartphone.PlatformObjectValue.Should().NotBeNull();
        smartphone.PlatformObjectValue?.OperatingSystem.Should().Be(smartphoneDto.PlatformObjectValue.OperatingSystem);
        smartphone.PlatformObjectValue?.Chipset.Should().Be(smartphoneDto.PlatformObjectValue.Chipset);
        smartphone.PlatformObjectValue?.Gpu.Should().Be(smartphoneDto.PlatformObjectValue.Gpu);
        smartphone.PlatformObjectValue?.Cpu.Should().Be(smartphoneDto.PlatformObjectValue.Cpu);

        // Assert StorageObjectValue
        smartphone.StorageObjectValue.Should().NotBeNull();
        smartphone.StorageObjectValue?.StorageGb.Should().Be(smartphoneDto.StorageObjectValue.StorageGb);
        smartphone.StorageObjectValue?.RamGb.Should().Be(smartphoneDto.StorageObjectValue.RamGb);
    }
}
