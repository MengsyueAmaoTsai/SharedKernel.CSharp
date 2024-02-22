using FluentAssertions;

using RichillCapital.SharedKernel.Diagnostic;

namespace RichillCapital.SharedKernel.UnitTests.Diagnostics;

public sealed partial class EnsureTests
{
    [Fact]
    public void NotNull_Should_ThrowArgumentNullException_WhenValueIsNull()
    {
        // Arrange
        string? value = null;
        var message = "error";

        // Act
        Action action = () => Ensure.NotNull(value, message);

        // Assert
        action
            .Should().Throw<ArgumentNullException>()
            .WithMessage($"error (Parameter '{nameof(value)}')");
    }

    [Fact]
    public void NotNull_Should_NotThrowArgumentNullException_WhenValueIsNotNull()
    {
        // Arrange
        var value = "value";
        var message = "error";

        // Act
        Action action = () => Ensure.NotNull(value, message);

        // Assert
        action.Should().NotThrow<ArgumentNullException>();
    }
}