using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTFactoryTests : MonadTests
{
    [Fact]
    public void With_When_GivenValue_Should_CreateSuccessResultWithValue()
    {
        // Arrange & Act
        var result = Result<int>.With(TestValue);

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }

    [Fact]
    public void Failure_When_GivenError_Should_CreateFailureResultWithError()
    {
        // Arrange & Act
        Result<int> result = Result<int>.Failure(TestError);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }
}