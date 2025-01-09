using FluentAssertions;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed class ErrorTests
{
    [Fact]
    public void Equals_When_WithSameTypes_And_SameMessages_Should_ReturnTrue()
    {
        var error1 = Error.Invalid("invalid");
        var error2 = Error.Invalid("invalid");

        var result = error1.Equals(error2);

        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_When_WithSameTypes_And_DifferentMessages_Should_ReturnFalse()
    {
        var error1 = Error.Invalid("invalid");
        var error2 = Error.Invalid("invalid2");

        var result = error1.Equals(error2);

        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_When_WithDifferentTypes_And_SameMessages_Should_ReturnFalse()
    {
        var error1 = Error.Invalid("invalid");
        var error2 = Error.Unauthorized("invalid");

        var result = error1.Equals(error2);

        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_When_WithDifferentTypes_And_DifferentMessages_Should_ReturnFalse()
    {
        var error1 = Error.Invalid("invalid");
        var error2 = Error.Unauthorized("invalid2");

        var result = error1.Equals(error2);

        result.Should().BeFalse();
    }
}