using FluentAssertions;

using RichillCapital.SharedKernel.Specifications.Exceptions;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Exceptions;

public sealed class ConcurrentSelectorsExceptionTests
{
    private const string DefaultMessage = "Concurrent specification selector transforms defined." +
        "Ensure only one of the Select() or SelectMany() transforms is used in the same specification!";

    [Fact]
    public void DefaultConstructor_Should_ThrowsConcurrentSelectorsException()
    {
        // Arrange
        Action action = () => throw new ConcurrentSelectorsException();

        // Act & Assert
        action.Should()
            .Throw<ConcurrentSelectorsException>()
            .WithMessage(DefaultMessage);
    }

    [Fact]
    public void Should_ThrowsWithInnerException()
    {
        // Arrange
        var errorMessage = "Test";
        var innerException = new Exception(errorMessage);
        Action action = () => throw new ConcurrentSelectorsException(innerException);

        // Act & Assert 
        action.Should()
            .Throw<ConcurrentSelectorsException>().WithMessage(DefaultMessage)
            .WithInnerException<Exception>().WithMessage(errorMessage);
    }
}