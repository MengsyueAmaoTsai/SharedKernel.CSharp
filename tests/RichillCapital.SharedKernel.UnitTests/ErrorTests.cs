namespace RichillCapital.SharedKernel.UnitTests;

public sealed class ErrorTests
{
    [Fact]
    public void Create_When_GivenErrorTypeNull_Should_ThrowArgumentException()
    {
        Action action = () => Error.Create(ErrorType.Null, "errorCode", "errorMessage");
        action.ShouldThrow<ArgumentException>().Message.ShouldBe(Error.NullMessage);
    }

    [Fact]
    public void Create_When_GivenEmptyErrorCode_Should_ThrowArgumentException()
    {
        Action action = () => Error.Create(ErrorType.Validation, string.Empty, "errorMessage");
        action.ShouldThrow<ArgumentException>().Message.ShouldBe(Error.EmptyCodeMessage);
    }

    [Theory]
    [InlineData(ErrorType.Validation)]
    [InlineData(ErrorType.Unauthorized)]
    [InlineData(ErrorType.AccessDenied)]
    [InlineData(ErrorType.NotFound)]
    [InlineData(ErrorType.MethodNotAllowed)]
    [InlineData(ErrorType.Conflict)]
    [InlineData(ErrorType.UnsupportedMediaType)]
    [InlineData(ErrorType.Unexpected)]
    [InlineData(ErrorType.Unavailable)]
    public void Create_Should_CreateError(ErrorType errorType)
    {
        var errorCode = "Error.Code";
        var errorMessage = "Error message";

        Error error = Error.Create(errorType, errorCode, errorMessage);

        error.Type.ShouldBe(errorType);
        error.Code.ShouldBe(errorCode);
        error.Message.ShouldBe(errorMessage);
    }

    [Theory]
    [InlineData(ErrorType.Validation, nameof(ErrorType.Validation))]
    [InlineData(ErrorType.Unauthorized, nameof(ErrorType.Unauthorized))]
    [InlineData(ErrorType.AccessDenied, nameof(ErrorType.AccessDenied))]
    [InlineData(ErrorType.NotFound, nameof(ErrorType.NotFound))]
    [InlineData(ErrorType.MethodNotAllowed, nameof(ErrorType.MethodNotAllowed))]
    [InlineData(ErrorType.Conflict, nameof(ErrorType.Conflict))]
    [InlineData(ErrorType.UnsupportedMediaType, nameof(ErrorType.UnsupportedMediaType))]
    [InlineData(ErrorType.Unexpected, nameof(ErrorType.Unexpected))]
    [InlineData(ErrorType.Unavailable, nameof(ErrorType.Unavailable))]
    public void FactoryMethods_Should_CreateCorrectError(
        ErrorType errorType,
        string defaultErrorCode)
    {
        string customErrorCode = "Error.Code";
        string errorMessage = "Error message";

        (Error error1, Error error2) = errorType switch
        {
            ErrorType.Validation => (Error.Invalid(customErrorCode, errorMessage), Error.Invalid(errorMessage)),
            ErrorType.Unauthorized => (Error.Unauthorized(customErrorCode, errorMessage), Error.Unauthorized(errorMessage)),
            ErrorType.AccessDenied => (Error.AccessDenied(customErrorCode, errorMessage), Error.AccessDenied(errorMessage)),
            ErrorType.NotFound => (Error.NotFound(customErrorCode, errorMessage), Error.NotFound(errorMessage)),
            ErrorType.MethodNotAllowed => (Error.MethodNotAllowed(customErrorCode, errorMessage), Error.MethodNotAllowed(errorMessage)),
            ErrorType.Conflict => (Error.Conflict(customErrorCode, errorMessage), Error.Conflict(errorMessage)),
            ErrorType.UnsupportedMediaType => (Error.UnsupportedMediaType(customErrorCode, errorMessage), Error.UnsupportedMediaType(errorMessage)),
            ErrorType.Unexpected => (Error.Unexpected(customErrorCode, errorMessage), Error.Unexpected(errorMessage)),
            ErrorType.Unavailable => (Error.Unavailable(customErrorCode, errorMessage), Error.Unavailable(errorMessage)),
            _ => throw new ArgumentOutOfRangeException(nameof(errorType), errorType, null),
        };

        error1.Type.ShouldBe(errorType);
        error1.Code.ShouldBe(customErrorCode);
        error1.Message.ShouldBe(errorMessage);

        error2.Type.ShouldBe(errorType);
        error2.Code.ShouldBe(defaultErrorCode);
        error2.Message.ShouldBe(errorMessage);
    }

    [Fact]
    public void Null_Should_ReturnNullError()
    {
        Error error = Error.Null;

        error.Type.ShouldBe(ErrorType.Null);
        error.Code.ShouldBe(nameof(ErrorType.Null));
        error.Message.ShouldBe(string.Empty);
    }
}
