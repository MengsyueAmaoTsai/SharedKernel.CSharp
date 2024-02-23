using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Success_When_GivenPrimitiveValue_Should_ReturnSuccessResultWithValue()
    {
        // Arrange & Act
        var resultInt = Result<int>.Success(IntValue);

        // Assert
        resultInt.IsSuccess.Should().BeTrue();
        resultInt.IsFailure.Should().BeFalse();
        resultInt.Value.Should().Be(IntValue);
    }

    [Fact]
    public void Failure_When_GivenError_Should_ReturnFailureResultWithError()
    {
        // Arrange & Act
        var resultInt = Result<int>.Failure(NotFoundError);

        // Assert
        resultInt.IsFailure.Should().BeTrue();
        resultInt.IsSuccess.Should().BeFalse();
        resultInt.Error
            .Should().Be(NotFoundError);
    }
}

