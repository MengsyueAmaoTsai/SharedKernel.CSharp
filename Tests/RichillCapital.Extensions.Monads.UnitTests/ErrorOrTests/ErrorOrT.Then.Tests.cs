using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTThenTests : MonadTests
{
    [Fact]
    public void Then_When_HasError_Should_NotInvokeValueFactory_And_ReturnErrorOrWithErrors()
    {
        // Arrange
        var errorOr = UnexpectedError
            .ToErrorOr<int>()
            .Then(DoSomethingWithValue);

        // Act
        errorOr.ShouldBeError(UnexpectedError);
    }

    [Fact]
    public void Then_When_HasValue_Should_InvokeValueFactory_And_ReturnErrorOrWithValue()
    {
        // Arrange
        var errorOr = Value
            .ToErrorOr()
            .Then(DoSomethingWithValue);

        // Act
        errorOr.ShouldBeValue(Value + 1);
    }

    [Fact]
    public async Task ThenAsync_When_HasError_Should_NotInvokeValueFactory_And_ReturnErrorOrWithErrors()
    {
        // Arrange
        var errorOr = await Errors
            .ToErrorOr<int>()
            .Then(DoSomethingWithValueAsync);

        // Act
        errorOr.ShouldBeErrors(Errors);
    }

    private static int DoSomethingWithValue(int value) => value + 1;

    private static async Task<int> DoSomethingWithValueAsync(int value) => await Task.FromResult(value + 1);
}