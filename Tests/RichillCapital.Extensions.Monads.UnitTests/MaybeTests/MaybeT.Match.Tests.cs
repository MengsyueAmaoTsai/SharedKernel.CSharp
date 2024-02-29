using FluentAssertions;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class MaybeTMatchTests
{
    [Fact]
    public void Match_When_IsNull_Should_InvokeOnNull_And_ReturnResult()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Match(OnValue, OnNull);

        // Assert
        maybe.Should().Be(0);
    }

    [Fact]
    public void Match_When_IsValue_Should_InvokeOnValue_And_ReturnResult()
    {
        // Arrange & Act
        var maybe = 1.ToMaybe()
            .Match(OnValue, OnNull);

        // Assert
        maybe.Should().Be(2);
    }

    private static int OnValue(int value) => value * 2;

    private static int OnNull() => 0;
}