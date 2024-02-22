using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Map_Should_ReturnErrorOrWithValue_When_ErrorOrIsValue()
    {
        // Arrange
        ErrorOr<int> errorOrInt = ErrorOr<int>.Is(IntValue);
        ErrorOr<string> errorOrString = ErrorOr<string>.Is(StringValue);
        ErrorOr<bool> errorOrBool = ErrorOr<bool>.Is(BoolValue);
        ErrorOr<byte> errorOrByte = ErrorOr<byte>.Is(ByteValue);
        ErrorOr<DateTimeOffset> errorOrDateTime = ErrorOr<DateTimeOffset>.Is(DateTimeValue);
        ErrorOr<TestObject> errorOrObject = ErrorOr<TestObject>.Is(TestObjectValue);

        // Act
        ErrorOr<int> mappedErrorOrInt = errorOrInt.Map(value => value + 1);
        ErrorOr<string> mappedErrorOrString = errorOrString.Map(value => value + "1");
        ErrorOr<bool> mappedErrorOrBool = errorOrBool.Map(value => !value);
        ErrorOr<byte> mappedErrorOrByte = errorOrByte.Map(value => (byte)(value + 1));
        ErrorOr<DateTimeOffset> mappedErrorOrDateTime = errorOrDateTime
            .Map(value => value.AddDays(1));

        ErrorOr<TestObject> mappedErrorOrObject = errorOrObject
            .Map(value => new TestObject(value.Name + "1"));

        // Assert
        mappedErrorOrInt.ShouldBeValue(IntValue + 1);
        mappedErrorOrString.ShouldBeValue(StringValue + "1");
        mappedErrorOrBool.ShouldBeValue(!BoolValue);
        mappedErrorOrByte.ShouldBeValue((byte)(ByteValue + 1));
        mappedErrorOrDateTime.ShouldBeValue(DateTimeValue.AddDays(1));
        mappedErrorOrObject.ShouldBeValue(new TestObject(TestObjectValue.Name + "1"));
    }

    [Fact]
    public void Map_Should_ReturnErrorOrWithError_When_ErrorOrIsError()
    {
        // Arrange
        ErrorOr<int> errorOrInt = ErrorOr<int>.From(TestError);
        ErrorOr<string> errorOrString = ErrorOr<string>.From(TestError);
        ErrorOr<bool> errorOrBool = ErrorOr<bool>.From(TestError);
        ErrorOr<byte> errorOrByte = ErrorOr<byte>.From(TestError);
        ErrorOr<DateTimeOffset> errorOrDateTime = ErrorOr<DateTimeOffset>.From(TestError);
        ErrorOr<TestObject> errorOrObject = ErrorOr<TestObject>.From(TestError);

        // Act
        ErrorOr<int> mappedErrorOrInt = errorOrInt.Map(value => value + 1);
        ErrorOr<string> mappedErrorOrString = errorOrString.Map(value => value + "1");
        ErrorOr<bool> mappedErrorOrBool = errorOrBool.Map(value => !value);
        ErrorOr<byte> mappedErrorOrByte = errorOrByte.Map(value => (byte)(value + 1));
        ErrorOr<DateTimeOffset> mappedErrorOrDateTime = errorOrDateTime
            .Map(value => value.AddDays(1));

        ErrorOr<TestObject> mappedErrorOrObject = errorOrObject
            .Map(value => new TestObject(value.Name + "1"));

        // Assert
        mappedErrorOrInt.ShouldBeErrors([TestError]);
        mappedErrorOrString.ShouldBeErrors([TestError]);
        mappedErrorOrBool.ShouldBeErrors([TestError]);
        mappedErrorOrByte.ShouldBeErrors([TestError]);
        mappedErrorOrDateTime.ShouldBeErrors([TestError]);
        mappedErrorOrObject.ShouldBeErrors([TestError]);
    }
}