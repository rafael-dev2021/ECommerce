using Application.Dtos.ObjectsValues.ProductObjectValue;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.ObjectsValues.ProductObjectValue;

public class DataDtoObjectValueTests
{
    [Fact]
    public void DataDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        var releaseMonth = "January";
        var releaseYear = 2023;

        // Act
        var dataDtoObjectValue = new DataDtoObjectValue(releaseMonth, releaseYear);

        // Assert
        Assert.Equal(releaseMonth, dataDtoObjectValue.ReleaseMonth);
        Assert.Equal(releaseYear, dataDtoObjectValue.ReleaseYear);
    }
}
