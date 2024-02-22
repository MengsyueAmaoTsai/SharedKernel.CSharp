using FluentAssertions;

using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class ResultTests : MonadTests
{
    [Fact]
    public void ImplicitCast_Should_CreateFailureResult_When_CastingErrorToResult()
    {
        // Arrange & Act
        Result result = TestError;

        // Assert
        result.ShouldBeFailureResultWithError(TestError);
    }

    [Fact]
    public void Equal_Should_ReturnTrue_When_BothResultsAreSuccessAndValuesAreEqual()
    {
        // Arrange
        Result result1 = Result.Success();
        Result result2 = Result.Success();

        // Act
        bool areEqual = result1 == result2;

        // Assert
        areEqual.Should().BeTrue();
    }

    [Fact]
    public void Equal_Should_ReturnFalse_When_BothResultsAreFailureAndErrorAreNotEqual()
    {
        // Arrange
        Result result1 = Result.Failure(Error.Invalid("error1"));
        Result result2 = Result.Failure(Error.Invalid("error2"));

        // Act
        bool areEqual = result1 == result2;

        // Assert
        areEqual.Should().BeFalse();
    }
}