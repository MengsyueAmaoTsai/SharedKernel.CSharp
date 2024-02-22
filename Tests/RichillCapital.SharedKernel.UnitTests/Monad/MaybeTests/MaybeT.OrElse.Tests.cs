
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void OrElse_When_MaybeHasValue_Should_ReturnOriginalValue()
    {
        // Arrange
        Maybe<int> intMaybe = Maybe<int>.With(IntValue);
        Maybe<string> stringMaybe = Maybe<string>.With(StringValue);
        Maybe<bool> boolMaybe = Maybe<bool>.With(BoolValue);
        Maybe<byte> byteMaybe = Maybe<byte>.With(ByteValue);
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<TestEntity> testEntityMaybe = Maybe<TestEntity>.With(TestEntity);

        var anotherIntValue = 100;
        var anotherStringValue = "Another";
        var anotherBoolValue = true;
        var anotherByteValue = (byte)100;
        var anotherDateTimeValue = DateTimeOffset.Now;
        var anotherTestEntity = new TestEntity(new TestEntityId(1), "2");

        // Act
        Maybe<int> intOrElse = intMaybe.OrElse(anotherIntValue);
        Maybe<string> stringOrElse = stringMaybe.OrElse(anotherStringValue);
        Maybe<bool> boolOrElse = boolMaybe.OrElse(anotherBoolValue);
        Maybe<byte> byteOrElse = byteMaybe.OrElse(anotherByteValue);
        Maybe<DateTimeOffset> dateTimeOrElse = dateTimeMaybe.OrElse(anotherDateTimeValue);
        Maybe<TestEntity> testEntityOrElse = testEntityMaybe.OrElse(anotherTestEntity);

        // Assert
        intOrElse.ShouldHasValue(IntValue);
        stringOrElse.ShouldHasValue(StringValue);
        boolOrElse.ShouldHasValue(BoolValue);
        byteOrElse.ShouldHasValue(ByteValue);
        dateTimeOrElse.ShouldHasValue(DateTimeValue);
        testEntityOrElse.ShouldHasValue(TestEntity);
    }

    [Fact]
    public void OrElse_When_MaybeHasNoValue_Should_ReturnAlternativeValue()
    {
        // Arrange
        Maybe<int> intMaybe = Maybe<int>.Null;
        Maybe<string> stringMaybe = Maybe<string>.Null;
        Maybe<bool> boolMaybe = Maybe<bool>.Null;
        Maybe<byte> byteMaybe = Maybe<byte>.Null;
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.Null;
        Maybe<TestEntity> testEntityMaybe = Maybe<TestEntity>.Null;

        var anotherIntValue = 100;
        var anotherStringValue = "Another";
        var anotherBoolValue = true;
        var anotherByteValue = (byte)100;
        var anotherDateTimeValue = DateTimeOffset.Now;
        var anotherTestEntity = new TestEntity(new TestEntityId(1), "2");

        // Act
        Maybe<int> intOrElse = intMaybe.OrElse(anotherIntValue);
        Maybe<string> stringOrElse = stringMaybe.OrElse(anotherStringValue);
        Maybe<bool> boolOrElse = boolMaybe.OrElse(anotherBoolValue);
        Maybe<byte> byteOrElse = byteMaybe.OrElse(anotherByteValue);
        Maybe<DateTimeOffset> dateTimeOrElse = dateTimeMaybe.OrElse(anotherDateTimeValue);
        Maybe<TestEntity> testEntityOrElse = testEntityMaybe.OrElse(anotherTestEntity);

        // Assert
        intOrElse.ShouldHasValue(anotherIntValue);
        stringOrElse.ShouldHasValue(anotherStringValue);
        boolOrElse.ShouldHasValue(anotherBoolValue);
        byteOrElse.ShouldHasValue(anotherByteValue);
        dateTimeOrElse.ShouldHasValue(anotherDateTimeValue);
        testEntityOrElse.ShouldHasValue(anotherTestEntity);
    }
}