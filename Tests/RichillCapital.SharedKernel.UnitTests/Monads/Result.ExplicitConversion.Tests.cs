using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class ResultTests : MonadTests
{
    [Fact]
    public void ToResult_Should_ConvertValueToResult()
    {
        // Arrange & Act
        Result resultFromError = NotFoundError.ToResult();

        // Assert
        resultFromError.IsFailure.Should().BeTrue();
        resultFromError.Error.Should().Be(NotFoundError);
    }
}