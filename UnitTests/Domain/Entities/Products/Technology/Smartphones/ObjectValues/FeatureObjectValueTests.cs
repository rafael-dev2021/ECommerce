using Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using Xunit;

namespace UnitTests.Domain.Entities.Products.Technology.Smartphones.ObjectValues;

[TestFixture]
public class FeatureObjectValueTests
{ 
    private readonly FeatureObjectValueValidator _validator = new();
    
    [Fact]
    [Test]
    public void CellNetworkTechnology_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var featureObjectValue = new FeatureObjectValue();
        featureObjectValue.SetCellNetworkTechnology("");
        // Act
        var result = _validator.TestValidate(featureObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CellNetworkTechnology)
            .WithErrorMessage("Cell network technology cannot be empty.");
    }
    
    [Fact]
    [Test]
    public void CellNetworkTechnology_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var featureObjectValue = new FeatureObjectValue();
        featureObjectValue.SetCellNetworkTechnology(" ".PadRight(31, 'a'));
        // Act
        var result = _validator.TestValidate(featureObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CellNetworkTechnology)
            .WithErrorMessage("Cell network technology must have a maximum length of 30 characters.");
    }
}