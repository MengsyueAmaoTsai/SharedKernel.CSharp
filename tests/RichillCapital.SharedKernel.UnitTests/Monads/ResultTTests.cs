namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed class ResultTTests
{
    [Fact]
    public void Success_Should_CreateSuccessResultWithValue()
    {
        var value = 20;

        var result = Result<int>.Success(value);

        result.IsSuccess.ShouldBeTrue();
        result.IsFailure.ShouldBeFalse();
        Should.Throw<InvalidOperationException>(() => result.Error, Result<int>.AccessErrorOnSuccessMessage);
        result.Value.ShouldBe(value);
    }

    [Fact]
    public void Failure_Should_CreateFailureResult()
    {
        var error = Error.Invalid("Invalid operation");

        var result = Result<int>.Failure(error);

        result.IsFailure.ShouldBeTrue();
        result.IsSuccess.ShouldBeFalse();
        result.Error.ShouldBe(error);
        Should.Throw<InvalidOperationException>(() => result.Value, Result<int>.AccessValueOnFailureMessage);
    }

    [Fact]
    public void Failure_GivenNullError_ShouldThrowArgumentNullException() =>
        Should.Throw<ArgumentNullException>(() =>
            Result<int>.Failure(Error.Null), Result<int>.NullErrorMessage);

    [Fact]
    public void Results_WithSameValue_ShouldBeEqual()
    {
        var value = 20;
        (Result<int> result1, Result<int> result2) = (Result<int>.Success(value), Result<int>.Success(value));

        result1.ShouldBe(result2);
    }

    [Fact]
    public void Results_WithDifferentValues_ShouldNotBeEqual()
    {
        (Result<int> result1, Result<int> result2) = (
            Result<int>.Success(20),
            Result<int>.Success(30));

        result1.ShouldNotBe(result2);
    }

    [Fact]
    public void Results_WithSameError_ShouldBeEqual()
    {
        var error = Error.Invalid("Invalid operation");
        (Result<int> result1, Result<int> result2) = (Result<int>.Failure(error), Result<int>.Failure(error));

        result1.ShouldBe(result2);
    }

    [Fact]
    public void Results_WithDifferentErrors_ShouldNotBeEqual()
    {
        (Result<int> result1, Result<int> result2) = (
            Result<int>.Failure(Error.Invalid("Invalid operation")),
            Result<int>.Failure(Error.Unexpected("Invalid operation")));

        result1.ShouldNotBe(result2);
    }

    [Fact]
    public void SuccessResult_Should_NotBeEqualToFailureResult()
    {
        (Result<int> result1, Result<int> result2) =
            (Result<int>.Success(20), Result<int>.Failure(Error.Invalid("Invalid operation")));

        result1.ShouldNotBe(result2);
    }
}
