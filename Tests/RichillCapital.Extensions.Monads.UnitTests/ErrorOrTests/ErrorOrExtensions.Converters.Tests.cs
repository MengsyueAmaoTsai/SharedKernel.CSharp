using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrExtensionsConvertersTests : MonadTests
{
    [Fact]
    public void ToErrorOr_When_FromValue_Should_ConvertToErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = TestValue.ToErrorOr();

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }

    [Fact]
    public async Task ToErrorOrAsync_When_FromValue_Should_ConvertToErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = await GetTestValueAsync().ToErrorOr();

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }

    [Fact]
    public void ToErrorOr_When_FromError_Should_ConvertToErrorOrWithError()
    {
        // Arrange & Act
        var errorOr = TestError.ToErrorOr<int>();

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public void ToErrorOr_When_FromErrorsList_Should_ConvertToErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOr = TestErrors
            .ToList()
            .ToErrorOr<int>();

        // Assert
        errorOr.ShouldBeErrors(TestErrors);
    }

    [Fact]
    public void ToErrorOr_When_FromErrorsArray_Should_ConvertToErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOr = TestErrors
            .ToArray()
            .ToErrorOr<int>();

        // Assert
        errorOr.ShouldBeErrors(TestErrors);
    }
}