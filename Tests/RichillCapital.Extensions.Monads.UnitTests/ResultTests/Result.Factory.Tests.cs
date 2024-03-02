using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultFactoryTests : MonadTests
{
    [Fact]
    public void Failure_When_GivenError_Should_CreateFailureResultWithError()
    {
        // Arrange & Act
        Result result = Result.Failure(TestError);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }
}