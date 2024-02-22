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
}