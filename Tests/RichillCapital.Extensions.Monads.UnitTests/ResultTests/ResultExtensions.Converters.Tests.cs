using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultExtensionsConvertersTests : MonadTests
{
    [Fact]
    public void ToResult_When_GivenValue_Should_ConvertToSuccessResultWithValue()
    {
        // Arrange & Act
        var result = TestValue.ToResult();

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }

    [Fact]
    public void ToResult_When_GivenError_Should_ConvertToFailureResultWithError()
    {
        // Arrange & Act
        var result = TestError.ToResult<int>();

        // Assert
        result.ShouldBeFailureWith(TestError);
    }
}