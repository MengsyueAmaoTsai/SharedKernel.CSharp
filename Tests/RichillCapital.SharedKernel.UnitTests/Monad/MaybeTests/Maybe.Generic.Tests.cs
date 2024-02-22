using FluentAssertions;

using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void ImplicitCast_Should_ReturnMaybeWithValue()
    {
        // Arrange & Act
        Maybe<int> intMaybe = IntValue;
        Maybe<string> stringMaybe = StringValue;
        Maybe<bool> boolMaybe = BoolValue;
        Maybe<byte> byteMaybe = ByteValue;
        Maybe<DateTimeOffset> dateTimeMaybe = DateTimeValue;
        Maybe<TestObject> testObjectMaybe = TestObjectValue;

        // Assert
        intMaybe.ShouldBeMaybeHasValue(IntValue);
        stringMaybe.ShouldBeMaybeHasValue(StringValue);
        boolMaybe.ShouldBeMaybeHasValue(BoolValue);
        byteMaybe.ShouldBeMaybeHasValue(ByteValue);
        dateTimeMaybe.ShouldBeMaybeHasValue(DateTimeValue);
        testObjectMaybe.ShouldBeMaybeHasValue(TestObjectValue);
    }

    [Fact]
    public void ImplicitCast_Should_ReturnMaybeWithNoValue()
    {
        // Arrange & Act
        Maybe<TestObject> testObjectMaybe = null!;

        // Assert
        testObjectMaybe.ShouldBeMaybeHasNoValue();
    }

    [Fact]
    public void Equals_Should_ReturnTrue_WhenBothHaveValueAndValuesAreEqual()
    {
        // Arrange
        Maybe<int> intMaybe1 = Maybe<int>.With(IntValue);
        Maybe<int> intMaybe2 = Maybe<int>.With(IntValue);

        Maybe<string> stringMaybe1 = Maybe<string>.With(StringValue);
        Maybe<string> stringMaybe2 = Maybe<string>.With(StringValue);

        Maybe<bool> boolMaybe1 = Maybe<bool>.With(BoolValue);
        Maybe<bool> boolMaybe2 = Maybe<bool>.With(BoolValue);

        Maybe<byte> byteMaybe1 = Maybe<byte>.With(ByteValue);
        Maybe<byte> byteMaybe2 = Maybe<byte>.With(ByteValue);

        Maybe<DateTimeOffset> dateTimeMaybe1 = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<DateTimeOffset> dateTimeMaybe2 = Maybe<DateTimeOffset>.With(DateTimeValue);

        Maybe<TestObject> testObjectMaybe1 = Maybe<TestObject>.With(TestObjectValue);
        Maybe<TestObject> testObjectMaybe2 = Maybe<TestObject>.With(TestObjectValue);

        // Act & Assert
        intMaybe1.Equals(intMaybe2).Should().BeTrue();
        stringMaybe1.Equals(stringMaybe2).Should().BeTrue();
        boolMaybe1.Equals(boolMaybe2).Should().BeTrue();
        byteMaybe1.Equals(byteMaybe2).Should().BeTrue();
        dateTimeMaybe1.Equals(dateTimeMaybe2).Should().BeTrue();
        testObjectMaybe1.Equals(testObjectMaybe2).Should().BeTrue();
    }

    [Fact]
    public void Equals_Should_ReturnFalse_WhenBothHaveValueAndValuesAreNotEqual()
    {
        // Arrange
        Maybe<int> intMaybe1 = Maybe<int>.With(IntValue);
        Maybe<int> intMaybe2 = Maybe<int>.With(5);

        Maybe<string> stringMaybe1 = Maybe<string>.With(StringValue);
        Maybe<string> stringMaybe2 = Maybe<string>.With("Default");

        Maybe<bool> boolMaybe1 = Maybe<bool>.With(BoolValue);
        Maybe<bool> boolMaybe2 = Maybe<bool>.With(false);

        Maybe<byte> byteMaybe1 = Maybe<byte>.With(ByteValue);
        Maybe<byte> byteMaybe2 = Maybe<byte>.With(0x0E);

        Maybe<DateTimeOffset> dateTimeMaybe1 = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<DateTimeOffset> dateTimeMaybe2 = Maybe<DateTimeOffset>.With(DateTimeOffset.Now);

        Maybe<TestObject> testObjectMaybe1 = Maybe<TestObject>.With(TestObjectValue);
        Maybe<TestObject> testObjectMaybe2 = Maybe<TestObject>.With(new TestObject("Default"));

        // Act & Assert
        intMaybe1.Equals(intMaybe2).Should().BeFalse();
        stringMaybe1.Equals(stringMaybe2).Should().BeFalse();
        boolMaybe1.Equals(boolMaybe2).Should().BeFalse();
        byteMaybe1.Equals(byteMaybe2).Should().BeFalse();
        dateTimeMaybe1.Equals(dateTimeMaybe2).Should().BeFalse();
        testObjectMaybe1.Equals(testObjectMaybe2).Should().BeFalse();
    }

    [Fact]
    public void Equal_Should_ReturnFalse_WhenOneHasValueAndOtherHasNoValue()
    {
        // Arrange
        Maybe<int> intMaybe1 = Maybe<int>.With(IntValue);
        Maybe<int> intMaybe2 = Maybe<int>.Null;

        Maybe<string> stringMaybe1 = Maybe<string>.With(StringValue);
        Maybe<string> stringMaybe2 = Maybe<string>.Null;

        Maybe<bool> boolMaybe1 = Maybe<bool>.With(BoolValue);
        Maybe<bool> boolMaybe2 = Maybe<bool>.Null;

        Maybe<byte> byteMaybe1 = Maybe<byte>.With(ByteValue);
        Maybe<byte> byteMaybe2 = Maybe<byte>.Null;

        Maybe<DateTimeOffset> dateTimeMaybe1 = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<DateTimeOffset> dateTimeMaybe2 = Maybe<DateTimeOffset>.Null;

        Maybe<TestObject> testObjectMaybe1 = Maybe<TestObject>.With(TestObjectValue);
        Maybe<TestObject> testObjectMaybe2 = Maybe<TestObject>.Null;

        // Act & Assert
        intMaybe1.Equals(intMaybe2).Should().BeFalse();
        stringMaybe1.Equals(stringMaybe2).Should().BeFalse();
        boolMaybe1.Equals(boolMaybe2).Should().BeFalse();
        byteMaybe1.Equals(byteMaybe2).Should().BeFalse();
        dateTimeMaybe1.Equals(dateTimeMaybe2).Should().BeFalse();
        testObjectMaybe1.Equals(testObjectMaybe2).Should().BeFalse();
    }

    [Fact]
    public void Equal_Should_ReturnTrue_WhenBothHaveNoValue()
    {
        // Arrange
        Maybe<int> intMaybe1 = Maybe<int>.Null;
        Maybe<int> intMaybe2 = Maybe<int>.Null;

        Maybe<string> stringMaybe1 = Maybe<string>.Null;
        Maybe<string> stringMaybe2 = Maybe<string>.Null;

        Maybe<bool> boolMaybe1 = Maybe<bool>.Null;
        Maybe<bool> boolMaybe2 = Maybe<bool>.Null;

        Maybe<byte> byteMaybe1 = Maybe<byte>.Null;
        Maybe<byte> byteMaybe2 = Maybe<byte>.Null;

        Maybe<DateTimeOffset> dateTimeMaybe1 = Maybe<DateTimeOffset>.Null;
        Maybe<DateTimeOffset> dateTimeMaybe2 = Maybe<DateTimeOffset>.Null;

        Maybe<TestObject> testObjectMaybe1 = Maybe<TestObject>.Null;
        Maybe<TestObject> testObjectMaybe2 = Maybe<TestObject>.Null;

        // Act & Assert
        intMaybe1.Equals(intMaybe2).Should().BeTrue();
        stringMaybe1.Equals(stringMaybe2).Should().BeTrue();
        boolMaybe1.Equals(boolMaybe2).Should().BeTrue();
        byteMaybe1.Equals(byteMaybe2).Should().BeTrue();
        dateTimeMaybe1.Equals(dateTimeMaybe2).Should().BeTrue();
        testObjectMaybe1.Equals(testObjectMaybe2).Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_Should_ReturnTrue_WhenBothHaveValueAndValuesAreEqual()
    {
        // Arrange
        Maybe<int> intMaybe1 = Maybe<int>.With(IntValue);
        Maybe<int> intMaybe2 = Maybe<int>.With(IntValue);

        Maybe<string> stringMaybe1 = Maybe<string>.With(StringValue);
        Maybe<string> stringMaybe2 = Maybe<string>.With(StringValue);

        Maybe<bool> boolMaybe1 = Maybe<bool>.With(BoolValue);
        Maybe<bool> boolMaybe2 = Maybe<bool>.With(BoolValue);

        Maybe<byte> byteMaybe1 = Maybe<byte>.With(ByteValue);
        Maybe<byte> byteMaybe2 = Maybe<byte>.With(ByteValue);

        Maybe<DateTimeOffset> dateTimeMaybe1 = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<DateTimeOffset> dateTimeMaybe2 = Maybe<DateTimeOffset>.With(DateTimeValue);

        Maybe<TestObject> testObjectMaybe1 = Maybe<TestObject>.With(TestObjectValue);
        Maybe<TestObject> testObjectMaybe2 = Maybe<TestObject>.With(TestObjectValue);

        // Act & Assert
        (intMaybe1 == intMaybe2).Should().BeTrue();
        (stringMaybe1 == stringMaybe2).Should().BeTrue();
        (boolMaybe1 == boolMaybe2).Should().BeTrue();
        (byteMaybe1 == byteMaybe2).Should().BeTrue();
        (dateTimeMaybe1 == dateTimeMaybe2).Should().BeTrue();
        (testObjectMaybe1 == testObjectMaybe2).Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_Should_ReturnFalse_WhenBothHaveValueAndValuesAreNotEqual()
    {
        // Arrange
        Maybe<int> intMaybe1 = Maybe<int>.With(IntValue);
        Maybe<int> intMaybe2 = Maybe<int>.With(5);

        Maybe<string> stringMaybe1 = Maybe<string>.With(StringValue);
        Maybe<string> stringMaybe2 = Maybe<string>.With("Default");

        Maybe<bool> boolMaybe1 = Maybe<bool>.With(BoolValue);
        Maybe<bool> boolMaybe2 = Maybe<bool>.With(false);

        Maybe<byte> byteMaybe1 = Maybe<byte>.With(ByteValue);
        Maybe<byte> byteMaybe2 = Maybe<byte>.With(0x0E);

        Maybe<DateTimeOffset> dateTimeMaybe1 = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<DateTimeOffset> dateTimeMaybe2 = Maybe<DateTimeOffset>.With(DateTimeOffset.Now);

        Maybe<TestObject> testObjectMaybe1 = Maybe<TestObject>.With(TestObjectValue);
        Maybe<TestObject> testObjectMaybe2 = Maybe<TestObject>.With(new TestObject("Default"));

        // Act & Assert
        (intMaybe1 == intMaybe2).Should().BeFalse();
        (stringMaybe1 == stringMaybe2).Should().BeFalse();
        (boolMaybe1 == boolMaybe2).Should().BeFalse();
        (byteMaybe1 == byteMaybe2).Should().BeFalse();
        (dateTimeMaybe1 == dateTimeMaybe2).Should().BeFalse();
        (testObjectMaybe1 == testObjectMaybe2).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_Should_ReturnTrue_WhenBothHaveValueAndValuesAreNotEqual()
    {
        // Arrange
        Maybe<int> intMaybe1 = Maybe<int>.With(IntValue);
        Maybe<int> intMaybe2 = Maybe<int>.With(5);

        Maybe<string> stringMaybe1 = Maybe<string>.With(StringValue);
        Maybe<string> stringMaybe2 = Maybe<string>.With("Default");

        Maybe<bool> boolMaybe1 = Maybe<bool>.With(BoolValue);
        Maybe<bool> boolMaybe2 = Maybe<bool>.With(false);

        Maybe<byte> byteMaybe1 = Maybe<byte>.With(ByteValue);
        Maybe<byte> byteMaybe2 = Maybe<byte>.With(0x0E);

        Maybe<DateTimeOffset> dateTimeMaybe1 = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<DateTimeOffset> dateTimeMaybe2 = Maybe<DateTimeOffset>.With(DateTimeOffset.Now);

        Maybe<TestObject> testObjectMaybe1 = Maybe<TestObject>.With(TestObjectValue);
        Maybe<TestObject> testObjectMaybe2 = Maybe<TestObject>.With(new TestObject("Default"));

        // Act & Assert
        (intMaybe1 != intMaybe2).Should().BeTrue();
        (stringMaybe1 != stringMaybe2).Should().BeTrue();
        (boolMaybe1 != boolMaybe2).Should().BeTrue();
        (byteMaybe1 != byteMaybe2).Should().BeTrue();
        (dateTimeMaybe1 != dateTimeMaybe2).Should().BeTrue();
        (testObjectMaybe1 != testObjectMaybe2).Should().BeTrue();
    }

    [Fact]
    public void NotEqualsOperator_Should_ReturnFalse_WhenBothHaveValueAndValuesAreEqual()
    {
        // Arrange
        Maybe<int> intMaybe1 = Maybe<int>.With(IntValue);
        Maybe<int> intMaybe2 = Maybe<int>.With(IntValue);

        Maybe<string> stringMaybe1 = Maybe<string>.With(StringValue);
        Maybe<string> stringMaybe2 = Maybe<string>.With(StringValue);

        Maybe<bool> boolMaybe1 = Maybe<bool>.With(BoolValue);
        Maybe<bool> boolMaybe2 = Maybe<bool>.With(BoolValue);

        Maybe<byte> byteMaybe1 = Maybe<byte>.With(ByteValue);
        Maybe<byte> byteMaybe2 = Maybe<byte>.With(ByteValue);

        Maybe<DateTimeOffset> dateTimeMaybe1 = Maybe<DateTimeOffset>.With(DateTimeValue);
        Maybe<DateTimeOffset> dateTimeMaybe2 = Maybe<DateTimeOffset>.With(DateTimeValue);

        Maybe<TestObject> testObjectMaybe1 = Maybe<TestObject>.With(TestObjectValue);
        Maybe<TestObject> testObjectMaybe2 = Maybe<TestObject>.With(TestObjectValue);

        // Act & Assert
        (intMaybe1 != intMaybe2).Should().BeFalse();
        (stringMaybe1 != stringMaybe2).Should().BeFalse();
        (boolMaybe1 != boolMaybe2).Should().BeFalse();
        (byteMaybe1 != byteMaybe2).Should().BeFalse();
        (dateTimeMaybe1 != dateTimeMaybe2).Should().BeFalse();
        (testObjectMaybe1 != testObjectMaybe2).Should().BeFalse();
    }
}

