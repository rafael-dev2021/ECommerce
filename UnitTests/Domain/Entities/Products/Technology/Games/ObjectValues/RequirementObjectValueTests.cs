using Domain.Entities.Products.Technology.Games.ObjectValues;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Products.Technology.Games.ObjectValues;
using Xunit;

namespace UnitTests.Domain.Entities.Products.Technology.Games.ObjectValues;

[TestFixture]
public class RequirementObjectValueTests
{ 
    private readonly RequirementObjectValueValidator _validator = new();

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_MinimumRamRequirementInMb_Is_Valid()
    {
        // Arrange
        var requirementObjectValue = new RequirementObjectValue();
        requirementObjectValue.SetMinimumRamRequirementInMb(4);
        // Act
        var result = _validator.TestValidate(requirementObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.MinimumRamRequirementInMb);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_MinimumRamRequirementInMb_Is_Empty()
    {
        // Arrange
        var requirementObjectValue = new RequirementObjectValue();
        requirementObjectValue.SetMinimumRamRequirementInMb(0);
        // Act
        var result = _validator.TestValidate(requirementObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MinimumRamRequirementInMb)
            .WithErrorMessage("Minimum RAM requirement cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_MinimumRamRequirementInMb_Is_Less_Than_4()
    {
        // Arrange
        var requirementObjectValue = new RequirementObjectValue();
        requirementObjectValue.SetMinimumRamRequirementInMb(3); // Menos que 4 GB
        // Act
        var result = _validator.TestValidate(requirementObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MinimumRamRequirementInMb)
            .WithErrorMessage("Minimum RAM requirement must be greater than or equal to 4 GB (4096 MB).");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_MinimumRamRequirementInMb_Is_Greater_Than_16()
    {
        // Arrange
        var requirementObjectValue = new RequirementObjectValue();
        requirementObjectValue.SetMinimumRamRequirementInMb(20); 
        // Act
        var result = _validator.TestValidate(requirementObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MinimumRamRequirementInMb)
            .WithErrorMessage("Minimum RAM requirement must be less than or equal to 16 GB (16384 MB).");
    }
    
    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_MinimumOperatingSystemsRequired_Is_Valid()
    {
        // Arrange
        var requirementObjectValue = new RequirementObjectValue();
        requirementObjectValue.SetMinimumOperatingSystemsRequired("Windows 10");
        // Act
        var result = _validator.TestValidate(requirementObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.MinimumOperatingSystemsRequired);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_MinimumOperatingSystemsRequired_Is_Empty()
    {
        // Arrange
        var requirementObjectValue = new RequirementObjectValue();
        requirementObjectValue.SetMinimumOperatingSystemsRequired("");
        // Act
        var result = _validator.TestValidate(requirementObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MinimumOperatingSystemsRequired)
            .WithErrorMessage("Minimum operating systems required cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_MinimumOperatingSystemsRequired_Exceeds_Maximum_Length()
    {
        // Arrange
        var requirementObjectValue = new RequirementObjectValue();
        requirementObjectValue.SetMinimumOperatingSystemsRequired("Windows  11");
        // Act
        var result = _validator.TestValidate(requirementObjectValue);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MinimumOperatingSystemsRequired)
            .WithErrorMessage("Minimum operating systems required must have a maximum length of 10 characters.");
    }
    
    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_MinimumGraphicsProcessorsRequired_Is_Valid()
    {
        // Arrange
        var requirementObjectValue = new RequirementObjectValue();
        requirementObjectValue.SetMinimumGraphicsProcessorsRequired("GPU 1");
        // Act
        var result = _validator.TestValidate(requirementObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.MinimumGraphicsProcessorsRequired);
    }
    
    [Fact]
    [Test]
    public void Should_Have_Error_When_MinimumGraphicsProcessorsRequired_Is_Empty()
    {
        // Arrange
        var requirementObjectValue = new RequirementObjectValue();
        requirementObjectValue.SetMinimumGraphicsProcessorsRequired("");
        // Act
        var result = _validator.TestValidate(requirementObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MinimumGraphicsProcessorsRequired)
            .WithErrorMessage("Minimum graphics processors required cannot be empty.");
    }
    
    [Fact]
    [Test]
    public void Should_Have_Error_When_MinimumGraphicsProcessorsRequired_Exceeds_Maximum_Length()
    {
        // Arrange
        var requirementObjectValue = new RequirementObjectValue();
        requirementObjectValue.SetMinimumGraphicsProcessorsRequired("GraphicsProcessor 1");
        // Act
        var result = _validator.TestValidate(requirementObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MinimumGraphicsProcessorsRequired)
            .WithErrorMessage("Minimum graphics processors required must have a maximum length of 10 characters.");
    }
    
    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_MinimumProcessorsRequired_Is_Valid()
    {
        // Arrange
        var requirementObjectValue = new RequirementObjectValue();
        requirementObjectValue.SetMinimumProcessorsRequired("Pro 1");
        // Act
        var result = _validator.TestValidate(requirementObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.MinimumProcessorsRequired);
    }
 
    [Fact]
    [Test]
    public void Should_Have_Error_When_MinimumProcessorsRequired_Is_Empty()
    {
        // Arrange
        var requirementObjectValue = new RequirementObjectValue();
        requirementObjectValue.SetMinimumProcessorsRequired("");
        // Act
        var result = _validator.TestValidate(requirementObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MinimumProcessorsRequired)
            .WithErrorMessage("Minimum processors required cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_MinimumProcessorsRequired_Exceeds_Maximum_Length()
    {
        // Arrange
        var requirementObjectValue = new RequirementObjectValue();
        requirementObjectValue.SetMinimumProcessorsRequired("Processors 1");
        // Act
        var result = _validator.TestValidate(requirementObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MinimumProcessorsRequired)
            .WithErrorMessage("Minimum processors required must have a maximum length of 10 characters.");
    }
}