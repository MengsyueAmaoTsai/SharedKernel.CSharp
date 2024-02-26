using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public async Task Then_When_ErrorOrIsValue_Should_ReturnErrorOrWithResultValue()
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
    public async Task Then_When_ErrorOrIsError_Should_ReturnErrorOrWithErrors()
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

    private static async Task<ErrorOr<int>> UpdateValueAsync(int value) =>
        await Task.FromResult(ErrorOr<int>.Is(value * 2));
}