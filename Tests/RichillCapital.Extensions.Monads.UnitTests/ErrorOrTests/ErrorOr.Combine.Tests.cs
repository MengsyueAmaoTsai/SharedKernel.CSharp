using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrCombineTests : MonadTests
{
    [Fact]
    public void CombineFactory_When_AllErrorOrsAreValue_Should_ReturnLastErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.Combine(
            1.ToErrorOr(),
            2.ToErrorOr(),
            3.ToErrorOr());

        // Assert
        errorOr.ShouldBeValue(3);
    }

    [Fact]
    public void CombineFactory_When_ErrorOrsContainError_Should_ReturnFirstErrorOr()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.Combine(
            1.ToErrorOr(),
            UnexpectedError.ToErrorOr<int>(),
            3.ToErrorOr());

        // Assert
        errorOr.ShouldBeError(UnexpectedError);
    }

    [Fact]
    public void CombineFactory_When_AllResultsAreSuccess_Should_ConvertLastResultToErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.Combine(
            1.ToResult(),
            2.ToResult(),
            3.ToResult());

        // Assert
        errorOr.ShouldBeValue(3);
    }

    [Fact]
    public void CombineFactory_When_ResultsContainFailure_Should_ConvertFirstFailureToErrorOrWithError()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.Combine(
            UnexpectedError.ToResult<int>(),
            NotFoundError.ToResult<int>(),
            3.ToResult());

        // Assert
        errorOr.ShouldBeErrors([UnexpectedError, NotFoundError]);
    }
}