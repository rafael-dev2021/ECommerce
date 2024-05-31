using Application.CustomExceptions;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.CustomExceptions;

public class ShoppingCartItemExceptionTests
{
    [Fact]
    public void ShoppingCartItemException_WhenInitializedWithMessage_ShouldContainMessage()
    {
        // Arrange
        const string expectedMessage = "Test exception message";

        // Act
        var exception = new ShoppingCartItemException(expectedMessage);

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void ShoppingCartItemException_WhenInitializedWithMessageAndInnerException_ShouldContainMessageAndInnerException()
    {
        // Arrange
        const string expectedMessage = "Test exception message";
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new ShoppingCartItemException(expectedMessage, innerException);

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
        Assert.Equal(innerException, exception.InnerException);
    }
}
