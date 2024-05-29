using Application.CustomExceptions;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.CustomExceptions;

public class CategoryExceptionTests
{
    [Fact]
    public void CategoryException_WhenInitializedWithMessage_ShouldContainMessage()
    {
        // Arrange
        string expectedMessage = "Test exception message";

        // Act
        var exception = new CategoryException(expectedMessage, new Exception());

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void CategoryException_WhenInitializedWithMessageAndInnerException_ShouldContainMessageAndInnerException()
    {
        // Arrange
        string expectedMessage = "Test exception message";
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new CategoryException(expectedMessage, innerException);

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
        Assert.Equal(innerException, exception.InnerException);
    }
}
