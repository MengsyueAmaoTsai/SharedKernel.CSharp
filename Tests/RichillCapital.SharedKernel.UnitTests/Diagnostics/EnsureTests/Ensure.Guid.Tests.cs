using FluentAssertions;

using RichillCapital.SharedKernel.Diagnostic;

namespace RichillCapital.SharedKernel.UnitTests.Diagnostics;

public sealed partial class EnsureTests
{
    [Fact]
    public void NotEmpty_Should_ThrowArgumentException_WhenValueIsEmptyGuid()
    {
        // Arrange
        var value = Guid.Empty;
        var message = "error";

        // Act
        Action action = () => Ensure.NotEmpty(value, message);

        // Assert
        action
            .Should().Throw<ArgumentException>()
            .WithMessage($"error (Parameter '{nameof(value)}')");
    }

    [Fact]
    public void NotEmpty_Should_NotThrowArgumentException_WhenValueIsNotEmptyGuid()
    {
        // Arrange
        var value = Guid.NewGuid();
        var message = "error";

        // Act
        Action action = () => Ensure.NotEmpty(value, message);

        // Assert
        action.Should().NotThrow<ArgumentException>();
    }
}