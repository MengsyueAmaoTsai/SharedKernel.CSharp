
using FluentAssertions;

using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Equals_When_ComparingResultWithSameValues_Should_ReturnTrue()
    {
        // Arrange
        var intResult = Result<int>.Success(IntValue);
        var intResult2 = Result<int>.Success(IntValue);

        // Act & Assert
        intResult.Equals(intResult2).Should().BeTrue();
    }

    [Fact]
    public void Equals_When_ComparingResultWithDifferentValues_Should_ReturnFalse()
    {
        // Arrange
        var intResult = Result<int>.Success(IntValue);
        var intResult2 = Result<int>.Success(IntValue + 1);

        // Act & Assert
        intResult.Equals(intResult2).Should().BeFalse();
    }

    [Fact]
    public void Equals_When_ComparingResultWithSameErrors_Should_ReturnTrue()
    {
        // Arrange
        var result = Result<int>.Failure(TestError);
        var result2 = Result<int>.Failure(TestError);

        // Act & Assert
        result.Equals(result2).Should().BeTrue();
    }

    [Fact]
    public void Equals_When_ComparingResultWithDifferentErrors_Should_ReturnFalse()
    {
        // Arrange
        var result = Result<int>.Failure(TestError);
        var result2 = Result<int>.Failure(Error.Invalid("Different error"));

        // Act & Assert
        result.Equals(result2).Should().BeFalse();
    }

    [Fact]
    public void Value_When_ResultIsSuccess_Should_ReturnProvidedValue()
    {
        // Arrange
        var intResult = Result<int>.Success(IntValue);
        var stringValueResult = Result<string>.Success(StringValue);
        var boolResult = Result<bool>.Success(BoolValue);
        var byteResult = Result<byte>.Success(ByteValue);
        var dateTimeResult = Result<DateTimeOffset>.Success(DateTimeValue);
        var testEntityResult = Result<TestEntity>.Success(TestEntity);

        // Act & Assert
        intResult.Value.Should().Be(IntValue);
        stringValueResult.Value.Should().Be(StringValue);
        boolResult.Value.Should().Be(BoolValue);
        byteResult.Value.Should().Be(ByteValue);
        dateTimeResult.Value.Should().Be(DateTimeValue);
        testEntityResult.Value.Should().Be(TestEntity);
    }

    [Fact]
    public void Value_When_ResultIsFailure_Should_ThrowInvalidOperationException()
    {
        // Arrange
        var intResult = Result<int>.Failure(TestError);
        var stringValueResult = Result<string>.Failure(TestError);
        var boolResult = Result<bool>.Failure(TestError);
        var byteResult = Result<byte>.Failure(TestError);
        var dateTimeResult = Result<DateTimeOffset>.Failure(TestError);
        var testEntityResult = Result<TestEntity>.Failure(TestError);

        var expectedErrorMessage = "Cannot access value for a failure result.";

        // Act & Assert
        intResult.Invoking(r => r.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage(expectedErrorMessage);

        stringValueResult.Invoking(r => r.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage(expectedErrorMessage);

        boolResult.Invoking(r => r.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage(expectedErrorMessage);

        byteResult.Invoking(r => r.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage(expectedErrorMessage);

        dateTimeResult.Invoking(r => r.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage(expectedErrorMessage);

        testEntityResult.Invoking(r => r.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage(expectedErrorMessage);
    }

    [Fact]
    public void ValueOrDefault_When_ResultIsSuccess_Should_ReturnProvidedValue()
    {
        // Arrange
        var intResult = Result<int>.Success(IntValue);
        var stringValueResult = Result<string>.Success(StringValue);
        var boolResult = Result<bool>.Success(BoolValue);
        var byteResult = Result<byte>.Success(ByteValue);
        var dateTimeResult = Result<DateTimeOffset>.Success(DateTimeValue);
        var testEntityResult = Result<TestEntity>.Success(TestEntity);

        // Act & Assert
        intResult.ValueOrDefault.Should().Be(IntValue);
        stringValueResult.ValueOrDefault.Should().Be(StringValue);
        boolResult.ValueOrDefault.Should().Be(BoolValue);
        byteResult.ValueOrDefault.Should().Be(ByteValue);
        dateTimeResult.ValueOrDefault.Should().Be(DateTimeValue);
        testEntityResult.ValueOrDefault.Should().Be(TestEntity);
    }

    [Fact]
    public void ValueOrDefault_When_ResultIsFailure_Should_ReturnDefault()
    {
        // Arrange
        var intResult = Result<int>.Failure(TestError);
        var stringValueResult = Result<string>.Failure(TestError);
        var boolResult = Result<bool>.Failure(TestError);
        var byteResult = Result<byte>.Failure(TestError);
        var dateTimeResult = Result<DateTimeOffset>.Failure(TestError);
        var testEntityResult = Result<TestEntity>.Failure(TestError);

        // Act & Assert
        intResult.ValueOrDefault.Should().Be(default);
        stringValueResult.ValueOrDefault.Should().Be(default);
        boolResult.ValueOrDefault.Should().Be(default);
        byteResult.ValueOrDefault.Should().Be(default);
        dateTimeResult.ValueOrDefault.Should().Be(default);
        testEntityResult.ValueOrDefault.Should().Be(default);
    }
}