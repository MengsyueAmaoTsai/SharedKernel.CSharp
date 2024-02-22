using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void Map_When_MaybeHasValue_Should_ReturnMappedValue()
    {
        // Arrange
        Maybe<int> intMaybe = Maybe<int>.With(IntValue);
        Maybe<string> stringMaybe = Maybe<string>.With(StringValue);
        Maybe<bool> boolMaybe = Maybe<bool>.With(BoolValue);
        Maybe<byte> byteMaybe = Maybe<byte>.With(ByteValue);
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<TestEntity> testEntityMaybe = Maybe<TestEntity>.With(TestEntity);

        // Act
        Maybe<string> intMapped = intMaybe.Map(value => value.ToString());
        Maybe<int> stringMapped = stringMaybe.Map(value => value.Length);
        Maybe<string> boolMapped = boolMaybe.Map(value => value.ToString());
        Maybe<int> byteMapped = byteMaybe.Map(value => value + 1);
        Maybe<string> dateTimeMapped = dateTimeMaybe.Map(value => value.ToString());
        Maybe<string> testEntityMapped = testEntityMaybe.Map(value => value.Name);

        // Assert
        intMapped.ShouldHasValue(IntValue.ToString());
        stringMapped.ShouldHasValue(StringValue.Length);
        boolMapped.ShouldHasValue(BoolValue.ToString());
        byteMapped.ShouldHasValue(ByteValue + 1);
        dateTimeMapped.ShouldHasValue(DateTimeValue.ToString());
        testEntityMapped.ShouldHasValue(TestEntity.Name);
    }

    [Fact]
    public void Map_When_MaybeHasNoValue_Should_ReturnEmptyMaybe()
    {
        // Arrange
        Maybe<int> intMaybe = Maybe<int>.Null;
        Maybe<string> stringMaybe = Maybe<string>.Null;
        Maybe<bool> boolMaybe = Maybe<bool>.Null;
        Maybe<byte> byteMaybe = Maybe<byte>.Null;
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.Null;
        Maybe<TestEntity> testEntityMaybe = Maybe<TestEntity>.Null;

        // Act
        Maybe<string> intMapped = intMaybe.Map(value => value.ToString());
        Maybe<int> stringMapped = stringMaybe.Map(value => value.Length);
        Maybe<string> boolMapped = boolMaybe.Map(value => value.ToString());
        Maybe<int> byteMapped = byteMaybe.Map(value => value + 1);
        Maybe<string> dateTimeMapped = dateTimeMaybe.Map(value => value.ToString());
        Maybe<string> testEntityMapped = testEntityMaybe.Map(value => value.Name);

        // Assert
        intMapped.ShouldHasNoValue();
        stringMapped.ShouldHasNoValue();
        boolMapped.ShouldHasNoValue();
        byteMapped.ShouldHasNoValue();
        dateTimeMapped.ShouldHasNoValue();
        testEntityMapped.ShouldHasNoValue();
    }
}