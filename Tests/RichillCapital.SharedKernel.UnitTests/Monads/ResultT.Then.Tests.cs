using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public async Task Then_When_ResultIsSuccess_Should_InvokeTaskAndReturnResultWithValue()
    {
        // Arrange & Act
        var result = await Result<int>
            .Success(IntValue)
            .Then(UpdateValueAsync);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(IntValue * 2);
    }

    [Fact]
    public async Task Then_When_ResultIsFailure_ShouldNot_InvokeTaskAndReturnResultWithErrors()
    {
        // Arrange & Act
        var result = await Result<int>
            .Failure(NotFoundError)
            .Then(UpdateValueAsync);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(NotFoundError);
    }

    [Fact]
    public void Then_When_ResultIsFailure_ShouldNot_InvokeFactory()
    {
        // Arrange & Act
        var result = Result<int>
            .Failure(NotFoundError)
            .Then(CreateValue);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(NotFoundError);
    }

    [Fact]
    public void Then_When_ResultIsSuccess_Should_InvokeFactoryAndReturnResultWithResult()
    {
        // Arrange & Act
        var result = Result<int>
            .Success(IntValue)
            .Then(CreateValue);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(5);
    }

    private static async Task<Result<int>> UpdateValueAsync(int value) =>
        await Task.FromResult(Result<int>.Success(value * 2));

    private static int CreateValue() => 5;
}