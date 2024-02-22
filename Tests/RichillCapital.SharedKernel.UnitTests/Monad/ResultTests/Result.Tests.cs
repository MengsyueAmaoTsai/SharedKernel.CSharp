using FluentAssertions;

using RichillCapital.SharedKernel.Monad;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class ResultTests
{
    [Fact]
    public void Equals_WhenComparingDifferenceResults_ShouldReturnFalse()
    {
        // Arrange
        var successResult = Result.Success();
        var failureResult = Result.Failure(TestError);

        // Act & Assert
        successResult.Equals(failureResult).Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenComparingResultsWithSameValue_ShouldReturnTrue()
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
    public void Equals_When_ComparingFailureResultWithDifferentError_ShouldReturnFalse()
    {
        // Arrange
        var failureResult = Result.Failure(TestError);
        var otherFailureResult = Result.Failure(Error.NotFound("Not found"));

        // Act & Assert
        failureResult.Equals(otherFailureResult).Should().BeFalse();
    }
}