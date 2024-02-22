
using FluentAssertions;

using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Value_When_ResultIsSuccess_ShouldReturnProvidedValue()
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
    public void Value_When_ResultIsFailure_ShouldThrowInvalidOperationException()
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
}