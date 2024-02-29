using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTThenTests : MonadTests
{
    [Fact]
    public void Then_When_HasError_Should_NotInvokeResultFactoryWithValue_And_ReturnErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOr = UnexpectedError
            .ToErrorOr<int>()
            .Then(value => value.ToString());

        // Assert
        errorOr.ShouldBeError(UnexpectedError);
    }

    [Fact]
    public void Then_When_IsValue_Should_InvokeResultFactoryWithValue_And_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = Value.ToErrorOr()
            .Then(value => value.ToString());

        // Assert
        errorOr.ShouldBeValue(Value.ToString());
    }

    [Fact]
    public void Then_When_HasError_Should_NotInvokeResultFactory_And_ReturnErrorOrWithErrors()
    {
        // Arrange
        var errorOr = UnexpectedError
            .ToErrorOr<int>()
            .Then(() => 1);

        // Assert
        errorOr.ShouldBeError(UnexpectedError);
    }

    [Fact]
    public void Then_When_IsValue_Should_InvokeResultFactory_And_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = Value.ToErrorOr()
            .Then(() => 1);

        // Assert
        errorOr.ShouldBeValue(1);
    }

    [Fact]
    public void Then_When_HasError_Should_NotInvokeActionWithValue_And_ReturnErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOr = UnexpectedError
            .ToErrorOr<int>()
            .Then(value => throw new InvalidOperationException());

        // Assert   
        errorOr.ShouldBeError(UnexpectedError);
    }

    [Fact]
    public void Then_When_IsValue_Should_InvokeActionWithValue_And_ReturnErrorOrWithValue()
    {
        // Arrange
        var actionInvoked = false;

        // Act
        Value.ToErrorOr()
            .Then(value => actionInvoked = true);

        // Assert
        actionInvoked.Should().BeTrue();
    }
}