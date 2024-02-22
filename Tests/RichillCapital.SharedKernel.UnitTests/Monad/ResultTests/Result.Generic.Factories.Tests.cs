using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Success_Should_CreateSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> intResult = Result<int>.Success(IntValue);
        Result<string> stringResult = Result<string>.Success(StringValue);
        Result<bool> boolResult = Result<bool>.Success(BoolValue);
        Result<byte> byteResult = Result<byte>.Success(ByteValue);
        Result<DateTimeOffset> dateTimeResult = Result<DateTimeOffset>.Success(DateTimeValue);
        Result<TestObject> objectResult = Result<TestObject>.Success(TestObjectValue);

        // Assert
        intResult.ShouldBeSuccessResultWithValue(IntValue);
        stringResult.ShouldBeSuccessResultWithValue(StringValue);
        boolResult.ShouldBeSuccessResultWithValue(BoolValue);
        byteResult.ShouldBeSuccessResultWithValue(ByteValue);
        dateTimeResult.ShouldBeSuccessResultWithValue(DateTimeValue);
        objectResult.ShouldBeSuccessResultWithValue(TestObjectValue);
    }

    [Fact]
    public void Failure_Should_CreateFailureResultWithErrorMessage()
    {
        // Arrange & Act
        Result<int> intResult = Result<int>.Failure(TestError);
        Result<string> stringResult = Result<string>.Failure(TestError);
        Result<bool> boolResult = Result<bool>.Failure(TestError);
        Result<byte> byteResult = Result<byte>.Failure(TestError);
        Result<DateTimeOffset> dateTimeResult = Result<DateTimeOffset>.Failure(TestError);
        Result<TestObject> objectResult = Result<TestObject>.Failure(TestError);

        // Assert
        intResult.ShouldBeFailureResultWithError(TestError);
        stringResult.ShouldBeFailureResultWithError(TestError);
        boolResult.ShouldBeFailureResultWithError(TestError);
        byteResult.ShouldBeFailureResultWithError(TestError);
        dateTimeResult.ShouldBeFailureResultWithError(TestError);
        objectResult.ShouldBeFailureResultWithError(TestError);
    }
}