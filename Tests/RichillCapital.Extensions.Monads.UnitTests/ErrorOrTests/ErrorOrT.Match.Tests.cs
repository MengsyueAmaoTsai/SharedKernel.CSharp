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
            .Match(OnError, OnIsValue);

        // Assert
        result.Should().Be(OnIsValue(TestValue));
    }

    [Fact]
    public void Match_When_HasError_Should_InvokeOnHasErrorWithErrors_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = TestErrors
            .ToErrorOr<int>()
            .Match(OnError, OnIsValue);

        // Assert
        result.Should().Be(OnError(TestErrors));
    }

    [Fact]
    public async Task MatchAsync_When_ErrorOrTaskIsValue_Should_InvokeOnIsValueWithValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = await ErrorOrTaskWithValue()
            .Match(OnError, OnIsValue);

        // Assert
        result.Should().Be(OnIsValue(TestValue));
    }

    [Fact]
    public async Task MatchAsync_When_ErrorOrTaskHasError_Should_InvokeOnHasErrorWithErrors_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = await ErrorOrTaskWithErrors()
            .Match(OnError, OnIsValue);

        // Assert
        result.Should().Be(OnError(TestErrors));
    }
}