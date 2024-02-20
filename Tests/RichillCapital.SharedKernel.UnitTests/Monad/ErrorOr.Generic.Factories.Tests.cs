using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;
using RichillCapital.SharedKernel.UnitTests.Monad.Common.Assertions;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Is_Should_CreateErrorOrWithValue()
    {
        // Arrange & Act
        ErrorOr<int> intErrorOr = ErrorOr<int>.Is(IntValue);
        ErrorOr<string> stringErrorOr = ErrorOr<string>.Is(StringValue);
        ErrorOr<bool> boolErrorOr = ErrorOr<bool>.Is(BoolValue);
        ErrorOr<byte> byteErrorOr = ErrorOr<byte>.Is(ByteValue);
        ErrorOr<DateTimeOffset> dateTimeErrorOr = ErrorOr<DateTimeOffset>.Is(DateTimeValue);
        ErrorOr<TestObject> objectErrorOr = ErrorOr<TestObject>.Is(TestObjectValue);

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
        List<Error> errors = [
            TestError,
            Error.Invalid("error1"),
            Error.NotFound("error2"),
            Error.Conflict("error3"),
        ];
        ErrorOr<int> intErrorOr = ErrorOr<int>.From(errors);
        ErrorOr<string> stringErrorOr = ErrorOr<string>.From(errors);
        ErrorOr<bool> boolErrorOr = ErrorOr<bool>.From(errors);
        ErrorOr<byte> byteErrorOr = ErrorOr<byte>.From(errors);
        ErrorOr<DateTimeOffset> dateTimeErrorOr = ErrorOr<DateTimeOffset>.From(errors);
        ErrorOr<TestObject> objectErrorOr = ErrorOr<TestObject>.From(errors);

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
        ErrorOr<int> intErrorOr = ErrorOr<int>.From(TestError);
        ErrorOr<string> stringErrorOr = ErrorOr<string>.From(TestError);
        ErrorOr<bool> boolErrorOr = ErrorOr<bool>.From(TestError);
        ErrorOr<byte> byteErrorOr = ErrorOr<byte>.From(TestError);
        ErrorOr<DateTimeOffset> dateTimeErrorOr = ErrorOr<DateTimeOffset>.From(TestError);
        ErrorOr<TestObject> objectErrorOr = ErrorOr<TestObject>.From(TestError);

        // Assert
        intErrorOr.ShouldBeErrors([TestError]);
        stringErrorOr.ShouldBeErrors([TestError]);
        boolErrorOr.ShouldBeErrors([TestError]);
        byteErrorOr.ShouldBeErrors([TestError]);
        dateTimeErrorOr.ShouldBeErrors([TestError]);
        objectErrorOr.ShouldBeErrors([TestError]);
    }
}