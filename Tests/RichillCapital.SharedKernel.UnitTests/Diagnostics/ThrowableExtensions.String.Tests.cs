using FluentAssertions;

using RichillCapital.SharedKernel.Diagnostics;

namespace RichillCapital.SharedKernel.UnitTests.Diagnostics;

public sealed partial class ThrowableExtensionsTests
{
    [Fact]
    public void Throw_IfWhiteSpace_When_WhiteSpace_Should_Throw_ArgumentException()
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
}