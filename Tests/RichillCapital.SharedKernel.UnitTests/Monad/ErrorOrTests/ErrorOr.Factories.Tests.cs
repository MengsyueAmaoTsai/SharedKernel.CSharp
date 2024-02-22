using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

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

    [Fact]
    public void Ensure_Should_CreateErrorOrWithValue()
    {
        // Arrange & Act
        ErrorOr<int> intErrorOr = ErrorOr.Ensure(IntValue, _ => true, TestError);
        ErrorOr<string> stringErrorOr = ErrorOr.Ensure(StringValue, _ => true, TestError);
        ErrorOr<bool> boolErrorOr = ErrorOr.Ensure(BoolValue, _ => true, TestError);
        ErrorOr<byte> byteErrorOr = ErrorOr.Ensure(ByteValue, _ => true, TestError);
        ErrorOr<DateTimeOffset> dateTimeErrorOr = ErrorOr.Ensure(DateTimeValue, _ => true, TestError);
        ErrorOr<TestObject> objectErrorOr = ErrorOr.Ensure(TestObjectValue, _ => true, TestError);

        // Assert
        intErrorOr.ShouldBeValue(IntValue);
        stringErrorOr.ShouldBeValue(StringValue);
        boolErrorOr.ShouldBeValue(BoolValue);
        byteErrorOr.ShouldBeValue(ByteValue);
        dateTimeErrorOr.ShouldBeValue(DateTimeValue);
        objectErrorOr.ShouldBeValue(TestObjectValue);
    }

    [Fact]
    public void Ensure_Should_CreateErrorOrWithError()
    {
        // Arrange & Act
        ErrorOr<int> intErrorOr = ErrorOr.Ensure(IntValue, _ => false, TestError);
        ErrorOr<string> stringErrorOr = ErrorOr.Ensure(StringValue, _ => false, TestError);
        ErrorOr<bool> boolErrorOr = ErrorOr.Ensure(BoolValue, _ => false, TestError);
        ErrorOr<byte> byteErrorOr = ErrorOr.Ensure(ByteValue, _ => false, TestError);
        ErrorOr<DateTimeOffset> dateTimeErrorOr = ErrorOr.Ensure(DateTimeValue, _ => false, TestError);
        ErrorOr<TestObject> objectErrorOr = ErrorOr.Ensure(TestObjectValue, _ => false, TestError);

        // Assert
        intErrorOr.ShouldBeErrors([TestError]);
        stringErrorOr.ShouldBeErrors([TestError]);
        boolErrorOr.ShouldBeErrors([TestError]);
        byteErrorOr.ShouldBeErrors([TestError]);
        dateTimeErrorOr.ShouldBeErrors([TestError]);
        objectErrorOr.ShouldBeErrors([TestError]);
    }

    [Fact]
    public void Combine_Should_CreateErrorOrWithValue()
    {
        // Arrange & Act
        ErrorOr<int> intErrorOr = ErrorOr.Combine(
            ErrorOr.Is(IntValue),
            ErrorOr.Is(IntValue),
            ErrorOr.Is(IntValue),
            ErrorOr.Is(IntValue));

        ErrorOr<string> stringErrorOr = ErrorOr.Combine(
            ErrorOr.Is(StringValue),
            ErrorOr.Is(StringValue),
            ErrorOr.Is(StringValue),
            ErrorOr.Is(StringValue));

        ErrorOr<bool> boolErrorOr = ErrorOr.Combine(
            ErrorOr.Is(BoolValue),
            ErrorOr.Is(BoolValue),
            ErrorOr.Is(BoolValue),
            ErrorOr.Is(BoolValue));

        ErrorOr<byte> byteErrorOr = ErrorOr.Combine(
            ErrorOr.Is(ByteValue),
            ErrorOr.Is(ByteValue),
            ErrorOr.Is(ByteValue),
            ErrorOr.Is(ByteValue));

        ErrorOr<DateTimeOffset> dateTimeErrorOr = ErrorOr.Combine(
            ErrorOr.Is(DateTimeValue),
            ErrorOr.Is(DateTimeValue),
            ErrorOr.Is(DateTimeValue),
            ErrorOr.Is(DateTimeValue));

        ErrorOr<TestObject> objectErrorOr = ErrorOr.Combine(
            ErrorOr.Is(TestObjectValue),
            ErrorOr.Is(TestObjectValue),
            ErrorOr.Is(TestObjectValue),
            ErrorOr.Is(TestObjectValue));

        // Assert
        intErrorOr.ShouldBeValue(IntValue);
        stringErrorOr.ShouldBeValue(StringValue);
        boolErrorOr.ShouldBeValue(BoolValue);
        byteErrorOr.ShouldBeValue(ByteValue);
        dateTimeErrorOr.ShouldBeValue(DateTimeValue);
        objectErrorOr.ShouldBeValue(TestObjectValue);
    }

    [Fact]
    public void Combine_Should_CreateErrorOrWithErrors()
    {
        // Arrange & Act
        ErrorOr<int> intErrorOr = ErrorOr.Combine(
            ErrorOr<int>.From(TestError),
            ErrorOr<int>.From(TestError),
            ErrorOr<int>.From(TestError),
            ErrorOr<int>.From(TestError));

        ErrorOr<string> stringErrorOr = ErrorOr.Combine(
            ErrorOr<string>.From(TestError),
            ErrorOr<string>.From(TestError),
            ErrorOr<string>.From(TestError),
            ErrorOr<string>.From(TestError));

        ErrorOr<bool> boolErrorOr = ErrorOr.Combine(
            ErrorOr<bool>.From(TestError),
            ErrorOr<bool>.From(TestError),
            ErrorOr<bool>.From(TestError),
            ErrorOr<bool>.From(TestError));

        ErrorOr<byte> byteErrorOr = ErrorOr.Combine(
            ErrorOr<byte>.From(TestError),
            ErrorOr<byte>.From(TestError),
            ErrorOr<byte>.From(TestError),
            ErrorOr<byte>.From(TestError));

        ErrorOr<DateTimeOffset> dateTimeErrorOr = ErrorOr.Combine(
            ErrorOr<DateTimeOffset>.From(TestError),
            ErrorOr<DateTimeOffset>.From(TestError),
            ErrorOr<DateTimeOffset>.From(TestError),
            ErrorOr<DateTimeOffset>.From(TestError));

        ErrorOr<TestObject> objectErrorOr = ErrorOr.Combine(
            ErrorOr<TestObject>.From(TestError),
            ErrorOr<TestObject>.From(TestError),
            ErrorOr<TestObject>.From(TestError),
            ErrorOr<TestObject>.From(TestError));

        // Assert
        intErrorOr.ShouldBeErrors([TestError]);
        stringErrorOr.ShouldBeErrors([TestError]);
        boolErrorOr.ShouldBeErrors([TestError]);
        byteErrorOr.ShouldBeErrors([TestError]);
        dateTimeErrorOr.ShouldBeErrors([TestError]);
        objectErrorOr.ShouldBeErrors([TestError]);
    }
}