using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTMatchTests : MonadTests
{
    [Fact]
    public void Match_When_IsValue_Should_InvokeOnIsValueWithValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = TestValue
            .ToErrorOr()
            .Match(OnHasError, OnIsValue);

        // Assert
        result.Should().Be(OnIsValue(TestValue));
    }

    [Fact]
    public void Match_When_HasError_Should_InvokeOnHasErrorWithErrors_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = TestErrors
            .ToErrorOr<int>()
            .Match(OnHasError, OnIsValue);

        // Assert
        result.Should().Be(OnHasError(TestErrors));
    }

    [Fact]
    public async Task MatchAsync_When_ErrorOrTaskIsValue_Should_InvokeOnIsValueWithValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = await ErrorOrTaskWithValue()
            .Match(OnHasError, OnIsValue);

        // Assert
        result.Should().Be(OnIsValue(TestValue));
    }

    [Fact]
    public async Task MatchAsync_When_ErrorOrTaskHasError_Should_InvokeOnHasErrorWithErrors_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = await ErrorOrTaskWithErrors()
            .Match(OnHasError, OnIsValue);

        // Assert
        result.Should().Be(OnHasError(TestErrors));
    }

    [Fact]
    public async Task MatchAsync_When_HasError_Should_InvokeOnHasErrorTaskWithErrors_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = await TestErrors
            .ToErrorOr<int>()
            .Match(OnHasErrorAsync, OnIsValueAsync);

        // Assert
        result.Should().Be(await OnHasErrorAsync(TestErrors));
    }

    [Fact]
    public async Task MatchAsync_When_IsValue_Should_InvokeOnIsValueTaskWithValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = await TestValue
            .ToErrorOr()
            .Match(OnHasErrorAsync, OnIsValueAsync);

        // Assert
        result.Should().Be(await OnIsValueAsync(TestValue));
    }
}