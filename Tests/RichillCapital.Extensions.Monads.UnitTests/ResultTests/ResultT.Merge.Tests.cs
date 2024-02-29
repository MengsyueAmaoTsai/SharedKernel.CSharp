using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTMergeTests : MonadTests
{
    [Fact]
    public void Merge_When_OriginalIsSuccess_And_AllResultsAreSuccess_Should_ReturnLastSuccessResultWithValue()
    {
        // Arrange & Act
        var result = Value.ToResult().Merge(
            10.ToResult(),
            20.ToResult());

        // Assert
        result.ShouldBeSuccessWith(20);
    }

    [Fact]
    public void Merge_When_OriginalIsFailure_And_AllResultsAreSuccess_Should_ReturnOriginalWithError()
    {
        // Arrange & Act
        var result = UnexpectedError.ToResult<int>()
            .Merge(10.ToResult(), 20.ToResult());

        // Assert
        result.ShouldBeFailureWith(UnexpectedError);
    }

    [Fact]
    public void Merge_When_OriginalIsSuccess_And_ContainsFailure_Should_ReturnFirstFailureResult()
    {
        // Arrange & Act
        var result = Value.ToResult()
            .Merge(
                20.ToResult(),
                UnexpectedError.ToResult<int>(),
                NotFoundError.ToResult<int>());

        // Assert
        result.ShouldBeFailureWith(UnexpectedError);
    }

    [Fact]
    public void Merge_When_OriginalIsFailure_And_ContainsFailure_Should_ReturnOriginalWithError()
    {
        // Arrange & Act
        var result = UnexpectedError.ToResult<int>()
            .Merge(
                20.ToResult(),
                NotFoundError.ToResult<int>(),
                NotFoundError.ToResult<int>());

        // Assert
        result.ShouldBeFailureWith(UnexpectedError);
    }
}