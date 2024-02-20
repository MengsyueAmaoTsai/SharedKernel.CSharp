using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;
using RichillCapital.SharedKernel.UnitTests.Monad.Common.Assertions;

public sealed partial class ErrorOrTests : MonadTests
{
    [Fact]
    public void Is_Should_CreateErrorOrWithValue()
    {
        // Arrange & Act
        ErrorOr<int> intErrorOr = ErrorOr.Is(IntValue);
        ErrorOr<string> stringErrorOr = ErrorOr.Is(StringValue);
        ErrorOr<bool> boolErrorOr = ErrorOr.Is(BoolValue);
        ErrorOr<byte> byteErrorOr = ErrorOr.Is(ByteValue);
        ErrorOr<DateTimeOffset> dateTimeErrorOr = ErrorOr.Is(DateTimeValue);
        ErrorOr<TestObject> objectErrorOr = ErrorOr.Is(TestObjectValue);

        // Assert
        intErrorOr.ShouldBeValue(IntValue);
        stringErrorOr.ShouldBeValue(StringValue);
        boolErrorOr.ShouldBeValue(BoolValue);
        byteErrorOr.ShouldBeValue(ByteValue);
        dateTimeErrorOr.ShouldBeValue(DateTimeValue);
        objectErrorOr.ShouldBeValue(TestObjectValue);
    }

    [Fact]
    public void From_Should_CreateErrorOrWithErrors()
    {
        // Arrange & Act
        var errors = new[]
        {
            TestError,
            Error.Invalid("error1"),
            Error.NotFound("error2"),
            Error.Conflict("error3"),
        };
        ErrorOr<int> intErrorOr = ErrorOr.From<int>(errors);
        ErrorOr<string> stringErrorOr = ErrorOr.From<string>(errors);
        ErrorOr<bool> boolErrorOr = ErrorOr.From<bool>(errors);
        ErrorOr<byte> byteErrorOr = ErrorOr.From<byte>(errors);
        ErrorOr<DateTimeOffset> dateTimeErrorOr = ErrorOr.From<DateTimeOffset>(errors);
        ErrorOr<TestObject> objectErrorOr = ErrorOr.From<TestObject>(errors);

        // Assert
        intErrorOr.ShouldBeErrors(errors);
        stringErrorOr.ShouldBeErrors(errors);
        boolErrorOr.ShouldBeErrors(errors);
        byteErrorOr.ShouldBeErrors(errors);
        dateTimeErrorOr.ShouldBeErrors(errors);
        objectErrorOr.ShouldBeErrors(errors);
    }

    [Fact]
    public void From_Should_CreateErrorOrWithError()
    {
        // Arrange & Act
        ErrorOr<int> intErrorOr = ErrorOr.From<int>(TestError);
        ErrorOr<string> stringErrorOr = ErrorOr.From<string>(TestError);
        ErrorOr<bool> boolErrorOr = ErrorOr.From<bool>(TestError);
        ErrorOr<byte> byteErrorOr = ErrorOr.From<byte>(TestError);
        ErrorOr<DateTimeOffset> dateTimeErrorOr = ErrorOr.From<DateTimeOffset>(TestError);
        ErrorOr<TestObject> objectErrorOr = ErrorOr.From<TestObject>(TestError);

        // Assert
        intErrorOr.ShouldBeErrors([TestError]);
        stringErrorOr.ShouldBeErrors([TestError]);
        boolErrorOr.ShouldBeErrors([TestError]);
        byteErrorOr.ShouldBeErrors([TestError]);
        dateTimeErrorOr.ShouldBeErrors([TestError]);
        objectErrorOr.ShouldBeErrors([TestError]);
    }
}