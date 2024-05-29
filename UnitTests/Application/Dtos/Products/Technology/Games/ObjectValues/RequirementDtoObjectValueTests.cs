using Application.Dtos.Products.Technology.Games.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Products.Technology.Games.ObjectValues;

public class RequirementDtoObjectValueTests
{
    [Fact]
    public void RequirementDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        int minimumRamRequirementInMb = 4096;
        string minimumOperatingSystemsRequired = "Windows 10";
        string minimumGraphicsProcessorsRequired = "NVIDIA GTX 1660 Ti";
        string minimumProcessorsRequired = "Intel Core i5-8400";

        // Act
        var requirementDtoObjectValue = new RequirementDtoObjectValue(minimumRamRequirementInMb, minimumOperatingSystemsRequired, minimumGraphicsProcessorsRequired, minimumProcessorsRequired);

        // Assert
        Assert.Equal(minimumRamRequirementInMb, requirementDtoObjectValue.MinimumRamRequirementInMb);
        Assert.Equal(minimumOperatingSystemsRequired, requirementDtoObjectValue.MinimumOperatingSystemsRequired);
        Assert.Equal(minimumGraphicsProcessorsRequired, requirementDtoObjectValue.MinimumGraphicsProcessorsRequired);
        Assert.Equal(minimumProcessorsRequired, requirementDtoObjectValue.MinimumProcessorsRequired);
    }
}
