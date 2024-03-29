using Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using Xunit;

namespace UnitTests.Domain.Entities.Products.Technology.Smartphones.ObjectValues;

[TestFixture]
public class PlatformObjectValueTests
{
    private readonly PlatformObjectValueValidator _validator = new();

    [Fact]
    [Test]
    public void OperatingSystem_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var platform = new PlatformObjectValue();
        platform.SetOperatingSystem("");
        // Act
        var result = _validator.TestValidate(platform);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.OperatingSystem)
            .WithErrorMessage("Operating system cannot be empty.");
    }

    [Fact]
    [Test]
    public void OperatingSystem_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var platform = new PlatformObjectValue();
        platform.SetOperatingSystem(" ".PadRight(16, 'a'));
        // Act
        var result = _validator.TestValidate(platform);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.OperatingSystem)
            .WithErrorMessage("Operating system must have a maximum length of 15 characters.");
    }

    [Fact]
    [Test]
    public void Chipset_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var platform = new PlatformObjectValue();
        platform.SetChipset("");
        // Act
        var result = _validator.TestValidate(platform);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Chipset)
            .WithErrorMessage("Chipset cannot be empty.");
    }

    [Fact]
    [Test]
    public void Chipset_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var platform = new PlatformObjectValue();
        platform.SetChipset(" ".PadRight(51, 'a'));
        // Act
        var result = _validator.TestValidate(platform);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Chipset)
            .WithErrorMessage("Chipset must have a maximum length of 50 characters.");
    }

    [Fact]
    [Test]
    public void Gpu_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var platform = new PlatformObjectValue();
        platform.SetGpu("");
        // Act
        var result = _validator.TestValidate(platform);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Gpu)
            .WithErrorMessage("GPU cannot be empty.");
    }

    [Fact]
    [Test]
    public void Gpu_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var platform = new PlatformObjectValue();
        platform.SetGpu(" ".PadRight(31, 'a'));
        // Act
        var result = _validator.TestValidate(platform);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Gpu)
            .WithErrorMessage("GPU must have a maximum length of 30 characters.");
    }

    [Fact]
    [Test]
    public void Cpu_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var platform = new PlatformObjectValue();
        platform.SetCpu("");
        // Act
        var result = _validator.TestValidate(platform);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Cpu)
            .WithErrorMessage("CPU cannot be empty.");
    }

    [Fact]
    [Test]
    public void Cpu_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var platform = new PlatformObjectValue();
        platform.SetCpu(" ".PadRight(31, 'a'));
        // Act
        var result = _validator.TestValidate(platform);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Cpu)
            .WithErrorMessage("CPU must have a maximum length of 30 characters.");
    }
}