using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class MaybeTMatchTests : MonadTests
{
    [Fact]
    public void Match_When_IsNull_Should_InvokeOnNull_And_ReturnResult()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Match(OnHasValue, OnNull);

        // Assert
        maybe.Should().Be(0);
    }

    [Fact]
    public void Match_When_IsValue_Should_InvokeOnHasValue_And_ReturnResult()
    {
        // Arrange & Act
        var maybe = 1.ToMaybe()
            .Match(OnHasValue, OnNull);

        // Assert
        maybe.Should().Be(2);
    }

    [Fact]
    public async Task MatchAsync_When_IsNull_Should_InvokeOnNull_And_ReturnResult()
    {
        // Arrange & Act
        var maybe = await Maybe<int>.Null
            .Then(MaybeFactoryTask)
            .Match(OnHasValue, OnNull);

        // Assert
        maybe.Should().Be(0);
    }

    [Fact]
    public async Task MatchAsync_When_IsValue_Should_InvokeOnHasValue_And_ReturnResult()
    {
        // Arrange & Act
        var maybe = await Value.ToMaybe()
            .Then(MaybeFactoryTask)
            .Match(OnHasValue, OnNull);

        // Assert
        maybe.Should().Be(Value * 2);
    }
}