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
    public async ValueTask ToMaybeAsync_When_FromValueTask_Should_ConvertToMaybeWithValue()
    {
        // Arrange & Act
        var maybe = await GetTestValueValueTaskAsync().ToMaybe();

        // Assert
        maybe.ShouldBeHas(TestValue);
    }
}