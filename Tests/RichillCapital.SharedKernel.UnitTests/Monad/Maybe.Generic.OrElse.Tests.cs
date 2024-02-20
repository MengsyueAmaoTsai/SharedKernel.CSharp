using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;
using RichillCapital.SharedKernel.UnitTests.Monad.Common.Assertions;

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
        intMaybe.ShouldBeMaybeHasValue(IntValue);
        stringMaybe.ShouldBeMaybeHasValue(StringValue);
        boolMaybe.ShouldBeMaybeHasValue(BoolValue);
        byteMaybe.ShouldBeMaybeHasValue(ByteValue);
        dateTimeMaybe.ShouldBeMaybeHasValue(DateTimeValue);
        testObjectMaybe.ShouldBeMaybeHasValue(TestObjectValue);
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
        intMaybe.ShouldBeMaybeHasValue(expectedIntValue);
        stringMaybe.ShouldBeMaybeHasValue(expectedStringValue);
        boolMaybe.ShouldBeMaybeHasValue(expectedBoolValue);
        byteMaybe.ShouldBeMaybeHasValue(expectedByteValue);
        dateTimeMaybe.ShouldBeMaybeHasValue(now);
        testObjectMaybe.ShouldBeMaybeHasValue(defaultObject);
    }
}

