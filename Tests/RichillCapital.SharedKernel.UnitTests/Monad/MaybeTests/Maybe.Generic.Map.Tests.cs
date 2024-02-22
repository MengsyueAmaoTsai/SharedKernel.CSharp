using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void Map_Should_ReturnMaybeWithValue_WhenHasValue()
    {
        // Arrange
        Maybe<int> intMaybe = Maybe<int>.With(IntValue);
        Maybe<string> stringMaybe = Maybe<string>.With(StringValue);
        Maybe<bool> boolMaybe = Maybe<bool>.With(BoolValue);
        Maybe<byte> byteMaybe = Maybe<byte>.With(ByteValue);
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<TestObject> testObjectMaybe = Maybe<TestObject>.With(TestObjectValue);

        // Act
        Maybe<int> mappedIntMaybe = intMaybe.Map(value => value * 2);
        Maybe<string> mappedStringMaybe = stringMaybe.Map(value => value.ToUpper());
        Maybe<bool> mappedBoolMaybe = boolMaybe.Map(value => !value);
        Maybe<byte> mappedByteMaybe = byteMaybe.Map(value => (byte)(value * 2));
        Maybe<DateTimeOffset> mappedDateTimeMaybe = dateTimeMaybe.Map(value => value.AddDays(1));
        Maybe<TestObject> mappedTestObjectMaybe = testObjectMaybe.Map(value => new TestObject(value.Name.ToUpper()));

        // Assert
        mappedIntMaybe.ShouldBeMaybeHasValue(IntValue * 2);
        mappedStringMaybe.ShouldBeMaybeHasValue(StringValue.ToUpper());
        mappedBoolMaybe.ShouldBeMaybeHasValue(!BoolValue);
        mappedByteMaybe.ShouldBeMaybeHasValue((byte)(ByteValue * 2));
        mappedDateTimeMaybe.ShouldBeMaybeHasValue(DateTimeValue.AddDays(1));
        mappedTestObjectMaybe.ShouldBeMaybeHasValue(new TestObject(TestObjectValue.Name.ToUpper()));
    }

    [Fact]
    public void Map_Should_ReturnMaybeWithNoValue_WhenHasNoValue()
    {
        // Arrange
        Maybe<int> intMaybe = Maybe<int>.Null;
        Maybe<string> stringMaybe = Maybe<string>.Null;
        Maybe<bool> boolMaybe = Maybe<bool>.Null;
        Maybe<byte> byteMaybe = Maybe<byte>.Null;
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.Null;
        Maybe<TestObject> testObjectMaybe = Maybe<TestObject>.Null;

        // Act
        Maybe<int> mappedIntMaybe = intMaybe.Map(value => value * 2);
        Maybe<string> mappedStringMaybe = stringMaybe.Map(value => value.ToUpper());
        Maybe<bool> mappedBoolMaybe = boolMaybe.Map(value => !value);
        Maybe<byte> mappedByteMaybe = byteMaybe.Map(value => (byte)(value * 2));
        Maybe<DateTimeOffset> mappedDateTimeMaybe = dateTimeMaybe.Map(value => value.AddDays(1));
        Maybe<TestObject> mappedTestObjectMaybe = testObjectMaybe.Map(value => new TestObject(value.Name.ToUpper()));

        // Assert
        mappedIntMaybe.ShouldBeMaybeHasNoValue();
        mappedStringMaybe.ShouldBeMaybeHasNoValue();
        mappedBoolMaybe.ShouldBeMaybeHasNoValue();
        mappedByteMaybe.ShouldBeMaybeHasNoValue();
        mappedDateTimeMaybe.ShouldBeMaybeHasNoValue();
        mappedTestObjectMaybe.ShouldBeMaybeHasNoValue();
    }
}

