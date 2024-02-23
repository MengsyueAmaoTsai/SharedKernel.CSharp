
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public async Task Then_WhenIsFailure_ReturnsFailureResult()
    {
        // Arrange
        var result = Result<int>.Failure(TestError);

        // Act
        var actual = await result.Then(value => Task.FromResult(Result<string>.Success(value.ToString())));

        // Assert
        actual.ShouldBeFailureResultWithError(TestError);
    }

    [Fact]
    public async Task Then_WhenIsNotFailure_ReturnsSuccessResult()
    {
        // Arrange
        var result = Result<int>.Success(1);

        // Act
        var actual = await result.Then(value => Task.FromResult(Result<string>.Success(value.ToString())));

        // Assert
        actual.ShouldBeSuccessResultWithValue("1");
    }
}