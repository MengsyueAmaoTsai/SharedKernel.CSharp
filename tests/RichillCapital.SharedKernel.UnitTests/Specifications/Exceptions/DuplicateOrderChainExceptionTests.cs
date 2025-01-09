using FluentAssertions;

using RichillCapital.SharedKernel.Specifications.Exceptions;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Exceptions;

public sealed class DuplicateOrderChainExceptionTests
{
    private const string DefaultMessage = "The specification contains more than one Order chain!";

    [Fact]
    public void DefaultConstructor_Should_ThrowsDuplicateOrderChainException()
    {
        // Arrange
        Action action = () => throw new DuplicateOrderChainException();

        // Act & Assert
        action.Should().Throw<DuplicateOrderChainException>()
            .WithMessage(DefaultMessage);
    }

    [Fact]
    public void Should_ThrowsWithInnerException()
    {
        // Arrange
        var innerException = new Exception("Test");
        Action action = () => throw new DuplicateOrderChainException(innerException);

        // Act & Assert 
        action.Should().Throw<DuplicateOrderChainException>()
            .WithMessage(DefaultMessage)
            .WithInnerException<Exception>()
            .WithMessage("Test");
    }
}