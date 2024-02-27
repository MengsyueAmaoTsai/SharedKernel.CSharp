using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Then_When_IsValue_Should_InvokeFunctionWithValue_And_ReturnErrorOrWithValue() =>
        IntValue
            .ToErrorOr()
            .Then(value => value * 2)
            .ShouldBeErrorOrWithValue(IntValue * 2);

    [Fact]
    public void Then_When_IsError_ShouldNot_InvokeFunctionWithValue_And_ReturnErrorOrWithError() =>
        NotFoundError
            .ToErrorOr<int>()
            .Then(value => value * 2)
            .ShouldBeErrorOrWithError(NotFoundError);

    [Fact]
    public void Then_When_IsValue_Should_InvokeFunctionWithValue_And_ReturnErrorOrWithOriginalValue() =>
        IntValue
            .ToErrorOr()
            .Then(value => { })
            .ShouldBeErrorOrWithValue(IntValue);

    [Fact]
    public void Then_When_IsError_ShouldNot_InvokeFunctionWithValue_And_ReturnErrorOrWithOriginErrors() =>
        ValidationErrors
            .ToErrorOr<int>()
            .Then(value => { })
            .ShouldBeErrorOrWithErrors(ValidationErrors);

    [Fact]
    public async Task ThenAsync_When_IsValue_Should_InvokeFunctionWithValue_And_ReturnErrorOrWithValue() =>
        (await IntValue
            .ToErrorOr()
            .Then(value => Task.FromResult(value * 2)))
            .ShouldBeErrorOrWithValue(IntValue * 2);

    [Fact]
    public async Task ThenAsync_When_IsError_ShouldNot_InvokeFunctionWithValue_And_ReturnErrorOrWithError() =>
        (await NotFoundError
            .ToErrorOr<int>()
            .Then(value => Task.FromResult(value * 2)))
            .ShouldBeErrorOrWithError(NotFoundError);

    [Fact]
    public async Task ThenAsync_When_IsValue_Should_InvokeFunctionWithValue_And_ReturnErrorOrWithOriginalValue() =>
        (await IntValue
            .ToErrorOr()
            .Then(value => Task.CompletedTask))
            .ShouldBeErrorOrWithValue(IntValue);

    [Fact]
    public async Task ThenAsync_When_IsError_ShouldNot_InvokeFunctionWithValue_And_ReturnErrorOrWithOriginErrors() =>
        (await ValidationErrors
            .ToErrorOr<int>()
            .Then(value => Task.CompletedTask))
            .ShouldBeErrorOrWithErrors(ValidationErrors);
}