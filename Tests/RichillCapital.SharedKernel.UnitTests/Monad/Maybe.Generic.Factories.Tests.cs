using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;
using RichillCapital.SharedKernel.UnitTests.Monad.Common.Assertions;

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
        intMaybe.ShouldBeMaybeHasNoValue();
        stringMaybe.ShouldBeMaybeHasNoValue();
        boolMaybe.ShouldBeMaybeHasNoValue();
        byteMaybe.ShouldBeMaybeHasNoValue();
        dateTimeMaybe.ShouldBeMaybeHasNoValue();
        testObjectMaybe.ShouldBeMaybeHasNoValue();
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
        intMaybe.ShouldBeMaybeHasValue(IntValue);
        stringMaybe.ShouldBeMaybeHasValue(StringValue);
        boolMaybe.ShouldBeMaybeHasValue(BoolValue);
        byteMaybe.ShouldBeMaybeHasValue(ByteValue);
        dateTimeMaybe.ShouldBeMaybeHasValue(DateTimeValue);
        testObjectMaybe.ShouldBeMaybeHasValue(TestObjectValue);
    }
}

