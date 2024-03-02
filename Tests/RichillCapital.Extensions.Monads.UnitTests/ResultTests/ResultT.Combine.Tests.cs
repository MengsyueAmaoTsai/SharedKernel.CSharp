using RichillCapital.Extensions.Monads.UnitTests.Shared;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class ResultTCombineTests : MonadTests
{
    [Fact]
    public void Combine_When_AllResultsAreSuccess_Should_ReturnLastSuccessResult()
    {
        // Arrange
        var result1 = 1.ToResult();
        var result2 = 2.ToResult();
        var result3 = 3.ToResult();

        // Act
        var combinedResult = Result<int>.Combine(result1, result2, result3);

        // Assert
        combinedResult.ShouldBeSuccessWith(3);
    }

    [Fact]
    public void Combine_When_AnyResultIsFailure_Should_ReturnFirstFailureResult()
    {
        // Arrange
        var result1 = 1.ToResult();
        var result2 = TestError.ToResult<int>();
        var result3 = 3.ToResult();

        // Act
        var combinedResult = Result<int>.Combine(result1, result2, result3);

        // Assert
        combinedResult.ShouldBeFailureWith(TestError);
    }
}