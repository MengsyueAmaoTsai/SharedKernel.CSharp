using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void Match_When_MaybeWithNoValue_Should_InvokeOnNoValue()
    {
        // Arrange & Act
        var intValue = Maybe<int>
            .Null
            .Match(OnHasValue, OnNoValue);

        // Assert
        intValue.Should().Be(0);
    }

    [Fact]
    public void Match_When_MaybeWithValue_Should_InvokeOnHasValue()
    {
        // Arrange & Act
        var intValue = Maybe<int>
            .Have(IntValue)
            .Match(OnHasValue, OnNoValue);

        // Assert
        intValue.Should().Be(IntValue + 10);
    }

    [Fact]
    public async Task MatchAsync_When_MaybeWithNoValue_Should_InvokeOnNoValue()
    {
        // Arrange & Act
        var intValue = await Maybe<int>
            .Null
            .Match(OnHasValueAsync, OnNoValueAsync);

        // Assert
        intValue.Should().Be(0);
    }

    [Fact]
    public async Task MatchAsync_When_MaybeWithValue_Should_InvokeOnHasValue()
    {
        // Arrange & Act
        var intValue = await Maybe<int>
            .Have(IntValue)
            .Match(OnHasValueAsync, OnNoValueAsync);

        // Assert
        intValue.Should().Be(IntValue + 10);
    }

    [Fact]
    public async Task MatchAsync_When_MaybeTaskWithNoValue_Should_InvokeOnNoValue()
    {
        // Arrange & Act
        var intValue = await Task.FromResult(Maybe<int>
            .Null)
            .Match(OnHasValue, OnNoValue);

        // Assert
        intValue.Should().Be(0);
    }

    [Fact]
    public async Task MatchAsync_When_MaybeTaskWithValue_Should_InvokeOnHasValue()
    {
        // Arrange & Act
        var intValue = await Task.FromResult(Maybe<int>
            .Have(IntValue))
            .Match(OnHasValue, OnNoValue);

        // Assert
        intValue.Should().Be(IntValue + 10);
    }
}