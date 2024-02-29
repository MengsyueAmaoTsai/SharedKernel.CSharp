using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTCombineTests : MonadTests
{
    [Fact]
    public void CombineFactory_When_AllResultsAreSuccess_Should_ReturnLastResultWithValue()
    {
        // Arrange & Act
        var result = Result<int>.Combine(
            1.ToResult(),
            2.ToResult(),
            3.ToResult());

        // Assert
        result.ShouldBeSuccessWith(3);
    }

    [Fact]
    public void CombineFactory_When_ResultsContainFailure_Should_ReturnFirstFailure()
    {
        // Arrange & Act
        var result = Result<int>.Combine(
            1.ToResult(),
            UnexpectedError.ToResult<int>(),
            3.ToResult());

        // Assert
        result.ShouldBeFailureWith(UnexpectedError);
    }

    [Fact]
    public void CombineFactory_When_AllErrorOrsAreValue_Should_ConvertLastErrorOrToResultWithValue()
    {
        // Arrange & Act
        var result = Result<int>.Combine(
            1.ToErrorOr(),
            2.ToErrorOr(),
            3.ToErrorOr());

        // Assert
        result.ShouldBeSuccessWith(3);
    }

    [Fact]
    public void CombineFactory_When_ErrorOrsContainError_Should_ConvertFirstErrorOrToResultWithError()
    {
        // Arrange & Act
        var result = Result<int>.Combine(
            1.ToErrorOr(),
            UnexpectedError.ToErrorOr<int>(),
            3.ToErrorOr());

        // Assert
        result.ShouldBeFailureWith(UnexpectedError);
    }
}