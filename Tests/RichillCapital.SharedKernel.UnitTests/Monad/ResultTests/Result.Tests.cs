using FluentAssertions;

using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class ResultTests : MonadTests
{
    [Fact]
    public void Equals_WhenComparingDifferenceResults_Should_ReturnFalse()
    {
        // Arrange
        var successResult = Result.Success();
        var failureResult = Result.Failure(TestError);

        // Act & Assert
        successResult.Equals(failureResult).Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenComparingResultsWithSameValue_Should_ReturnTrue()
    {
        // Arrange
        var successResult = Result.Success();
        var otherSuccessResult = Result.Success();
        var failureResult = Result.Failure(TestError);
        var otherFailureResult = Result.Failure(TestError);

        // Act & Assert
        successResult.Equals(otherSuccessResult).Should().BeTrue();
        failureResult.Equals(otherFailureResult).Should().BeTrue();
    }

    [Fact]
    public void Equals_When_ComparingFailureResultWithDifferentError_Should_ReturnFalse()
    {
        // Arrange
        var failureResult = Result.Failure(TestError);
        var otherFailureResult = Result.Failure(Error.NotFound("Not found"));

        // Act & Assert
        failureResult.Equals(otherFailureResult).Should().BeFalse();
    }
}