using Application.Dtos.ObjectsValues.ProductObjectValue;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.ObjectsValues.ProductObjectValue;

public class SpecificationDtoObjectValueTests
{
    [Fact]
    public void SpecificationDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string model = "Model X";
        string brand = "Brand Y";
        string line = "Line Z";
        string weight = "10 kg";
        string type = "Type A";

        // Act
        var specificationDtoObjectValue = new SpecificationDtoObjectValue(model, brand, line, weight, type);

        // Assert
        Assert.Equal(model, specificationDtoObjectValue.Model);
        Assert.Equal(brand, specificationDtoObjectValue.Brand);
        Assert.Equal(line, specificationDtoObjectValue.Line);
        Assert.Equal(weight, specificationDtoObjectValue.Weight);
        Assert.Equal(type, specificationDtoObjectValue.Type);
    }
}
