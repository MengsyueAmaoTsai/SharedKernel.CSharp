using FluentAssertions;

using RichillCapital.SharedKernel.Diagnostic;

namespace RichillCapital.SharedKernel.UnitTests.Diagnostics;

public sealed partial class EnsureTests
{
    [Fact]
    public void NotEmpty_Should_ThrowArgumentException_WhenValueIsDefaultDateTime()
    {
        // Arrange
        var value = default(DateTime);
        var message = "error";

        // Act
        Action action = () => Ensure.NotEmpty(value, message);

        // Assert
        action
            .Should().Throw<ArgumentException>()
            .WithMessage($"error (Parameter '{nameof(value)}')");
    }

    [Fact]
    public void NotEmpty_Should_NotThrowArgumentException_WhenValueIsNotEmptyDateTime()
    {
        // Arrange
        var value = DateTime.Now;
        var message = "error";

        // Act
        Action action = () => Ensure.NotEmpty(value, message);

        // Assert
        action.Should().NotThrow<ArgumentException>();
    }
}