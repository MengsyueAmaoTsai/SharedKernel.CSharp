using FluentAssertions;

using RichillCapital.SharedKernel.Specifications.Exceptions;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Exceptions;

public sealed class DuplicateSkipExceptionTests
{
    private const string DefaultMessage = "Duplicate skip detected. Only one skip is allowed per specification.";

    [Fact]
    public void DefaultConstructor_Should_ThrowsDuplicateSkipException()
    {
        // Arrange
        Action action = () => throw new DuplicateSkipException();

        // Act & Assert
        action.Should().Throw<DuplicateSkipException>()
            .WithMessage(DefaultMessage);
    }

    [Fact]
    public void Should_ThrowsWithInnerException()
    {
        // Arrange
        var innerException = new Exception("Test");
        Action action = () => throw new DuplicateSkipException(innerException);

        // Act & Assert 
        action.Should().Throw<DuplicateSkipException>()
            .WithMessage(DefaultMessage)
            .WithInnerException<Exception>()
            .WithMessage("Test");
    }
}