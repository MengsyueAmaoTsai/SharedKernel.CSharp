
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void ImplicitCast_Should_ConvertErrorToFailureResult()
    {
        // Arrange & Act
        Result<int> intResult = TestError;
        Result<string> stringValueResult = TestError;
        Result<bool> boolResult = TestError;
        Result<byte> byteResult = TestError;
        Result<DateTimeOffset> dateTimeResult = TestError;
        Result<TestEntity> testEntityResult = TestError;

        // Assert
        intResult.ShouldBeFailureResultWithError(TestError);
        stringValueResult.ShouldBeFailureResultWithError(TestError);
        boolResult.ShouldBeFailureResultWithError(TestError);
        byteResult.ShouldBeFailureResultWithError(TestError);
        dateTimeResult.ShouldBeFailureResultWithError(TestError);
        testEntityResult.ShouldBeFailureResultWithError(TestError);
    }

    [Fact]
    public void ImplicitCast_Should_ConvertValueToSuccessResult()
    {
        // Arrange & Act
        Result<int> intResult = IntValue;
        Result<string> stringValueResult = StringValue;
        Result<bool> boolResult = BoolValue;
        Result<byte> byteResult = ByteValue;
        Result<DateTimeOffset> dateTimeResult = DateTimeValue;
        Result<TestEntity> testEntityResult = TestEntity;

        // Assert
        intResult.ShouldBeSuccessResultWithValue(IntValue);
        stringValueResult.ShouldBeSuccessResultWithValue(StringValue);
        boolResult.ShouldBeSuccessResultWithValue(BoolValue);
        byteResult.ShouldBeSuccessResultWithValue(ByteValue);
        dateTimeResult.ShouldBeSuccessResultWithValue(DateTimeValue);
        testEntityResult.ShouldBeSuccessResultWithValue(TestEntity);
    }
}