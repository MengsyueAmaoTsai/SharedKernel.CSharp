using FluentAssertions;

using RichillCapital.SharedKernel.Diagnostic;

namespace RichillCapital.SharedKernel.UnitTests.Diagnostics;

public sealed partial class EnsureTests
{
    [Fact]
    public void NotEmpty_Should_ThrowArgumentException_WhenValueIsEmpty()
    {
        // Arrange
        var value = string.Empty;
        var message = "error";

        // Act
        Action action = () => Ensure.NotEmpty(value, message);

        // Assert
        action
            .Should().Throw<ArgumentException>()
            .WithMessage($"error (Parameter '{nameof(value)}')");
    }

    [Fact]
    public void NotEmpty_Should_NotThrowArgumentException_WhenValueIsNotEmpty()
    {
        // Arrange
        var value = "value";
        var message = "error";

        // Act
        Action action = () => Ensure.NotEmpty(value, message);

        // Assert
        action.Should().NotThrow<ArgumentException>();
    }
}