using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultExtensionsConvertersTests : MonadTests
{
    [Fact]
    public void ToResult_When_GivenValue_Should_ConvertToSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> result = TestValue.ToResult();

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }

    [Fact]
    public async Task ToResultAsync_When_FromValue_Should_ConvertToSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> result = await GetTestValueAsync().ToResult();

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }

    [Fact]
    public void ToResult_When_GivenError_Should_ConvertToFailureResultWithError()
    {
        // Arrange & Act
        Result<int> result = TestError.ToResult<int>();

        // Assert
        result.ShouldBeFailureWith(TestError);
    }
}