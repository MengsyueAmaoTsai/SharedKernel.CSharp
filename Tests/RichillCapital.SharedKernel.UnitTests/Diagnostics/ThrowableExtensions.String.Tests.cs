using FluentAssertions;

using RichillCapital.SharedKernel.Diagnostics;

namespace RichillCapital.SharedKernel.UnitTests.Diagnostics;

public sealed partial class ThrowableExtensionsTests
{
    [Fact]
    public void Throw_IfWhiteSpace_When_WhiteSpace_Should_ThrowArgumentException()
    {
        // Arrange
        string value = " ";
        Action action = () => value.Throw().IfWhiteSpace();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be white space only. (Parameter '{nameof(value)}')");
    }

    [Fact]
    public void Throw_IfWhiteSpace_When_NotWhiteSpace_Should_NotThrow()
    {
        // Arrange
        string value = "a";

        // Act
        Action action = () => value.Throw().IfWhiteSpace();

        // Assert
        action.Should().NotThrow();
    }

    [Fact]
    public void Throw_IfEmpty_When_Empty_Should_ThrowArgumentException()
    {
        // Arrange
        string value = string.Empty;
        Action action = () => value.Throw().IfEmpty();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be empty. (Parameter '{nameof(value)}')");
    }

    [Fact]
    public void Throw_IfEmpty_When_NotEmpty_Should_NotThrow()
    {
        // Arrange
        string value = "a";

        // Act
        Action action = () => value.Throw().IfEmpty();

        // Assert
        action.Should().NotThrow();
    }
}