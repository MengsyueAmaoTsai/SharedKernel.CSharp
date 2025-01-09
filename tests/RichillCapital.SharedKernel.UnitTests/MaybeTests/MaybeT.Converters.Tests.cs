using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeExtensionsConvertersTests : MonadTests
{
    [Fact]
    public void ToMaybe_When_FromValue_Should_ConvertToMaybeWithValue()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToMaybe();

        // Assert
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public async Task ToMaybeAsync_When_FromTask_Should_ConvertToMaybeWithValue()
    {
        // Arrange & Act
        var maybe = await GetTestValueAsync().ToMaybe();

        // // Assert
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public async Task ToMaybeAsync_When_FromValueTask_Should_ConvertToMaybeWithValue()
    {
        // Arrange & Act
        var maybe = await GetTestValueValueTaskAsync().ToMaybe();

        // Assert
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public void ToMaybe_When_ErrorOrHasError_Should_ConvertToNull()
    {
        // Arrange & Act
        Maybe<int> maybe = TestErrors
            .ToErrorOr<int>()
            .ToMaybe();

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void ToMaybe_When_ErrorOrIsValue_Should_ConvertToMaybeWithValue()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToErrorOr()
            .ToMaybe();

        // Assert
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public async Task ToMaybeAsync_When_FromTaskErrorOrHasError_Should_ConvertToNull()
    {
        // Arrange & Act
        var maybe = await ErrorOrTaskWithErrors()
            .ToMaybe();

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task ToMaybeAsync_When_FromTaskErrorOrIsValue_Should_ConvertToMaybeWithValue()
    {
        // Arrange & Act
        var maybe = await ErrorOrTaskWithValue()
            .ToMaybe();

        // Assert
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public void ToMaybe_When_ResultIsFailure_Should_ConvertToNull()
    {
        // Arrange & Act
        var maybe = TestError
            .ToResult<int>()
            .ToMaybe();

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void ToMaybe_When_ResultIsSuccess_Should_ConvertToMaybeWithValue()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToResult()
            .ToMaybe();

        // Assert
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public async Task ToMaybeAsync_When_ResultTaskIsFailure_Should_ConvertToNull()
    {
        // Arrange & Act
        var maybe = await ResultTaskWithError()
            .ToMaybe();

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task ToMaybeAsync_When_ResultTaskIsSuccess_Should_ConvertToMaybeWithValue()
    {
        // Arrange & Act
        var maybe = await ResultTaskWithValue()
            .ToMaybe();

        // Assert
        maybe.ShouldBeHas(TestValue);
    }
}