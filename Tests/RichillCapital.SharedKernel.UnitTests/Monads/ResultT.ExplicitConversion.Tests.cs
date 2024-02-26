using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void ToResult_Should_ConvertValueToResult()
    {
        // Arrange & Act
        var resultFromValue = IntValue.ToResult();
        var resultFromError = NotFoundError.ToResult<int>();

        // Assert
        resultFromValue.IsSuccess.Should().BeTrue();
        resultFromValue.Value.Should().Be(IntValue);

        resultFromError.IsFailure.Should().BeTrue();
        resultFromError.Error.Should().Be(NotFoundError);
    }

    [Fact]
    public void ToResult_Should_ConvertErrorToResult()
    {
        // Arrange & Act
        var resultFromError = NotFoundError.ToResult();

        // Assert
        resultFromError.IsFailure.Should().BeTrue();
        resultFromError.Error.Should().Be(NotFoundError);
    }

    [Fact]
    public void ToResult_Should_ConvertErrorToResult_WithoutType()
    {
        // Arrange & Act
        var resultFromError = NotFoundError.ToResult();

        // Assert
        resultFromError.IsFailure.Should().BeTrue();
        resultFromError.Error.Should().Be(NotFoundError);
    }
}