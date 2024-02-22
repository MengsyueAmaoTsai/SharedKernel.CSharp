
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Success_When_ValueIsProvided_Should_CreateSuccessResultWithProvidedValue()
    {
        // Arrange & Act
        var intResult = Result<int>.Success(IntValue);
        var stringValueResult = Result<string>.Success(StringValue);
        var boolResult = Result<bool>.Success(BoolValue);
        var byteResult = Result<byte>.Success(ByteValue);
        var dateTimeResult = Result<DateTimeOffset>.Success(DateTimeValue);
        var testEntityResult = Result<TestEntity>.Success(TestEntity);

        // Assert
        intResult.ShouldBeSuccessResultWithValue(IntValue);
        stringValueResult.ShouldBeSuccessResultWithValue(StringValue);
        boolResult.ShouldBeSuccessResultWithValue(BoolValue);
        byteResult.ShouldBeSuccessResultWithValue(ByteValue);
        dateTimeResult.ShouldBeSuccessResultWithValue(DateTimeValue);
        testEntityResult.ShouldBeSuccessResultWithValue(TestEntity);
    }

    [Fact]
    public void Failure_When_ValueIsProvided_Should_CreateFailureResultWithProvidedError()
    {
        // Arrange & Act
        var intResult = Result<int>.Failure(TestError);
        var stringValueResult = Result<string>.Failure(TestError);
        var boolResult = Result<bool>.Failure(TestError);
        var byteResult = Result<byte>.Failure(TestError);
        var dateTimeResult = Result<DateTimeOffset>.Failure(TestError);
        var testEntityResult = Result<TestEntity>.Failure(TestError);

        // Assert
        intResult.ShouldBeFailureResultWithError(TestError);
        stringValueResult.ShouldBeFailureResultWithError(TestError);
        boolResult.ShouldBeFailureResultWithError(TestError);
        byteResult.ShouldBeFailureResultWithError(TestError);
        dateTimeResult.ShouldBeFailureResultWithError(TestError);
        testEntityResult.ShouldBeFailureResultWithError(TestError);
    }
}