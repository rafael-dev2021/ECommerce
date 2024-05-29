using Application.Dtos.Products.Technology.Smartphones.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Products.Technology.Smartphones.ObjectValues;

public class PlatformDtoObjectValueTests
{
    [Fact]
    public void PlatformDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string operatingSystem = "Android 11";
        string chipset = "Snapdragon 888";
        string gpu = "Adreno 660";
        string cpu = "Octa-core";

        // Act
        var platformDtoObjectValue = new PlatformDtoObjectValue(operatingSystem, chipset, gpu, cpu);

        // Assert
        Assert.Equal(operatingSystem, platformDtoObjectValue.OperatingSystem);
        Assert.Equal(chipset, platformDtoObjectValue.Chipset);
        Assert.Equal(gpu, platformDtoObjectValue.Gpu);
        Assert.Equal(cpu, platformDtoObjectValue.Cpu);
    }
}
