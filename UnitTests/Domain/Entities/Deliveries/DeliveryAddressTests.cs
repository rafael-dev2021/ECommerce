using Domain.Entities.Deliveries;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Deliveries;
using Xunit;

namespace UnitTests.Domain.Entities.Deliveries;

[TestFixture]
public class DeliveryAddressTests
{
    private readonly DeliveryAddressValidator _validator = new();

    [Fact]
    [Test]
    public void Country_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var deliveryAddress = new DeliveryAddress();
        deliveryAddress.SetCountry("");
        // Act
        var result = _validator.TestValidate(deliveryAddress);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Country)
            .WithErrorMessage("Country cannot be empty.");
    }

    [Fact]
    [Test]
    public void Country_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var deliveryAddress = new DeliveryAddress();
        deliveryAddress.SetCountry(" ".PadRight(31, 'a'));
        // Act
        var result = _validator.TestValidate(deliveryAddress);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Country)
            .WithErrorMessage("Country must have a maximum length of 30 characters.");
    }

    [Fact]
    [Test]
    public void Address_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var deliveryAddress = new DeliveryAddress();
        deliveryAddress.SetAddress("");
        // Act
        var result = _validator.TestValidate(deliveryAddress);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Address)
            .WithErrorMessage("Address cannot be empty.");
    }

    [Fact]
    [Test]
    public void Address_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var deliveryAddress = new DeliveryAddress();
        deliveryAddress.SetAddress(" ".PadRight(61, 'a'));
        // Act
        var result = _validator.TestValidate(deliveryAddress);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Address)
            .WithErrorMessage("Address must have a maximum length of 60 characters.");
    }

    [Fact]
    [Test]
    public void Complement_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var deliveryAddress = new DeliveryAddress();
        deliveryAddress.SetComplement(" ".PadRight(61, 'a'));
        // Act
        var result = _validator.TestValidate(deliveryAddress);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Complement)
            .WithErrorMessage("Complement must have a maximum length of 60 characters.");
    }

    [Fact]
    [Test]
    public void ZipCode_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var deliveryAddress = new DeliveryAddress();
        deliveryAddress.SetZipCode("");
        // Act
        var result = _validator.TestValidate(deliveryAddress);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ZipCode)
            .WithErrorMessage("Zip code cannot be empty.");
    }
    
    [Fact]
    [Test]
    public void ZipCode_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var deliveryAddress = new DeliveryAddress();
        deliveryAddress.SetZipCode(" ".PadRight(12, 'a'));
        // Act
        var result = _validator.TestValidate(deliveryAddress);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ZipCode)
            .WithErrorMessage("Zip code must have a maximum length of 11 characters.");
    }
    
    [Fact]
    [Test]
    public void State_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var deliveryAddress = new DeliveryAddress();
            deliveryAddress.SetState("");
        // Act
        var result = _validator.TestValidate(deliveryAddress);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.State)
            .WithErrorMessage("State cannot be empty.");
    }

    [Fact]
    [Test]
    public void State_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var deliveryAddress = new DeliveryAddress();
        deliveryAddress.SetState(" ".PadRight(31, 'a'));
        // Act
        var result = _validator.TestValidate(deliveryAddress);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.State)
            .WithErrorMessage("State must have a maximum length of 30 characters.");
    }
    
    [Fact]
    [Test]
    public void City_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var deliveryAddress = new DeliveryAddress();
        deliveryAddress.SetCity("");
        // Act
        var result = _validator.TestValidate(deliveryAddress);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.City)
            .WithErrorMessage("City cannot be empty.");
    }

    [Fact]
    [Test]
    public void City_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var deliveryAddress = new DeliveryAddress();
        deliveryAddress.SetCity(" ".PadRight(31, 'a'));
        // Act
        var result = _validator.TestValidate(deliveryAddress);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.City)
            .WithErrorMessage("City must have a maximum length of 30 characters.");
    }
    
    [Fact]
    [Test]
    public void Neighborhood_WhenEmpty_ShouldHaveValidationError()
    { // Arrange
        var deliveryAddress = new DeliveryAddress();
        deliveryAddress.SetNeighborhood("");
        // Act
        var result = _validator.TestValidate(deliveryAddress);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Neighborhood)
            .WithErrorMessage("Neighborhood cannot be empty.");
    }
    
    [Fact]
    [Test]
    public void Neighborhood_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var deliveryAddress = new DeliveryAddress();
        deliveryAddress.SetNeighborhood(" ".PadRight(31, 'a'));
        // Act
        var result = _validator.TestValidate(deliveryAddress);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Neighborhood)
            .WithErrorMessage("Neighborhood must have a maximum length of 30 characters.");
    }
}