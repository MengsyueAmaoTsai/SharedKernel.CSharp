using RichillCapital.Extensions.Monads.UnitTests.Shared;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class ErrorOrTEnsureTests : MonadTests
{
    [Fact]
    public void EnsureFactory_When_EnsureTrue_Should_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.Ensure(TestValue, EnsureTrue, TestError);

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }

    [Fact]
    public void EnsureFactory_When_EnsureFalse_Should_ReturnErrorOrWithError()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.Ensure(TestValue, EnsureFalse, TestError);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public void Ensure_When_HasError_Should_NotInvokeEnsure_And_ReturnErrorOrWithError()
    {
        // Arrange & Act
        var errorOr = TestErrors
            .ToErrorOr<int>()
            .Ensure(EnsureTrue, TestError);

        // Assert
        errorOr.ShouldBeErrors(TestErrors);
    }

    [Fact]
    public void Ensure_When_IsValue_And_EnsureFalse_Should_InvokeEnsure_And_ReturnErrorOrWithGivenError()
    {
        // Arrange & Act
        var errorOr = TestValue
            .ToErrorOr()
            .Ensure(EnsureFalse, TestError);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public void Ensure_When_IsValue_And_EnsureTrue_Should_InvokeEnsure_And_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = TestValue
            .ToErrorOr()
            .Ensure(EnsureTrue, TestError);

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }
}