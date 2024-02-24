using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void ImplicitCast_When_GivenPrimitiveValue_Should_ReturnSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> resultInt = IntValue;

        // Assert
        resultInt.IsSuccess.Should().BeTrue();
        resultInt.IsFailure.Should().BeFalse();
        resultInt.Value.Should().Be(IntValue);
    }

    [Fact]
    public void ImplicitCast_When_GivenError_Should_ReturnFailureResultWithError()
    {
        // Arrange & Act
        Result<int> resultInt = NotFoundError;

        // Assert
        resultInt.IsFailure.Should().BeTrue();
        resultInt.IsSuccess.Should().BeFalse();
        resultInt.Error
            .Should().Be(NotFoundError);
    }

    [Fact]
    public void ImplicitCast_When_GivenGenericResult_Should_ReturnSuccessResult()
    {
        // Arrange & Act
        Result<int> resultInt = Result.Success(IntValue);
        Result result = resultInt;

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
    }
}

