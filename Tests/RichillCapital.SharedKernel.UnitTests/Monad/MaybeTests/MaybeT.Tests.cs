using FluentAssertions;

using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void Equals_WhenComparingMaybeWithNull_ShouldReturnFalse()
    {
        // Arrange
        Maybe<int> maybeInt = Maybe<int>.With(IntValue);
        Maybe<string> maybeString = Maybe<string>.With(StringValue);
        Maybe<bool> maybeBool = Maybe<bool>.With(BoolValue);
        Maybe<byte> maybeByte = Maybe<byte>.With(ByteValue);
        Maybe<DateTimeOffset> maybeDateTime = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<TestEntity> maybeTestEntity = Maybe<TestEntity>.With(TestEntity);

        // Act & Assert
        maybeInt.Equals(null).Should().BeFalse();
        maybeString.Equals(null!).Should().BeFalse();
        maybeBool.Equals(null).Should().BeFalse();
        maybeByte.Equals(null).Should().BeFalse();
        maybeDateTime.Equals(null).Should().BeFalse();
        maybeTestEntity.Equals(null!).Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenComparingMaybeWithSameValue_ShouldReturnTrue()
    {
        // Arrange
        Maybe<int> maybeInt = Maybe<int>.With(IntValue);
        Maybe<string> maybeString = Maybe<string>.With(StringValue);
        Maybe<bool> maybeBool = Maybe<bool>.With(BoolValue);
        Maybe<byte> maybeByte = Maybe<byte>.With(ByteValue);
        Maybe<DateTimeOffset> maybeDateTime = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<TestEntity> maybeTestEntity = Maybe<TestEntity>.With(TestEntity);

        var otherMaybeInt = Maybe<int>.With(IntValue);
        var otherMaybeString = Maybe<string>.With(StringValue);
        var otherMaybeBool = Maybe<bool>.With(BoolValue);
        var otherMaybeByte = Maybe<byte>.With(ByteValue);
        var otherMaybeDateTime = Maybe<DateTimeOffset>.With(DateTimeValue);
        var otherMaybeTestEntity = Maybe<TestEntity>.With(TestEntity);

        // Act & Assert
        maybeInt.Equals(otherMaybeInt).Should().BeTrue();
        maybeString.Equals(otherMaybeString).Should().BeTrue();
        maybeBool.Equals(otherMaybeBool).Should().BeTrue();
        maybeByte.Equals(otherMaybeByte).Should().BeTrue();
        maybeDateTime.Equals(otherMaybeDateTime).Should().BeTrue();
        maybeTestEntity.Equals(otherMaybeTestEntity).Should().BeTrue();
    }

    [Fact]
    public void Equals_WhenComparingMaybeWithDifferentType_ShouldReturnFalse()
    {
        // Arrange
        Maybe<int> maybeInt = Maybe<int>.With(IntValue);

        var otherMaybeString = Maybe<string>.With(StringValue);
        var otherMaybeBool = Maybe<bool>.With(BoolValue);
        var otherMaybeByte = Maybe<byte>.With(ByteValue);
        var otherMaybeDateTime = Maybe<DateTimeOffset>.With(DateTimeValue);
        var otherMaybeTestEntity = Maybe<TestEntity>.With(new TestEntity(new TestEntityId(1), "1"));

        // Act & Assert
        maybeInt.Equals(otherMaybeString).Should().BeFalse();
        maybeInt.Equals(otherMaybeBool).Should().BeFalse();
        maybeInt.Equals(otherMaybeByte).Should().BeFalse();
        maybeInt.Equals(otherMaybeDateTime).Should().BeFalse();
        maybeInt.Equals(otherMaybeTestEntity).Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenComparingMaybeWithDifferentValue_ShouldReturnFalse()
    {
        // Arrange
        Maybe<int> maybeInt = Maybe<int>.With(IntValue);
        Maybe<string> maybeString = Maybe<string>.With(StringValue);
        Maybe<bool> maybeBool = Maybe<bool>.With(BoolValue);
        Maybe<byte> maybeByte = Maybe<byte>.With(ByteValue);
        Maybe<DateTimeOffset> maybeDateTime = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<TestEntity> maybeTestEntity = Maybe<TestEntity>.With(TestEntity);

        Maybe<int> otherMaybeInt = Maybe<int>.With(100);
        Maybe<string> otherMaybeString = Maybe<string>.With("Different value");
        Maybe<bool> otherMaybeBool = Maybe<bool>.With(false);
        Maybe<byte> otherMaybeByte = Maybe<byte>.With(100);
        Maybe<DateTimeOffset> otherMaybeDateTime = Maybe<DateTimeOffset>.With(DateTimeOffset.MinValue);
        Maybe<TestEntity> otherMaybeTestEntity = Maybe<TestEntity>.With(new TestEntity(new TestEntityId(2), "1"));

        // Act & Assert
        maybeInt.Equals(otherMaybeInt).Should().BeFalse();
        maybeString.Equals(otherMaybeString).Should().BeFalse();
        maybeBool.Equals(otherMaybeBool).Should().BeFalse();
        maybeByte.Equals(otherMaybeByte).Should().BeFalse();
        maybeDateTime.Equals(otherMaybeDateTime).Should().BeFalse();
        maybeTestEntity.Equals(otherMaybeTestEntity).Should().BeFalse();
    }

    [Fact]
    public void Null_Should_ReturnMaybeWithNoValue()
    {
        // Arrange & Act
        Maybe<int> intMaybe = Maybe<int>.Null;
        Maybe<string> stringMaybe = Maybe<string>.Null;
        Maybe<bool> boolMaybe = Maybe<bool>.Null;
        Maybe<byte> byteMaybe = Maybe<byte>.Null;
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.Null;
        Maybe<TestEntity> testEntityMaybe = Maybe<TestEntity>.Null;

        // Assert
        intMaybe.ShouldHasNoValue();
        stringMaybe.ShouldHasNoValue();
        boolMaybe.ShouldHasNoValue();
        byteMaybe.ShouldHasNoValue();
        dateTimeMaybe.ShouldHasNoValue();
        testEntityMaybe.ShouldHasNoValue();
    }

    [Fact]
    public void Value_When_MaybeHasValue_Should_ReturnValue()
    {
        // Arrange
        Maybe<int> intMaybe = Maybe<int>.With(IntValue);
        Maybe<string> stringMaybe = Maybe<string>.With(StringValue);
        Maybe<bool> boolMaybe = Maybe<bool>.With(BoolValue);
        Maybe<byte> byteMaybe = Maybe<byte>.With(ByteValue);
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<TestEntity> testEntityMaybe = Maybe<TestEntity>.With(TestEntity);

        // Assert
        intMaybe.Value.Should().Be(IntValue);
        stringMaybe.Value.Should().Be(StringValue);
        boolMaybe.Value.Should().Be(BoolValue);
        byteMaybe.Value.Should().Be(ByteValue);
        dateTimeMaybe.Value.Should().Be(DateTimeValue);
        testEntityMaybe.Value.Should().Be(TestEntity);
    }

    [Fact]
    public void Value_When_MaybeHasNoValue_Should_ThrowInvalidOperationException()
    {
        // Arrange
        Maybe<int> intMaybe = Maybe<int>.Null;
        Maybe<string> stringMaybe = Maybe<string>.Null;
        Maybe<bool> boolMaybe = Maybe<bool>.Null;
        Maybe<byte> byteMaybe = Maybe<byte>.Null;
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.Null;
        Maybe<TestEntity> testEntityMaybe = Maybe<TestEntity>.Null;

        // Act & Assert
        intMaybe.Invoking(maybe => maybe.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage($"Maybe<{typeof(int)}> has no value.");

        stringMaybe.Invoking(maybe => maybe.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage($"Maybe<{typeof(string)}> has no value.");

        boolMaybe.Invoking(maybe => maybe.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage($"Maybe<{typeof(bool)}> has no value.");

        byteMaybe.Invoking(maybe => maybe.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage($"Maybe<{typeof(byte)}> has no value.");

        dateTimeMaybe.Invoking(maybe => maybe.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage($"Maybe<{typeof(DateTimeOffset)}> has no value.");

        testEntityMaybe.Invoking(maybe => maybe.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage($"Maybe<{typeof(TestEntity)}> has no value.");
    }

    [Fact]
    public void ValueOrDefault_When_MaybeHasValue_Should_ReturnValue()
    {
        // Arrange
        Maybe<int> intMaybe = Maybe<int>.With(IntValue);
        Maybe<string> stringMaybe = Maybe<string>.With(StringValue);
        Maybe<bool> boolMaybe = Maybe<bool>.With(BoolValue);
        Maybe<byte> byteMaybe = Maybe<byte>.With(ByteValue);
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<TestEntity> testEntityMaybe = Maybe<TestEntity>.With(TestEntity);

        // Assert
        intMaybe.ValueOrDefault.Should().Be(IntValue);
        stringMaybe.ValueOrDefault.Should().Be(StringValue);
        boolMaybe.ValueOrDefault.Should().Be(BoolValue);
        byteMaybe.ValueOrDefault.Should().Be(ByteValue);
        dateTimeMaybe.ValueOrDefault.Should().Be(DateTimeValue);
        testEntityMaybe.ValueOrDefault.Should().Be(TestEntity);
    }

    [Fact]
    public void ValueOrDefault_When_MaybeHasNoValue_Should_ReturnDefaultValue()
    {
        // Arrange
        Maybe<int> intMaybe = Maybe<int>.Null;
        Maybe<string> stringMaybe = Maybe<string>.Null;
        Maybe<bool> boolMaybe = Maybe<bool>.Null;
        Maybe<byte> byteMaybe = Maybe<byte>.Null;
        Maybe<DateTimeOffset> dateTimeMaybe = Maybe<DateTimeOffset>.Null;
        Maybe<TestEntity> testEntityMaybe = Maybe<TestEntity>.Null;

        // Assert
        intMaybe.ValueOrDefault.Should().Be(0);
        stringMaybe.ValueOrDefault.Should().Be(null);
        boolMaybe.ValueOrDefault.Should().Be(false);
        byteMaybe.ValueOrDefault.Should().Be(0);
        dateTimeMaybe.ValueOrDefault.Should().Be(DateTimeOffset.MinValue);
        testEntityMaybe.ValueOrDefault.Should().Be(null);
    }
}