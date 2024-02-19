using FluentAssertions;

using RichillCapital.SharedKernel.Diagnostic;

namespace RichillCapital.SharedKernel.UnitTests.Diagnostics;

public sealed class EnsureTests
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