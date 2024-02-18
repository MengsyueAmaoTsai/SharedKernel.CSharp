using FluentAssertions;

using RichillCapital.SharedKernel.Specifications.Exceptions;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Exceptions;

public class SelectorNotFoundExceptionTests
{
    private const string DefaultMessage = "The specification must have a selector transform defined." +
        "Ensure either Select() or SelectMany() is used in the specification!";

    [Fact]
    public void Constructor_Should_ThrowSelectorNotFoundException()
    {
        // Arrange
        Action action = () => throw new SelectorNotFoundException();

        // Act & Assert
        action.Should()
            .Throw<SelectorNotFoundException>()
            .WithMessage(DefaultMessage);
    }

    [Fact]
    public void Should_ThrowSelectorNotFoundExceptionWithInnerException()
    {
        // Arrange
        var errorMessage = "test";
        var inner = new Exception(errorMessage);
        Action action = () => throw new SelectorNotFoundException(inner);

        // Act & Assert
        action.Should()
            .Throw<SelectorNotFoundException>().WithMessage(DefaultMessage)
            .WithInnerException<Exception>().WithMessage(errorMessage);
    }
}