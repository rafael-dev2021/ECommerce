using Application.CustomExceptions;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.CustomExceptions;

public class OrderExceptionTests
{
    [Fact]
    public void OrderException_WhenInitializedWithMessage_ShouldContainMessage()
    {
        // Arrange
        const string expectedMessage = "Test exception message";

        // Act
        var exception = new OrderException(expectedMessage);

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void OrderException_WhenInitializedWithMessageAndInnerException_ShouldContainMessageAndInnerException()
    {
        // Arrange
        const string expectedMessage = "Test exception message";
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new OrderException(expectedMessage, innerException);

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
        Assert.Equal(innerException, exception.InnerException);
    }
}
