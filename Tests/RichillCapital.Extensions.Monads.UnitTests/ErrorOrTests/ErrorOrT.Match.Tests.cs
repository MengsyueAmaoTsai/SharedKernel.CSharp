using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class ErrorOrTMatchTests : MonadTests
{
    [Fact]
    public void Match_When_HasError_Should_InvokeOnError_And_ReturnResult()
    {
        // Arrange & Act
        var result = UnexpectedError.ToErrorOr<int>()
            .Match(OnError, OnValue);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void Match_When_IsValue_Should_InvokeOnValue_And_ReturnResult()
    {
        // Arrange & Act
        var result = Value.ToErrorOr()
            .Match(OnError, OnValue);

        // Assert
        result.Should().Be(Value * 2);
    }

    [Fact]
    public async Task MatchAsync_When_HasError_Should_InvokeOnError_And_ReturnResult()
    {
        // Arrange & Act
        var result = await UnexpectedError.ToErrorOr<int>()
            .Then(ErrorOrFactoryTask)
            .Match(OnError, OnValue);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public async Task MatchAsync_When_IsValue_Should_InvokeOnValue_And_ReturnResult()
    {
        // Arrange & Act
        var result = await Value.ToErrorOr()
            .Then(ErrorOrFactoryTask)
            .Match(OnError, OnValue);

        // Assert
        result.Should().Be(Value * 2);
    }
}