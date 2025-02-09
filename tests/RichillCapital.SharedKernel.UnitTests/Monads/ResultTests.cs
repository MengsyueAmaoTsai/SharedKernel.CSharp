namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed class ResultTests
{
    [Fact]
    public void Success_Should_CreateSuccessResult()
    {
        Result result = Result.Success();

        result.IsSuccess.ShouldBeTrue();
        result.IsFailure.ShouldBeFalse();
        Should.Throw<InvalidOperationException>(
            () => result.Error,
            Result.AccessErrorOnSuccessMessage);
    }

    [Fact]
    public void Failure_When_GivenNullError_ShouldThrowArgumentNullException() =>
        Should.Throw<ArgumentNullException>(
            () => Result.Failure(Error.Null),
            Result.NullErrorMessage);

    [Fact]
    public void Failure_Should_CreateFailureResult()
    {
        Error error = Error.Invalid("Invalid operation");
        Result result = Result.Failure(error);

        result.IsFailure.ShouldBeTrue();
        result.IsSuccess.ShouldBeFalse();
        result.Error.ShouldBe(error);
    }

    [Fact]
    public void SuccessResults_Should_BeEqual()
    {
        (Result result1, Result result2) = (Result.Success(), Result.Success());

        result1.ShouldBe(result2);
    }

    [Fact]
    public void FailureResults_WithSameError_Should_BeEqual()
    {
        Error error = Error.Invalid("Invalid operation");
        (Result result1, Result result2) = (Result.Failure(error), Result.Failure(error));

        result1.ShouldBe(result2);
    }

    [Fact]
    public void FailureResults_WithDifferentErrors_ShouldNotBeEqual()
    {
        (Result result1, Result result2) = (
            Result.Failure(Error.Invalid("Invalid operation")),
            Result.Failure(Error.Unexpected("Invalid operation")));

        result1.ShouldNotBe(result2);
    }

    [Fact]
    public void SuccessResult_Should_NotBeEqualToFailureResult()
    {
        (Result successResult, Result failureResult) = (
            Result.Success(),
            Result.Failure(Error.Invalid("Invalid operation")));

        successResult.ShouldNotBe(failureResult);
    }
}
