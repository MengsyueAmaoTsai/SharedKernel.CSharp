using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTMatchTests : MonadTests
{
    [Fact]
    public void Match_When_IsSuccess_Should_InvokeOnSuccessWithValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = TestValue.ToResult()
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(OnSuccess(TestValue));
    }

    [Fact]
    public void Match_When_IsFailure_Should_InvokeOnFailureWithError_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = TestError.ToResult<int>()
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(OnFailure(TestError));
    }

    [Fact]
    public async Task MatchAsync_When_IsSuccess_Should_InvokeOnSuccessWithValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = await ResultTaskWithValue()
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(OnSuccess(TestValue));
    }

    [Fact]
    public async Task MatchAsync_When_IsFailure_Should_InvokeOnFailureWithError_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = await ResultTaskWithError()
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(OnFailure(TestError));
    }

    [Fact]
    public async Task MatchAsync_When_IsFailure_Should_InvokeOnFailureTaskWithError_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = await TestError
            .ToResult<int>()
            .Match(OnSuccessAsync, OnFailureAsync);

        // Assert
        result.Should().Be(OnFailure(TestError));
    }

    [Fact]
    public async Task MatchAsync_When_IsSuccess_Should_InvokeOnSuccessTaskWithValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = await TestValue
            .ToResult()
            .Match(OnSuccessAsync, OnFailureAsync);

        // Assert
        result.Should().Be(OnSuccess(TestValue));
    }
}