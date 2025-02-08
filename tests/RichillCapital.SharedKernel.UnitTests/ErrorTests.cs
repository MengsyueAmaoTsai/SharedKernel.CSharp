namespace RichillCapital.SharedKernel.UnitTests;

public sealed class ErrorTests
{
    [Fact]
    public void Create_When_GivenErrorTypeNone_Should_ThrowArgumentException()
    {
        Action action = () => Error.Create(ErrorType.Null, "errorCode", "errorMessage");

        action.ShouldThrow<ArgumentException>();
    }

    [Theory]
    [InlineData(ErrorType.Validation)]
    [InlineData(ErrorType.Unauthorized)]
    [InlineData(ErrorType.Forbidden)]
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
}
