using Application.CustomExceptions;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.CustomExceptions;

public class ReviewExceptionTests
{
    [Fact]
    public void ReviewException_WhenInitializedWithMessage_ShouldContainMessage()
    {
        // Arrange
        string expectedMessage = "Test exception message";

        // Act
        var exception = new ReviewException(expectedMessage);

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void ReviewException_WhenInitializedWithMessageAndInnerException_ShouldContainMessageAndInnerException()
    {
        // Arrange
        string expectedMessage = "Test exception message";
        var innerException = new Exception("Inner exception message");

        // Act
        var exception = new ReviewException(expectedMessage, innerException);

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
        Assert.Equal(innerException, exception.InnerException);
    }
}
