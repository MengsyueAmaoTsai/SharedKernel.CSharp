using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Success_Should_CreateSuccessResult()
    {
        // Arrange & Act
        var result = Result<int>.Success(IntValue);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(IntValue);
    }

    [Fact]
    public void Failure_Should_CreateFailureResult()
    {
        // Arrange & Act
        var result = Result<int>.Failure(NotFoundError);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(NotFoundError);
    }
}

