using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void Null_Should_ReturnMaybeWithNoValue()
    {
        // Arrange & Act
        Maybe<int> intMaybe = Maybe<int>.Null;
        Maybe<string> stringMaybe = Maybe<string>.Null;
        Maybe<bool> boolMaybe = Maybe<bool>.Null;
        Maybe<byte> byteMaybe = Maybe<byte>.Null;
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.Null;
        Maybe<TestObject> testObjectMaybe = Maybe<TestObject>.Null;

        // Assert
        intMaybe.ShouldHasNoValue();
        stringMaybe.ShouldHasNoValue();
        boolMaybe.ShouldHasNoValue();
        byteMaybe.ShouldHasNoValue();
        dateTimeMaybe.ShouldHasNoValue();
        testObjectMaybe.ShouldHasNoValue();
    }

    [Fact]
    public void With_Should_ReturnMaybeWithValue()
    {
        // Arrange & Act
        Maybe<int> intMaybe = Maybe<int>.With(IntValue);
        Maybe<string> stringMaybe = Maybe<string>.With(StringValue);
        Maybe<bool> boolMaybe = Maybe<bool>.With(BoolValue);
        Maybe<byte> byteMaybe = Maybe<byte>.With(ByteValue);
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<TestObject> testObjectMaybe = Maybe<TestObject>.With(TestObjectValue);

        // Assert
        intMaybe.ShouldHasValue(IntValue);
        stringMaybe.ShouldHasValue(StringValue);
        boolMaybe.ShouldHasValue(BoolValue);
        byteMaybe.ShouldHasValue(ByteValue);
        dateTimeMaybe.ShouldHasValue(DateTimeValue);
        testObjectMaybe.ShouldHasValue(TestObjectValue);
    }
}

