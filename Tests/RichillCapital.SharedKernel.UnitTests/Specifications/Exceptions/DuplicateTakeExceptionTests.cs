using FluentAssertions;

using RichillCapital.SharedKernel.Specifications.Exceptions;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Exceptions;

public sealed class DuplicateTakeExceptionTests
{
    private const string DefaultMessage =
        "Duplicate take clause detected. Only one take clause is allowed per specification.";

    [Fact]
    public void DefaultConstructor_Should_ThrowsDuplicateTakeException()
    {
        // Arrange
        Action action = () => throw new DuplicateTakeException();

        // Act & Assert
        action.Should().Throw<DuplicateTakeException>()
            .WithMessage(DefaultMessage);
    }

    [Fact]
    public void Should_ThrowsWithInnerException()
    {
        // Arrange
        var innerException = new Exception("Test");
        Action action = () => throw new DuplicateTakeException(innerException);

        // Act & Assert 
        action.Should().Throw<DuplicateTakeException>()
            .WithMessage(DefaultMessage)
            .WithInnerException<Exception>()
            .WithMessage("Test");
    }
}