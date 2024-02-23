using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Value_When_ResultIsSuccess_Should_ReturnValue()
    {
        // Arrange
        var value = 10;
        var result = Result<int>.Success(value);

        // Act
        var resultValue = result.Value;

        // Assert
        resultValue.Should().Be(value);
    }

    [Fact]
    public void Value_When_ResultIsFailure_Should_ThrowInvalidOperationException()
    {
        // Arrange
        var result = Result<int>.Failure(NotFoundError);

        // Act
        Action act = () => _ = result.Value;

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("Cannot access the value of a failed result.");
    }

    [Fact]
    public void ValueOrDefault_When_ResultIsSuccess_Should_ReturnValue()
    {
        // Arrange
        var value = 10;
        var result = Result<int>.Success(value);

        // Act
        var resultValue = result.ValueOrDefault;

        // Assert
        resultValue.Should().Be(value);
    }

    [Fact]
    public void ValueOrDefault_When_ResultIsFailure_Should_ReturnDefault()
    {
        // Arrange
        var result = Result<int>.Failure(NotFoundError);

        // Act
        var resultValue = result.ValueOrDefault;

        // Assert
        resultValue.Should().Be(default);
    }
}

