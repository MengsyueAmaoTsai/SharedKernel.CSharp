using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class ResultTests : MonadTests
{
    [Fact]
    public void Success_Should_CreateSuccessResult()
    {
        // Arrange & Act
        Result result = Result.Success();

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void Failure_Should_CreateFailureResult()
    {
        // Arrange & Act
        Result result = Result.Failure(NotFoundError);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(NotFoundError);
    }
}