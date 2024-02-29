using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTMatchTests : MonadTests
{
    [Fact]
    public void Match_When_IsFailure_Should_InvokeOnFailure_And_ReturnResult()
    {
        // Arrange & Act
        var result = UnexpectedError
            .ToResult<int>()
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void Match_When_IsSuccess_Should_InvokeOnSuccess_And_ReturnResult()
    {
        // Arrange & Act
        var result = Value
            .ToResult()
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(Value * 2);
    }

    [Fact]
    public async Task MatchAsync_When_IsFailure_Should_InvokeOnFailure_And_ReturnResult()
    {
        // Arrange & Act
        var result = await UnexpectedError
            .ToResult<int>()
            .Then(ResultFactoryTask)
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public async Task MatchAsync_When_IsSuccess_Should_InvokeOnSuccess_And_ReturnResult()
    {
        // Arrange & Act
        var result = await Value
            .ToResult()
            .Then(ResultFactoryTask)
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(Value * 2);
    }
}