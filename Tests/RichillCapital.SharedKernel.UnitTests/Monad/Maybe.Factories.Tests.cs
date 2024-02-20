using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;
using RichillCapital.SharedKernel.UnitTests.Monad.Common.Assertions;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class MaybeTests : MonadTests
{
    [Fact]
    public void With_Should_ReturnMaybeWithValue()
    {
        // Arrange & Act
        Maybe<int> intMaybe = Maybe.With(IntValue);
        Maybe<string> stringMaybe = Maybe.With(StringValue);
        Maybe<bool> boolMaybe = Maybe.With(BoolValue);
        Maybe<byte> byteMaybe = Maybe.With(ByteValue);
        Maybe<DateTimeOffset> dateTimeOffsetMaybe = Maybe.With(DateTimeValue);
        Maybe<TestObject> testObjectMaybe = Maybe.With(TestObjectValue);

        // Assert
        intMaybe.ShouldBeMaybeHasValue(IntValue);
        stringMaybe.ShouldBeMaybeHasValue(StringValue);
        boolMaybe.ShouldBeMaybeHasValue(BoolValue);
        byteMaybe.ShouldBeMaybeHasValue(ByteValue);
        dateTimeOffsetMaybe.ShouldBeMaybeHasValue(DateTimeValue);
        testObjectMaybe.ShouldBeMaybeHasValue(TestObjectValue);
    }
}