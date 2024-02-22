using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void OrElse_Should_ReturnFirstMaybeIfHasValue()
    {
        // Arrange
        Maybe<int> intMaybe = Maybe<int>
            .With(IntValue)
            .OrElse(5);

        Maybe<string> stringMaybe = Maybe<string>
            .With(StringValue)
            .OrElse("Default");

        Maybe<bool> boolMaybe = Maybe<bool>
            .With(BoolValue)
            .OrElse(true);

        Maybe<byte> byteMaybe = Maybe<byte>
            .With(ByteValue)
            .OrElse(1);

        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>
            .With(DateTimeValue)
            .OrElse(DateTimeOffset.Now);

        Maybe<TestObject> testObjectMaybe = Maybe<TestObject>
            .With(TestObjectValue)
            .OrElse(new TestObject("Default"));

        // Act & Assert
        intMaybe.ShouldHasValue(IntValue);
        stringMaybe.ShouldHasValue(StringValue);
        boolMaybe.ShouldHasValue(BoolValue);
        byteMaybe.ShouldHasValue(ByteValue);
        dateTimeMaybe.ShouldHasValue(DateTimeValue);
        testObjectMaybe.ShouldHasValue(TestObjectValue);
    }

    [Fact]
    public void OrElse_Should_ReturnSecondMaybeIfHasNoValue()
    {
        // Arrange
        var expectedIntValue = 5;
        Maybe<int> intMaybe = Maybe<int>
            .Null
            .OrElse(expectedIntValue);

        var expectedStringValue = "Default";
        Maybe<string> stringMaybe = Maybe<string>
            .Null
            .OrElse(expectedStringValue);

        var expectedBoolValue = true;
        Maybe<bool> boolMaybe = Maybe<bool>
            .Null
            .OrElse(expectedBoolValue);

        var expectedByteValue = (byte)0x0E;
        Maybe<byte> byteMaybe = Maybe<byte>
            .Null
            .OrElse(expectedByteValue);

        var now = DateTimeOffset.Now;
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>
            .Null
            .OrElse(now);

        var defaultObject = new TestObject("Default");
        Maybe<TestObject> testObjectMaybe = Maybe<TestObject>
            .Null
            .OrElse(defaultObject);

        // Act & Assert
        intMaybe.ShouldHasValue(expectedIntValue);
        stringMaybe.ShouldHasValue(expectedStringValue);
        boolMaybe.ShouldHasValue(expectedBoolValue);
        byteMaybe.ShouldHasValue(expectedByteValue);
        dateTimeMaybe.ShouldHasValue(now);
        testObjectMaybe.ShouldHasValue(defaultObject);
    }
}

