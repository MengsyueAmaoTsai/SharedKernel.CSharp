using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTMatchTests : MonadTests
{
    [Fact]
    public void Match_WhenIsSuccess_Should_Invoke_OnSuccessWithValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = TestValue.ToResult()
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(OnSuccess(TestValue));
    }

    [Fact]
    public void Match_WhenIsFailure_Should_Invoke_OnFailureWithError_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = TestError.ToResult<int>()
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(OnFailure(TestError));
    }

    [Fact]
    public async Task MatchAsync_WhenIsSuccess_Should_Invoke_OnSuccessWithValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = await ResultTaskWithValue()
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(OnSuccess(TestValue));
    }

    [Fact]
    public async Task MatchAsync_WhenIsFailure_Should_Invoke_OnFailureWithError_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = await ResultTaskWithError()
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(OnFailure(TestError));
    }
}