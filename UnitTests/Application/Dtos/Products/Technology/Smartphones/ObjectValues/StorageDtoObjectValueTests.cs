using Application.Dtos.Products.Technology.Smartphones.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Products.Technology.Smartphones.ObjectValues;

public class StorageDtoObjectValueTests
{
    [Fact]
    public void StorageDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        int storageGb = 256;
        int ramGb = 8;

        // Act
        var storageDtoObjectValue = new StorageDtoObjectValue(storageGb, ramGb);

        // Assert
        Assert.Equal(storageGb, storageDtoObjectValue.StorageGb);
        Assert.Equal(ramGb, storageDtoObjectValue.RamGb);
    }
}
