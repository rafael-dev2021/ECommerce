using Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using Xunit;

namespace UnitTests.Domain.Entities.Products.Technology.Smartphones.ObjectValues;

[TestFixture]
public class BatteryObjectValueTests
{
    private readonly BatteryObjectValueValidator _validator = new();

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_BatteryType_Is_Valid()
    {
        // Arrange
        var batteryObjectValue = new BatteryObjectValue();
        batteryObjectValue.SetBatteryType("Li-ion");
        // Act
        var result = _validator.TestValidate(batteryObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.BatteryType);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_BatteryType_Is_Empty()
    {
        // Arrange
        var batteryObjectValue = new BatteryObjectValue();
        batteryObjectValue.SetBatteryType("");
        // Act
        var result = _validator.TestValidate(batteryObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.BatteryType)
            .WithErrorMessage("Battery type cannot be empty.");
    }
    

    [Fact]
    [Test]
    public void Should_Have_Error_When_BatteryType_Exceeds_Maximum_Length()
    {
        // Arrange
        var batteryObjectValue = new BatteryObjectValue();
        batteryObjectValue.SetBatteryType("ThisIsALongBatteryTypeDescription");
        // Act
        var result = _validator.TestValidate(batteryObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.BatteryType)
            .WithErrorMessage("Battery type must have a maximum length of 20 characters.");
    }
    
    [Fact]
    [Test]
    public void Should_Have_Error_When_BatteryCapacityMAh_Is_Zero()
    {
        // Arrange
        var batteryObjectValue = new BatteryObjectValue();
        batteryObjectValue.SetBatteryCapacityMAh(0);
        // Act
        var result = _validator.TestValidate(batteryObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.BatteryCapacityMAh)
            .WithErrorMessage("Battery capacity must be greater than zero.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_IsBatteryRemovable_Is_False()
    {
        // Arrange
        var batteryObjectValue = new BatteryObjectValue();
        batteryObjectValue.SetIsBatteryRemovable(false);
        // Act
        var result = _validator.TestValidate(batteryObjectValue);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.IsBatteryRemovable)
            .WithErrorMessage("Is battery removable must be true or false.");
    }
}