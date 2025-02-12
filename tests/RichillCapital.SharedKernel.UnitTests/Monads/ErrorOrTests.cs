namespace RichillCapital.SharedKernel.Monads;

public sealed class ErrorOrTests
{
    [Fact]
    public void WithValue_Should_CreateErrorOrWithValue()
    {
        var value = 20;

        var errorOr = ErrorOr<int>.WithValue(value);

        errorOr.IsValue.ShouldBeTrue();
        errorOr.HasError.ShouldBeFalse();
        Should.Throw<InvalidOperationException>(() => errorOr.Errors, ErrorOr<int>.AccessErrorsOnValueMessage);
        errorOr.Value.ShouldBe(value);
    }

    [Fact]
    public void WithError_Should_CreateErrorOrContainsError()
    {
        var error = Error.Invalid("Invalid operation");
        var errorOr = ErrorOr<int>.WithError(error);

        errorOr.HasError.ShouldBeTrue();
        errorOr.IsValue.ShouldBeFalse();
        errorOr.Errors.ShouldContain(error);
        Should.Throw<InvalidOperationException>(() => errorOr.Value, ErrorOr<int>.AccessValueOnErrorsMessage);
    }

    [Fact]
    public void WithError_GivenNullError_ShouldThrowArgumentNullException() =>
        Should.Throw<ArgumentNullException>(() =>
            ErrorOr<int>.WithError(Error.Null), ErrorOr<int>.NullErrorMessage);

    [Fact]
    public void WithErrors_Should_CreateErrorOrContainsErrors()
    {
        var errors = new List<Error>
        {
            Error.Invalid("Invalid operation"),
            Error.Invalid("Invalid operation")
        };

        var errorOr = ErrorOr<int>.WithErrors(errors);

        errorOr.HasError.ShouldBeTrue();
        errorOr.IsValue.ShouldBeFalse();
        errorOr.Errors.ShouldBe(errors);
        Should.Throw<InvalidOperationException>(() => errorOr.Value, ErrorOr<int>.AccessValueOnErrorsMessage);
    }

    [Fact]
    public void WithErrors_GivenErrorsContainsNullError_ShouldThrowArgumentNullException()
    {
        var errors = new List<Error>
        {
            Error.Null,
            Error.Invalid("Invalid operation"),
        };

        Should.Throw<ArgumentNullException>(() =>
            ErrorOr<int>.WithErrors(errors), ErrorOr<int>.NullErrorMessage);
    }

    [Fact]
    public void ErrorOr_WithSameValue_ShouldBeEqual()
    {
        var value = 20;
        (ErrorOr<int> errorOr1, ErrorOr<int> errorOr2) = (ErrorOr<int>.WithValue(value), ErrorOr<int>.WithValue(value));

        errorOr1.ShouldBe(errorOr2);
    }

    [Fact]
    public void ErrorOr_WithDifferentValues_ShouldNotBeEqual()
    {
        (ErrorOr<int> errorOr1, ErrorOr<int> errorOr2) = (
            ErrorOr<int>.WithValue(20),
            ErrorOr<int>.WithValue(30));

        errorOr1.ShouldNotBe(errorOr2);
    }

    [Fact]
    public void ErrorOr_WithSameError_ShouldBeEqual()
    {
        var error = Error.Invalid("Invalid operation");
        (ErrorOr<int> errorOr1, ErrorOr<int> errorOr2) = (ErrorOr<int>.WithError(error), ErrorOr<int>.WithError(error));

        errorOr1.ShouldBe(errorOr2);
    }

    [Fact]
    public void ErrorOr_WithDifferentErrors_ShouldNotBeEqual()
    {
        (ErrorOr<int> errorOr1, ErrorOr<int> errorOr2) = (
            ErrorOr<int>.WithErrors(new List<Error> { Error.Invalid("Invalid operation") }),
            ErrorOr<int>.WithErrors(new List<Error> { Error.Invalid("Invalid operation2") }));

        errorOr1.ShouldNotBe(errorOr2);
    }
}
