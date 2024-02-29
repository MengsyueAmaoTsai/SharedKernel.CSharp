using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTThenTests : MonadTests
{
    [Fact]
    public void Then_When_IsFailure_Should_NotInvokeResultFactory_And_ReturnErrorResultTWithErrors()
    {
        // Arrange & Act
        var result = UnexpectedError
            .ToResult<int>()
            .Then(value => value.ToString());

        // Assert
        result.ShouldBeFailureWith(UnexpectedError);
    }

    [Fact]
    public void Then_When_IsSuccess_Should_InvokeResultFactory_And_ReturnResultTWithValue()
    {
        // Arrange & Act
        var result = Value.ToResult()
            .Then(value => value.ToString());

        // Assert
        result.ShouldBeSuccessWith(Value.ToString());
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
    public void Then_When_IsSuccess_Should_InvokeActionWithValue_And_ReturnResultTWithValue()
    {
        // Arrange
        var actionInvoked = false;

        // Act
        Value.ToResult()
            .Then(value => actionInvoked = true);

        // Assert
        actionInvoked.Should().BeTrue();
    }
}