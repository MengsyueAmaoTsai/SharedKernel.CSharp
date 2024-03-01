using RichillCapital.Extensions.Monads.UnitTests.Shared;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class ResulTEnsureTests : MonadTests
{
    [Fact]
    public void Ensure_When_IsFailure_Should_NotInvokeEnsure_And_ReturnFailureResultWithError()
    {
        // Arrange & Act
        var result = TestError
            .ToResult<int>()
            .Ensure(EnsureTrue, TestError);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public void Ensure_When_IsValue_And_EnsureFalse_Should_InvokeEnsure_And_ReturnFailureResultWithGivenError()
    {
        // Arrange & Act
        var result = TestValue
            .ToResult()
            .Ensure(EnsureFalse, TestError);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public void Ensure_When_IsValue_And_EnsureTrue_Should_InvokeEnsure_And_ReturnSuccessResultWithValue()
    {
        // Arrange & Act
        var result = TestValue
            .ToResult()
            .Ensure(EnsureTrue, TestError);

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }
}