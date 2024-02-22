using FluentAssertions;

using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Equals_When_ComparingErrorOrWithValue_Should_ReturnTrue()
    {
        // Arrange
        var errorOrInt = ErrorOr<int>.Is(IntValue);
        var errorOrString = ErrorOr<string>.Is(StringValue);
        var errorOrBool = ErrorOr<bool>.Is(BoolValue);
        var errorOrByte = ErrorOr<byte>.Is(ByteValue);
        var errorOrDateTime = ErrorOr<DateTimeOffset>.Is(DateTimeValue);
        var errorOrEntity = ErrorOr<TestEntity>.Is(TestEntity);

        // Act & Assert
        errorOrInt.Equals(IntValue).Should().BeTrue();
        errorOrString.Equals(StringValue).Should().BeTrue();
        errorOrBool.Equals(BoolValue).Should().BeTrue();
        errorOrByte.Equals(ByteValue).Should().BeTrue();
        errorOrDateTime.Equals(DateTimeValue).Should().BeTrue();
        errorOrEntity.Equals(TestEntity).Should().BeTrue();
    }

    [Fact]
    public void Equals_When_ComparingWithDifferentValues_Should_ReturnFalse()
    {
        // Arrange
        var errorOrInt = ErrorOr<int>.Is(IntValue);
        var errorOrString = ErrorOr<string>.Is(StringValue);
        var errorOrBool = ErrorOr<bool>.Is(BoolValue);
        var errorOrByte = ErrorOr<byte>.Is(ByteValue);
        var errorOrDateTime = ErrorOr<DateTimeOffset>.Is(DateTimeValue);
        var errorOrEntity = ErrorOr<TestEntity>.Is(TestEntity);

        // Act & Assert
        errorOrInt.Equals(IntValue + 1).Should().BeFalse();
        errorOrString.Equals(StringValue + "1").Should().BeFalse();
        errorOrBool.Equals(!BoolValue).Should().BeFalse();
        errorOrByte.Equals(ByteValue + 1).Should().BeFalse();
        errorOrDateTime.Equals(DateTimeValue.AddDays(1)).Should().BeFalse();
        errorOrEntity.Equals(new TestEntity(new TestEntityId(2), "2")).Should().BeFalse();
    }

    [Fact]
    public void Equals_When_ComparingErrorOrWithDifferentErrors_Should_ReturnFalse()
    {
        // Arrange
        var errorOr = ErrorOr<int>.From(TestError);
        var errorOr2 = ErrorOr<int>.From(Error.Invalid("Different error"));

        // Act & Assert
        errorOr.Equals(errorOr2).Should().BeFalse();
    }

    [Fact]
    public void Value_When_ErrorOrIsValue_Should_ReturnProvidedValue()
    {
        // Arrange
        var errorOrInt = ErrorOr<int>.Is(IntValue);
        var errorOrString = ErrorOr<string>.Is(StringValue);
        var errorOrBool = ErrorOr<bool>.Is(BoolValue);
        var errorOrByte = ErrorOr<byte>.Is(ByteValue);
        var errorOrDateTime = ErrorOr<DateTimeOffset>.Is(DateTimeValue);
        var errorOrEntity = ErrorOr<TestEntity>.Is(TestEntity);

        // Act & Assert
        errorOrInt.Value.Should().Be(IntValue);
        errorOrString.Value.Should().Be(StringValue);
        errorOrBool.Value.Should().Be(BoolValue);
        errorOrByte.Value.Should().Be(ByteValue);
        errorOrDateTime.Value.Should().Be(DateTimeValue);
        errorOrEntity.Value.Should().Be(TestEntity);
    }

    [Fact]
    public void Value_When_ErrorOrIsError_Should_ThrowInvalidOperationException()
    {
        // Arrange
        var expectedMessage = "Cannot access value for an error result.";
        var errorOr = ErrorOr<int>.From(TestError);

        // Act & Assert
        errorOr.Invoking(e => e.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage(expectedMessage);
    }

    [Fact]
    public void ValueOrDefault_When_ErrorOrIsValue_Should_ReturnProvidedValue()
    {
        // Arrange
        var errorOrInt = ErrorOr<int>.Is(IntValue);
        var errorOrString = ErrorOr<string>.Is(StringValue);
        var errorOrBool = ErrorOr<bool>.Is(BoolValue);
        var errorOrByte = ErrorOr<byte>.Is(ByteValue);
        var errorOrDateTime = ErrorOr<DateTimeOffset>.Is(DateTimeValue);
        var errorOrEntity = ErrorOr<TestEntity>.Is(TestEntity);

        // Act & Assert
        errorOrInt.ValueOrDefault.Should().Be(IntValue);
        errorOrString.ValueOrDefault.Should().Be(StringValue);
        errorOrBool.ValueOrDefault.Should().Be(BoolValue);
        errorOrByte.ValueOrDefault.Should().Be(ByteValue);
        errorOrDateTime.ValueOrDefault.Should().Be(DateTimeValue);
        errorOrEntity.ValueOrDefault.Should().Be(TestEntity);
    }

    [Fact]
    public void ValueOrDefault_When_ErrorOrIsError_Should_ReturnDefaultValue()
    {
        // Arrange
        var errorOrInt = ErrorOr<int>.From(TestError);
        var errorOrString = ErrorOr<string>.From(TestError);
        var errorOrBool = ErrorOr<bool>.From(TestError);
        var errorOrByte = ErrorOr<byte>.From(TestError);
        var errorOrDateTime = ErrorOr<DateTimeOffset>.From(TestError);
        var errorOrEntity = ErrorOr<TestEntity>.From(TestError);

        // Act & Assert
        errorOrInt.ValueOrDefault.Should().Be(default);
        errorOrString.ValueOrDefault.Should().Be(default);
        errorOrBool.ValueOrDefault.Should().Be(default);
        errorOrByte.ValueOrDefault.Should().Be(default);
        errorOrDateTime.ValueOrDefault.Should().Be(default);
        errorOrEntity.ValueOrDefault.Should().Be(default);
    }

    [Fact]
    public void FirstError_When_ErrorOrIsError_Should_ReturnFirstError()
    {
        // Arrange
        var errorOr = ErrorOr<int>.From([
            TestError,
            Error.Invalid("Another error"),
            Error.Invalid("Yet another error"),
        ]);

        // Act & Assert
        errorOr.FirstError.Should().Be(TestError);
    }

    [Fact]
    public void FirstError_When_ErrorOrIsValue_Should_ReturnNullError()
    {
        // Arrange
        var errorOr = ErrorOr<int>.Is(IntValue);

        // Act & Assert
        errorOr.FirstError.Should().Be(Error.Null);
    }
}