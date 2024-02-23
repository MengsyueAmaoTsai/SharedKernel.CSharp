using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class ResultTests : MonadTests
{
    [Fact]
    public void ImplicitCast_When_GivenError_Should_ReturnFailureResult()
    {
        // Arrange

        // Act
        Result result = NotFoundError;

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(NotFoundError);
    }
}