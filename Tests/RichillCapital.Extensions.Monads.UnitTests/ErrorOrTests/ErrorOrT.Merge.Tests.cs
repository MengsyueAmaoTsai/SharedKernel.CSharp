using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTMergeTests : MonadTests
{
    [Fact]
    public void Merge_When_OriginalIsValue_And_AllErrorOrsAreValue_Should_ReturnLastValue()
    {
        // Arrange & Act
        var errorOr = 10.ToErrorOr().Merge(
            20.ToErrorOr(),
            30.ToErrorOr());

        // Assert
        errorOr.ShouldBeValue(30);
    }

    [Fact]
    public void Merge_When_OriginalIsFailure_And_AllErrorOrsAreValue_Should_ReturnOriginalWithError()
    {
        // Arrange & Act
        var errorOr = UnexpectedError.ToErrorOr<int>()
            .Merge(10.ToErrorOr(), 20.ToErrorOr());

        // Assert
        errorOr.ShouldBeError(UnexpectedError);
    }

    [Fact]
    public void Merge_When_OriginalIsValue_And_ContainsError_Should_ReturnErrorOrWithAllErrors()
    {
        // Arrange & Act
        var errorOr = 10.ToErrorOr()
            .Merge(
                UnexpectedError.ToErrorOr<int>(),
                20.ToErrorOr(),
                NotFoundError.ToErrorOr<int>());

        // Assert
        errorOr.ShouldBeErrors([UnexpectedError, NotFoundError]);
    }

    [Fact]
    public void Merge_When_OriginalIsFailure_And_ContainsError_Should_ReturnErrorOrWithAllErrors()
    {
        // Arrange & Act
        var errorOr = UnexpectedError.ToErrorOr<int>()
            .Merge(
                20.ToErrorOr(),
                NotFoundError.ToErrorOr<int>(),
                NotFoundError.ToErrorOr<int>());

        // Assert
        errorOr.ShouldBeErrors([UnexpectedError, NotFoundError]);
    }
}