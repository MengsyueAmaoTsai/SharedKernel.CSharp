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
        var successResult = Result.Success();

        // Assert
        successResult.ShouldBeSuccessResult();
    }

    [Fact]
    public void Failure_Should_CreateFailureResult()
    {
        // Arrange & Act
        var failureResult = Result.Failure(TestError);

        // Assert
        failureResult.ShouldBeFailureResultWithError(TestError);
    }

    [Fact]
    public void Success_When_ValueIsProvided_Should_CreateSuccessResultWithProvidedValue()
    {
        // Arrange & Act
        var intResult = Result.Success(IntValue);
        var stringValueResult = Result.Success(StringValue);
        var boolResult = Result.Success(BoolValue);
        var byteResult = Result.Success(ByteValue);
        var dateTimeResult = Result.Success(DateTimeValue);
        var testEntityResult = Result.Success(TestEntity);

        // Assert
        intResult.ShouldBeSuccessResultWithValue(IntValue);
        stringValueResult.ShouldBeSuccessResultWithValue(StringValue);
        boolResult.ShouldBeSuccessResultWithValue(BoolValue);
        byteResult.ShouldBeSuccessResultWithValue(ByteValue);
        dateTimeResult.ShouldBeSuccessResultWithValue(DateTimeValue);
        testEntityResult.ShouldBeSuccessResultWithValue(TestEntity);
    }

    [Fact]
    public void Ensure_When_PredicateIsTrue_Should_CreateSuccessResultWithProvidedValue()
    {
        // Arrange & Act
        var intResult = Result.Ensure(IntValue, _ => true, TestError);
        var stringValueResult = Result.Ensure(StringValue, _ => true, TestError);
        var boolResult = Result.Ensure(BoolValue, _ => true, TestError);
        var byteResult = Result.Ensure(ByteValue, _ => true, TestError);
        var dateTimeResult = Result.Ensure(DateTimeValue, _ => true, TestError);
        var testEntityResult = Result.Ensure(TestEntity, _ => true, TestError);

        // Assert
        intResult.ShouldBeSuccessResultWithValue(IntValue);
        stringValueResult.ShouldBeSuccessResultWithValue(StringValue);
        boolResult.ShouldBeSuccessResultWithValue(BoolValue);
        byteResult.ShouldBeSuccessResultWithValue(ByteValue);
        dateTimeResult.ShouldBeSuccessResultWithValue(DateTimeValue);
        testEntityResult.ShouldBeSuccessResultWithValue(TestEntity);
    }

    [Fact]
    public void Ensure_When_PredicateIsFalse_Should_CreateFailureResultWithProvidedError()
    {
        // Arrange & Act
        var intResult = Result.Ensure(IntValue, _ => false, TestError);
        var stringValueResult = Result.Ensure(StringValue, _ => false, TestError);
        var boolResult = Result.Ensure(BoolValue, _ => false, TestError);
        var byteResult = Result.Ensure(ByteValue, _ => false, TestError);
        var dateTimeResult = Result.Ensure(DateTimeValue, _ => false, TestError);
        var testEntityResult = Result.Ensure(TestEntity, _ => false, TestError);

        // Assert
        intResult.ShouldBeFailureResultWithError(TestError);
        stringValueResult.ShouldBeFailureResultWithError(TestError);
        boolResult.ShouldBeFailureResultWithError(TestError);
        byteResult.ShouldBeFailureResultWithError(TestError);
        dateTimeResult.ShouldBeFailureResultWithError(TestError);
        testEntityResult.ShouldBeFailureResultWithError(TestError);
    }
}