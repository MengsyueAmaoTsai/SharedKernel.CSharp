using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTExplicitConversionsTests : MonadTests
{
    [Fact]
    public void ToMaybe_When_GivenValue_Should_CreateMaybeWithValue()
    {
        // Arrange & Act
        Maybe<int> maybe = Value.ToMaybe();

        // Assert
        maybe.ShouldBeHasValueWith(Value);
    }

    [Fact]
    public void ToMaybe_When_GivenFailureResult_Should_ConvertToMaybeWithNull()
    {
        // Arrange & Act
        Maybe<int> maybe = UnexpectedError.ToResult<int>()
            .ToMaybe();

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void ToMaybe_When_GivenSuccessResult_Should_ConvertToMaybeWithValue()
    {
        // Arrange & Act
        Maybe<int> maybe = Value.ToResult()
            .ToMaybe();

        // Assert
        maybe.ShouldBeHasValueWith(Value);
    }

    [Fact]
    public void ToMaybe_When_GivenErrorOrWithErrors_Should_ConvertToMaybeWithNull()
    {
        // Arrange & Act
        Maybe<int> maybe = UnexpectedError.ToErrorOr<int>()
            .ToMaybe();

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void ToMaybe_When_GivenErrorOrWithValue_Should_ConvertToMaybeWithValue()
    {
        // Arrange & Act
        Maybe<int> maybe = Value.ToErrorOr()
            .ToMaybe();

        // Assert
        maybe.ShouldBeHasValueWith(Value);
    }

    [Fact]
    public async Task ToMaybe_When_GivenTask_Should_CreateMaybeWithValue()
    {
        // Arrange & Act
        Maybe<int> maybe = await GetValueAsync().ToMaybe();

        // Assert
        maybe.ShouldBeHasValueWith(Value);
    }

    [Fact]
    public async Task ToMaybe_When_GivenValueTask_Should_CreateMaybeWithValue()
    {
        // Arrange & Act
        Maybe<int> maybe = await TaskGetValueAsync().ToMaybe();

        // Assert
        maybe.ShouldBeHasValueWith(Value);
    }

    private async Task<int> GetValueAsync() => await Task.FromResult(Value);
    private async ValueTask<int> TaskGetValueAsync() => await new ValueTask<int>(Value);
}