using Application.Dtos.Products.Technology.Smartphones.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Products.Technology.Smartphones.ObjectValues;

public class BatteryDtoObjectValueTests
{
    [Fact]
    public void BatteryDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string batteryType = "Li-Po";
        int batteryCapacityMAh = 5000;
        bool isBatteryRemovable = false;

        // Act
        var batteryDtoObjectValue = new BatteryDtoObjectValue(batteryType, batteryCapacityMAh, isBatteryRemovable);

        // Assert
        Assert.Equal(batteryType, batteryDtoObjectValue.BatteryType);
        Assert.Equal(batteryCapacityMAh, batteryDtoObjectValue.BatteryCapacityMAh);
        Assert.Equal(isBatteryRemovable, batteryDtoObjectValue.IsBatteryRemovable);
    }
}
