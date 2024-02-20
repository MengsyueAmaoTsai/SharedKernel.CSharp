using FluentAssertions;

using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;
using RichillCapital.SharedKernel.UnitTests.Monad.Common.Assertions;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void ImplicitOperator_Should_CreateSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> intResult = IntValue;
        Result<string> stringResult = StringValue;
        Result<bool> boolResult = BoolValue;
        Result<byte> byteResult = ByteValue;
        Result<DateTimeOffset> dateTimeResult = DateTimeValue;
        Result<TestObject> objectResult = TestObjectValue;

        // Assert
        intResult.ShouldBeSuccessResultWithValue(IntValue);
        stringResult.ShouldBeSuccessResultWithValue(StringValue);
        boolResult.ShouldBeSuccessResultWithValue(BoolValue);
        byteResult.ShouldBeSuccessResultWithValue(ByteValue);
        dateTimeResult.ShouldBeSuccessResultWithValue(DateTimeValue);
        objectResult.ShouldBeSuccessResultWithValue(TestObjectValue);
    }

    [Fact]
    public void ImplicitOperator_Should_CreateFailureResultWithErrorMessage()
    {
        // Arrange & Act
        Result<int> intResult = TestError;
        Result<string> stringResult = TestError;
        Result<bool> boolResult = TestError;
        Result<byte> byteResult = TestError;
        Result<DateTimeOffset> dateTimeResult = TestError;
        Result<TestObject> objectResult = TestError;

        // Assert
        intResult.ShouldBeFailureResultWithError(TestError);
        stringResult.ShouldBeFailureResultWithError(TestError);
        boolResult.ShouldBeFailureResultWithError(TestError);
        byteResult.ShouldBeFailureResultWithError(TestError);
        dateTimeResult.ShouldBeFailureResultWithError(TestError);
        objectResult.ShouldBeFailureResultWithError(TestError);
    }

    [Fact]
    public void Equal_Should_ReturnTrue_When_ResultsAreEqual()
    {
        // Arrange
        Result<int> intResult1 = Result<int>.Success(IntValue);
        Result<int> intResult2 = Result<int>.Success(IntValue);

        Result<string> stringResult1 = Result<string>.Success(StringValue);
        Result<string> stringResult2 = Result<string>.Success(StringValue);

        Result<bool> boolResult1 = Result<bool>.Success(BoolValue);
        Result<bool> boolResult2 = Result<bool>.Success(BoolValue);

        Result<byte> byteResult1 = Result<byte>.Success(ByteValue);
        Result<byte> byteResult2 = Result<byte>.Success(ByteValue);

        Result<DateTimeOffset> dateTimeResult1 = Result<DateTimeOffset>.Success(DateTimeValue);
        Result<DateTimeOffset> dateTimeResult2 = Result<DateTimeOffset>.Success(DateTimeValue);

        Result<TestObject> testObjectResult1 = Result<TestObject>.Success(TestObjectValue);
        Result<TestObject> testObjectResult2 = Result<TestObject>.Success(TestObjectValue);

        // Act & Assert
        intResult1.Equals(intResult2).Should().BeTrue();
        stringResult1.Equals(stringResult2).Should().BeTrue();
        boolResult1.Equals(boolResult2).Should().BeTrue();
        byteResult1.Equals(byteResult2).Should().BeTrue();
        dateTimeResult1.Equals(dateTimeResult2).Should().BeTrue();
        testObjectResult1.Equals(testObjectResult2).Should().BeTrue();
    }

    [Fact]
    public void Equal_Should_ReturnFalse_When_ResultsAreNotEqual()
    {
        // Arrange
        Result<int> intResult1 = Result<int>.Success(IntValue);
        Result<int> intResult2 = Result<int>.Success(12);

        Result<string> stringResult1 = Result<string>.Success(StringValue);
        Result<string> stringResult2 = Result<string>.Success("1234");

        Result<bool> boolResult1 = Result<bool>.Success(BoolValue);
        Result<bool> boolResult2 = Result<bool>.Success(false);

        Result<byte> byteResult1 = Result<byte>.Success(ByteValue);
        Result<byte> byteResult2 = Result<byte>.Success(0x58);

        Result<DateTimeOffset> dateTimeResult1 = Result<DateTimeOffset>.Success(DateTimeValue);
        Result<DateTimeOffset> dateTimeResult2 = Result<DateTimeOffset>.Success(DateTimeOffset.UtcNow);

        Result<TestObject> testObjectResult1 = Result<TestObject>.Success(TestObjectValue);
        Result<TestObject> testObjectResult2 = Result<TestObject>.Success(new TestObject("1234"));

        // Act & Assert
        intResult1.Equals(intResult2).Should().BeFalse();
        stringResult1.Equals(stringResult2).Should().BeFalse();
        boolResult1.Equals(boolResult2).Should().BeFalse();
        byteResult1.Equals(byteResult2).Should().BeFalse();
        dateTimeResult1.Equals(dateTimeResult2).Should().BeFalse();
        testObjectResult1.Equals(testObjectResult2).Should().BeFalse();
    }

    [Fact]
    public void EqualsOperator_Should_ReturnTrue_When_ResultsAreEqual()
    {
        // Arrange
        Result<int> intResult1 = Result<int>.Success(IntValue);
        Result<int> intResult2 = Result<int>.Success(IntValue);

        Result<string> stringResult1 = Result<string>.Success(StringValue);
        Result<string> stringResult2 = Result<string>.Success(StringValue);

        Result<bool> boolResult1 = Result<bool>.Success(BoolValue);
        Result<bool> boolResult2 = Result<bool>.Success(BoolValue);

        Result<byte> byteResult1 = Result<byte>.Success(ByteValue);
        Result<byte> byteResult2 = Result<byte>.Success(ByteValue);

        Result<DateTimeOffset> dateTimeResult1 = Result<DateTimeOffset>.Success(DateTimeValue);
        Result<DateTimeOffset> dateTimeResult2 = Result<DateTimeOffset>.Success(DateTimeValue);

        Result<TestObject> testObjectResult1 = Result<TestObject>.Success(TestObjectValue);
        Result<TestObject> testObjectResult2 = Result<TestObject>.Success(TestObjectValue);

        // Act & Assert
        (intResult1 == intResult2).Should().BeTrue();
        (stringResult1 == stringResult2).Should().BeTrue();
        (boolResult1 == boolResult2).Should().BeTrue();
        (byteResult1 == byteResult2).Should().BeTrue();
        (dateTimeResult1 == dateTimeResult2).Should().BeTrue();
        (testObjectResult1 == testObjectResult2).Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_Should_ReturnFalse_When_ResultsAreNotEqual()
    {
        // Arrange
        Result<int> intResult1 = Result<int>.Success(IntValue);
        Result<int> intResult2 = Result<int>.Success(12);

        Result<string> stringResult1 = Result<string>.Success(StringValue);
        Result<string> stringResult2 = Result<string>.Success("1234");

        Result<bool> boolResult1 = Result<bool>.Success(BoolValue);
        Result<bool> boolResult2 = Result<bool>.Success(false);

        Result<byte> byteResult1 = Result<byte>.Success(ByteValue);
        Result<byte> byteResult2 = Result<byte>.Success(0x58);

        Result<DateTimeOffset> dateTimeResult1 = Result<DateTimeOffset>.Success(DateTimeValue);
        Result<DateTimeOffset> dateTimeResult2 = Result<DateTimeOffset>.Success(DateTimeOffset.UtcNow);

        Result<TestObject> testObjectResult1 = Result<TestObject>.Success(TestObjectValue);
        Result<TestObject> testObjectResult2 = Result<TestObject>.Success(new TestObject("1234"));

        // Act & Assert
        (intResult1 == intResult2).Should().BeFalse();
        (stringResult1 == stringResult2).Should().BeFalse();
        (boolResult1 == boolResult2).Should().BeFalse();
        (byteResult1 == byteResult2).Should().BeFalse();
        (dateTimeResult1 == dateTimeResult2).Should().BeFalse();
        (testObjectResult1 == testObjectResult2).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_Should_ReturnTrue_When_ResultsAreNotEqual()
    {
        // Arrange
        Result<int> intResult1 = Result<int>.Success(IntValue);
        Result<int> intResult2 = Result<int>.Success(12);

        Result<string> stringResult1 = Result<string>.Success(StringValue);
        Result<string> stringResult2 = Result<string>.Success("1234");

        Result<bool> boolResult1 = Result<bool>.Success(BoolValue);
        Result<bool> boolResult2 = Result<bool>.Success(false);

        Result<byte> byteResult1 = Result<byte>.Success(ByteValue);
        Result<byte> byteResult2 = Result<byte>.Success(0x58);

        Result<DateTimeOffset> dateTimeResult1 = Result<DateTimeOffset>.Success(DateTimeValue);
        Result<DateTimeOffset> dateTimeResult2 = Result<DateTimeOffset>.Success(DateTimeOffset.UtcNow);

        Result<TestObject> testObjectResult1 = Result<TestObject>.Success(TestObjectValue);
        Result<TestObject> testObjectResult2 = Result<TestObject>.Success(new TestObject("1234"));

        // Act & Assert
        (intResult1 != intResult2).Should().BeTrue();
        (stringResult1 != stringResult2).Should().BeTrue();
        (boolResult1 != boolResult2).Should().BeTrue();
        (byteResult1 != byteResult2).Should().BeTrue();
        (dateTimeResult1 != dateTimeResult2).Should().BeTrue();
        (testObjectResult1 != testObjectResult2).Should().BeTrue();
    }

    [Fact]
    public void NotEqualsOperator_Should_ReturnFalse_When_ResultsAreEqual()
    {
        // Arrange
        Result<int> intResult1 = Result<int>.Success(IntValue);
        Result<int> intResult2 = Result<int>.Success(IntValue);

        Result<string> stringResult1 = Result<string>.Success(StringValue);
        Result<string> stringResult2 = Result<string>.Success(StringValue);

        Result<bool> boolResult1 = Result<bool>.Success(BoolValue);
        Result<bool> boolResult2 = Result<bool>.Success(BoolValue);

        Result<byte> byteResult1 = Result<byte>.Success(ByteValue);
        Result<byte> byteResult2 = Result<byte>.Success(ByteValue);

        Result<DateTimeOffset> dateTimeResult1 = Result<DateTimeOffset>.Success(DateTimeValue);
        Result<DateTimeOffset> dateTimeResult2 = Result<DateTimeOffset>.Success(DateTimeValue);

        Result<TestObject> testObjectResult1 = Result<TestObject>.Success(TestObjectValue);
        Result<TestObject> testObjectResult2 = Result<TestObject>.Success(TestObjectValue);

        // Act & Assert
        (intResult1 != intResult2).Should().BeFalse();
        (stringResult1 != stringResult2).Should().BeFalse();
        (boolResult1 != boolResult2).Should().BeFalse();
        (byteResult1 != byteResult2).Should().BeFalse();
        (dateTimeResult1 != dateTimeResult2).Should().BeFalse();
        (testObjectResult1 != testObjectResult2).Should().BeFalse();
    }
}