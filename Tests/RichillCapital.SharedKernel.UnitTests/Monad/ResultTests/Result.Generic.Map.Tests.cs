using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Map_Should_ReturnSuccessResult_When_ResultIsSuccess()
    {
        // Arrange
        var expectedIntValue = 20;
        Result<int> intResult = Result<int>.Success(IntValue);

        var expectedStringValue = StringValue + "0";
        Result<string> stringResult = Result<string>.Success(StringValue);

        var expectedBoolValue = false;
        Result<bool> boolResult = Result<bool>.Success(BoolValue);

        var expectedByteValue = (byte)(ByteValue * 2);
        Result<byte> byteResult = Result<byte>.Success(ByteValue);

        var expectedDateTimeValue = DateTimeOffset.UtcNow;
        Result<DateTimeOffset> dateTimeResult = Result<DateTimeOffset>.Success(DateTimeValue);

        var expectedObjectValue = new TestObject(TestObjectValue.Name + "0");
        Result<TestObject> objectResult = Result<TestObject>.Success(TestObjectValue);

        // Act
        var mappedIntResult = intResult.Map(value => value * 2);
        var mappedStringResult = stringResult.Map(value => value + "0");
        var mappedBoolResult = boolResult.Map(value => !value);
        var mappedByteResult = byteResult.Map(value => (byte)(value * 2));
        var mappedDateTimeResult = dateTimeResult.Map(_ => expectedDateTimeValue);
        var mappedObjectResult = objectResult.Map(value => new TestObject(value.Name + "0"));

        // Assert
        mappedIntResult.ShouldBeSuccessResultWithValue(expectedIntValue);
        mappedStringResult.ShouldBeSuccessResultWithValue(expectedStringValue);
        mappedBoolResult.ShouldBeSuccessResultWithValue(expectedBoolValue);
        mappedByteResult.ShouldBeSuccessResultWithValue(expectedByteValue);
        mappedDateTimeResult.ShouldBeSuccessResultWithValue(expectedDateTimeValue);
        mappedObjectResult.ShouldBeSuccessResultWithValue(expectedObjectValue);
    }
}