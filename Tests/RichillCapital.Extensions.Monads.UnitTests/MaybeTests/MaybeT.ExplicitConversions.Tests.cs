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