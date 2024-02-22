using FluentAssertions;

using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
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