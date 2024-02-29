using FluentAssertions;

using RichillCapital.SharedKernel.Diagnostics;

namespace RichillCapital.SharedKernel.UnitTests.Diagnostics;

public sealed partial class ThrowerTests
{
    private const string ParamName = "paramName";
    private const string CustomMessage = "message";

    private static readonly string StringValue = "StringValue";

    [Fact]
    public void ThrowNull_When_Should_ThrowArgumentNullException()
    {
        // Arrange & Act
        var expectedMessage = $"Value cannot be null. (Parameter '{ParamName}')";
        Action action = () => Thrower.ThrowNull(ParamName);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage(expectedMessage);
    }

    [Fact]
    public void ThrowNull_When_GivenCustomMessage_Should_ThrowArgumentNullExceptionWithGeneralMessage()
    {
        // Arrange & Act
        var expectedMessage = $"{CustomMessage} (Parameter '{ParamName}')";
        Action action = () => Thrower.ThrowNull(ParamName, CustomMessage);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage(expectedMessage);
    }

    [Fact]
    public void ThrowOutOfRange_Should_ThrowOutOfRangeException()
    {
        // Arrange & Act
        var expectedMessage = $"Specified argument was out of the range of valid values. (Parameter '{ParamName}')\nActual value was {StringValue}.";

        Action action = () => Thrower.ThrowOutOfRange(ParamName, StringValue);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage(expectedMessage); ;
    }

    [Fact]
    public void ThrowOutOfRange_When_GivenCustomMessage_Should_ThrowOutOfRangeExceptionWithCustomMessage()
    {
        // Arrange & Act
        Action action = () => Thrower.ThrowOutOfRange(ParamName, StringValue, CustomMessage);

        // Assert
        action.Should().ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage($"{CustomMessage} (Parameter '{ParamName}')\nActual value was {StringValue}.");
    }

    [Fact]
    public void Throw_Should_ThrowArgumentException()
    {
        // Arrange & Act
        var expectedMessage = $"Value does not fall within the expected range. (Parameter '{ParamName}')";
        Action action = () => Thrower.Throw(ParamName);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage(expectedMessage);
    }

    [Fact]
    public void Throw_When_GivenCustomMessage_Should_ThrowArgumentExceptionWithCustomMessage()
    {
        // Arrange & Act
        var expectedMessage = $"{CustomMessage} (Parameter '{ParamName}')";
        Action action = () => Thrower.Throw(ParamName, CustomMessage);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage(expectedMessage);
    }
}