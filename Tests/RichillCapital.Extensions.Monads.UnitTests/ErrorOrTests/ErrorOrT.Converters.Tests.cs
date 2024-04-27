using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTConvertersTests : MonadTests
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
    public async Task ToErrorOrAsync_When_FromTask_Should_ConvertToErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = await GetTestValueAsync().ToErrorOr();

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }

    [Fact]
    public async Task ToErrorOrAsync_When_FromValueTask_Should_ConvertToErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = await GetTestValueValueTaskAsync().ToErrorOr();

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

    [Fact]
    public void ToErrorOr_When_ResultIsFailure_Should_ConvertToErrorOrWithError()
    {
        // Arrange & Act
        var result = TestError.ToResult<int>();
        var errorOr = result.ToErrorOr();

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public void ToErrorOr_When_ResultIsSuccess_Should_ConvertToErrorOrWithValue()
    {
        // Arrange & Act
        var result = TestValue.ToResult();
        var errorOr = result.ToErrorOr();

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }

    [Fact]
    public async Task ToErrorOrAsync_When_ResultTaskIsFailure_Should_ConvertToErrorOrWithError()
    {
        // Arrange & Act
        var errorOr = await ResultTaskWithError()
            .ToErrorOr();

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public async Task ToErrorOrAsync_When_ResultTaskIsSuccess_Should_ConvertToErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = await ResultTaskWithValue()
            .ToErrorOr();

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }

    [Fact]
    public void ToErrorOr_When_MaybeIsNull_Should_ConvertToErrorOrWithError()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null;
        var errorOr = maybe.ToErrorOr(TestError);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public void ToErrorOr_When_MaybeHasValue_Should_ConvertToErrorOrWithValue()
    {
        // Arrange & Act
        var maybe = TestValue.ToMaybe();
        var errorOr = maybe.ToErrorOr(TestError);

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }

    [Fact]
    public async Task ToErrorOrAsync_When_MaybeTaskIsNull_Should_ConvertToErrorOrWithError()
    {
        // Arrange & Act
        var errorOr = await MaybeTaskWithNull()
            .ToErrorOr(TestError);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public async Task ToErrorOrAsync_When_MaybeTaskHasValue_Should_ConvertToErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = await MaybeTaskWithValue()
            .ToErrorOr(TestError);

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }
}