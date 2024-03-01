using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTMatchTests : MonadTests
{
    [Fact]
    public void Match_When_HasValue_Should_InvokeOnHasValueWithValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var resultValue = TestValue
            .ToMaybe()
            .Match(OnHasValue, OnIsNull);

        // Assert
        resultValue.Should().Be(OnHasValue(TestValue));
    }

    [Fact]
    public void Match_When_IsNull_Should_InvokeOnIsNull_And_ReturnResultValue()
    {
        // Arrange & Act
        var resultValue = Maybe<int>
            .Null
            .Match(OnHasValue, OnIsNull);

        // Assert
        resultValue.Should().Be(OnIsNull());
    }

    [Fact]
    public async Task MatchAsync_When_HasValue_Should_InvokeOnHasValueWithValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var resultValue = await MaybeTaskWithValue()
            .Match(OnHasValue, OnIsNull);

        // Assert
        resultValue.Should().Be(OnHasValue(TestValue));
    }

    [Fact]
    public async Task MatchAsync_When_IsNull_Should_InvokeOnIsNull_And_ReturnResultValue()
    {
        // Arrange & Act
        var resultValue = await MaybeTaskWithNull()
            .Match(OnHasValue, OnIsNull);

        // Assert
        resultValue.Should().Be(OnIsNull());
    }
}