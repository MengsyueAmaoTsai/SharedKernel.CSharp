using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTThenTests : MonadTests
{
    [Fact]
    public void Then_When_IsFailure_Should_NotInvokeResultFactoryWithValue_And_ReturnErrorResultWithErrors()
    {
        // Arrange & Act
        var result = UnexpectedError
            .ToResult<int>()
            .Then(value => value.ToString());

        // Assert
        result.ShouldBeFailureWith(UnexpectedError);
    }

    [Fact]
    public void Then_When_IsSuccess_Should_InvokeResultFactoryWithValue_And_ReturnResultWithValue()
    {
        // Arrange & Act
        var result = Value.ToResult()
            .Then(value => value.ToString());

        // Assert
        result.ShouldBeSuccessWith(Value.ToString());
    }

    [Fact]
    public void Then_When_IsFailure_Should_NotInvokeResultFactory_And_ReturnResultWithError()
    {
        // Arrange & Act
        var result = UnexpectedError
            .ToResult<int>()
            .Then(() => 1);

        // Assert
        result.ShouldBeFailureWith(UnexpectedError);
    }

    [Fact]
    public void Then_When_IsSuccess_Should_InvokeResultFactory_And_ReturnResultWithValue()
    {
        // Arrange & Act
        var result = Value.ToResult()
            .Then(() => 1);

        // Assert
        result.ShouldBeSuccessWith(1);
    }

    [Fact]
    public void Then_When_IsFailure_Should_NotInvokeActionWithValue_And_ReturnFailureResult()
    {
        // Arrange & Act
        var result = UnexpectedError
            .ToResult<int>()
            .Then(value => throw new InvalidOperationException());

        // Assert   
        result.ShouldBeFailureWith(UnexpectedError);
    }

    [Fact]
    public void Then_When_IsSuccess_Should_InvokeActionWithValue_And_ReturnResultWithValue()
    {
        // Arrange
        var actionInvoked = false;

        // Act
        Value.ToResult()
            .Then(value => actionInvoked = true);

        // Assert
        actionInvoked.Should().BeTrue();
    }

    [Fact]
    public async Task ThenAsync_When_IsNull_Should_NotInvokeResultFactoryWithValue_And_ReturnMaybeWithNull()
    {
        // Arrange & Act
        var result = await UnexpectedError
            .ToResult<int>()
            .Then(ResultFactoryTask);

        // Assert
        result.ShouldBeFailureWith(UnexpectedError);
    }

    [Fact]
    public async Task ThenAsync_When_IsSuccess_Should_InvokeResultFactoryWithValue_And_ReturnResultWithValue()
    {
        // Arrange & Act
        var result = await Value
            .ToResult()
            .Then(ResultFactoryTask);

        // Assert
        result.ShouldBeSuccessWith(Value);
    }

    private static async Task<Result<int>> ResultFactoryTask(int value) =>
        await Task.FromResult(value.ToResult()).ConfigureAwait(false);
}