using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void ImplicitCast_Should_ConvertToErrorOrWithValue()
    {
        // Arrange & Act
        ErrorOr<int> intErrorOr = IntValue;
        ErrorOr<string> stringErrorOr = StringValue;
        ErrorOr<bool> boolErrorOr = BoolValue;
        ErrorOr<byte> byteErrorOr = ByteValue;
        ErrorOr<DateTimeOffset> dateTimeErrorOr = DateTimeValue;
        ErrorOr<TestObject> objectErrorOr = TestObjectValue;

        // Assert
        intErrorOr.ShouldBeValue(IntValue);
        stringErrorOr.ShouldBeValue(StringValue);
        boolErrorOr.ShouldBeValue(BoolValue);
        byteErrorOr.ShouldBeValue(ByteValue);
        dateTimeErrorOr.ShouldBeValue(DateTimeValue);
        objectErrorOr.ShouldBeValue(TestObjectValue);
    }

    [Fact]
    public void ImplicitCast_Should_CovertToErrorOrWithError()
    {
        // Arrange & Act
        ErrorOr<int> intErrorOr = TestError;
        ErrorOr<string> stringErrorOr = TestError;
        ErrorOr<bool> boolErrorOr = TestError;
        ErrorOr<byte> byteErrorOr = TestError;
        ErrorOr<DateTimeOffset> dateTimeErrorOr = TestError;
        ErrorOr<TestObject> objectErrorOr = TestError;

        // Assert
        intErrorOr.ShouldBeErrors([TestError]);
        stringErrorOr.ShouldBeErrors([TestError]);
        boolErrorOr.ShouldBeErrors([TestError]);
        byteErrorOr.ShouldBeErrors([TestError]);
        dateTimeErrorOr.ShouldBeErrors([TestError]);
        objectErrorOr.ShouldBeErrors([TestError]);
    }

    [Fact]
    public void ImplicitOperator_Should_CovertToErrorOrWithErrors()
    {
        // Arrange & Act
        List<Error> errors = [
            TestError,
            Error.Invalid("error1"),
            Error.NotFound("error2"),
            Error.Conflict("error3"),
        ];

        ErrorOr<int> intErrorOr = errors;
        ErrorOr<string> stringErrorOr = errors;
        ErrorOr<bool> boolErrorOr = errors;
        ErrorOr<byte> byteErrorOr = errors;
        ErrorOr<DateTimeOffset> dateTimeErrorOr = errors;
        ErrorOr<TestObject> objectErrorOr = errors;

        // Assert
        intErrorOr.ShouldBeErrors(errors);
        stringErrorOr.ShouldBeErrors(errors);
        boolErrorOr.ShouldBeErrors(errors);
        byteErrorOr.ShouldBeErrors(errors);
        dateTimeErrorOr.ShouldBeErrors(errors);
        objectErrorOr.ShouldBeErrors(errors);
    }
}