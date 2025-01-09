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
    public async Task ToResultAsync_When_FromTask_Should_ConvertToSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> result = await GetTestValueAsync().ToResult();

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }

    [Fact]
    public async Task ToResultAsync_When_FromValueTask_Should_ConvertToSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> result = await GetTestValueValueTaskAsync().ToResult();

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

    [Fact]
    public void ToResult_When_ErrorOrHasError_Should_ConvertToFailureResultWithFirstError()
    {
        // Arrange & Act
        Result<int> result = TestErrors.ToErrorOr<int>().ToResult();

        // Assert
        result.ShouldBeFailureWith(TestErrors.First());
    }

    [Fact]
    public void ToResult_When_ErrorOrIsValue_Should_ConvertToSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> result = TestValue.ToErrorOr().ToResult();

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }

    [Fact]
    public async Task ToResultAsync_When_ErrorOrTaskHasError_Should_ConvertToFailureResultWithFirstError()
    {
        // Arrange & Act
        Result<int> result = await ErrorOrTaskWithErrors().ToResult();

        // Assert
        result.ShouldBeFailureWith(TestErrors.First());
    }

    [Fact]
    public async Task ToResultAsync_When_ErrorOrTaskIsValue_Should_ConvertToSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> result = await ErrorOrTaskWithValue().ToResult();

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }

    [Fact]
    public void ToResult_When_MaybeIsNull_Should_ConvertToFailureResultWithGivenError()
    {
        // Arrange & Act
        Result<int> result = Maybe<int>.Null.ToResult(TestError);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public void ToResult_When_MaybeHasValue_Should_ConvertToSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> result = TestValue.ToMaybe().ToResult(TestError);

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }

    [Fact]
    public async Task ToResultAsync_When_MaybeTaskIsNull_Should_ConvertToFailureResultWithGivenError()
    {
        // Arrange & Act
        Result<int> result = await MaybeTaskWithNull().ToResult(TestError);

        // Assert
        result.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public async Task ToResultAsync_When_MaybeTaskHasValue_Should_ConvertToSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> result = await MaybeTaskWithValue().ToResult(TestError);

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }
}