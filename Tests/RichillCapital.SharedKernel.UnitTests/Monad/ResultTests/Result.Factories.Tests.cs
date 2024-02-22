using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class ResultTests : MonadTests
{
    [Fact]
    public void Success_Should_CreateSuccessResult()
    {
        // Arrange & Act
        var result = Result.Success();

        // Assert
        result.ShouldBeSuccessResult();
    }

    [Fact]
    public void Success_Should_CreateSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> intResult = Result.Success(IntValue);
        Result<string> stringResult = Result.Success(StringValue);
        Result<bool> boolResult = Result.Success(BoolValue);
        Result<byte> byteResult = Result.Success(ByteValue);
        Result<DateTimeOffset> dateTimeResult = Result.Success(DateTimeValue);
        Result<TestObject> objectResult = Result.Success(TestObjectValue);

        // Assert
        intResult.ShouldBeSuccessResultWithValue(IntValue);
        stringResult.ShouldBeSuccessResultWithValue(StringValue);
        boolResult.ShouldBeSuccessResultWithValue(BoolValue);
        byteResult.ShouldBeSuccessResultWithValue(ByteValue);
        dateTimeResult.ShouldBeSuccessResultWithValue(DateTimeValue);
        objectResult.ShouldBeSuccessResultWithValue(TestObjectValue);
    }

    [Fact]
    public void Failure_Should_CreateFailureResultWithError()
    {
        // Arrange & Act
        var result = Result.Failure(TestError);

        // Assert
        result.ShouldBeFailureResultWithError(TestError);
    }
}