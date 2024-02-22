using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class MaybeTests : MonadTests
{
    [Fact]
    public void With_When_ValueIsNotNull_Should_ReturnMaybeWithValue()
    {
        // Arrange & Act
        Maybe<int> intMaybe = Maybe.With(IntValue);
        Maybe<string> stringMaybe = Maybe.With(StringValue);
        Maybe<bool> boolMaybe = Maybe.With(BoolValue);
        Maybe<byte> byteMaybe = Maybe.With(ByteValue);
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe.With(DateTimeValue);
        Maybe<TestEntity> testEntityMaybe = Maybe.With(TestEntity);

        // Assert
        intMaybe.ShouldHasValue(IntValue);
        stringMaybe.ShouldHasValue(StringValue);
        boolMaybe.ShouldHasValue(BoolValue);
        byteMaybe.ShouldHasValue(ByteValue);
        dateTimeMaybe.ShouldHasValue(DateTimeValue);
        testEntityMaybe.ShouldHasValue(TestEntity);
    }
}