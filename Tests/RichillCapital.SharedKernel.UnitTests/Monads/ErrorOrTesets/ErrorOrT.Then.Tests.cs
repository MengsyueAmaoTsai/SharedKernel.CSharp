using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public async Task Then_When_ErrorOrIsValue_Should_InvokeTaskReturnErrorOrWithResultValue()
    {
        // Arrange & Act
        var errorOr = await ErrorOr<int>
            .Is(IntValue)
            .Then(UpdateValueAsync);

        // Assert
        errorOr.IsValue.Should().BeTrue();
        errorOr.Value.Should().Be(IntValue * 2);
    }

    [Fact]
    public async Task Then_When_ErrorOrIsError_ShouldNot_InvokeTaskReturnErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOr = await ErrorOr<int>
            .Is(NotFoundError)
            .Then(UpdateValueAsync);

        // Assert
        errorOr.IsError.Should().BeTrue();
        errorOr.Errors.Should().Contain(NotFoundError);
        errorOr.ErrorsOrEmpty.Should().Contain(NotFoundError);
        errorOr.ErrorsOrEmpty.Should().HaveCount(1);
    }

    [Fact]
    public void Then_When_ErrorOrIsError_ShouldNot_InvokeFactory()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>
            .Is(NotFoundError)
            .Then(CreateValue);

        // Assert
        errorOr.IsError.Should().BeTrue();
        errorOr.Errors.Should().Contain(NotFoundError);
    }

    [Fact]
    public void Then_When_ErrorOrIsValue_Should_InvokeFactoryAndReturnErrorOrWithResult()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>
            .Is(IntValue)
            .Then(CreateValue);

        // Assert
        errorOr.IsValue.Should().BeTrue();
        errorOr.Value.Should().Be(5);
    }

    private static async Task<ErrorOr<int>> UpdateValueAsync(int value) =>
        await Task.FromResult(ErrorOr<int>.Is(value * 2));

    private static int CreateValue() => 5;
}