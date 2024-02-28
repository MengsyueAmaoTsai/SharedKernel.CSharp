using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTFactoryTests : MonadTests
{
    [Fact]
    public void Success_When_GivenValue_Should_CreateSuccessResult()
    {
        // Arrange & Act
        Result<int> intResult = Result<int>.Success(Value);

        // Assert
        intResult.ShouldBeSuccessWith(Value);
    }

    [Fact]
    public void Failure_When_GivenError_Should_CreateFailureResult()
    {
        // Arrange & Act
        Result<int> intResult = Result<int>.Failure(UnexpectedError);

        // Assert
        intResult.ShouldBeFailureWith(UnexpectedError);
    }
}