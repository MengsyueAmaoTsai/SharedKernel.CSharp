using RichillCapital.Extensions.Monads.UnitTests.Shared;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class MaybeTEnsureTests : MonadTests
{
    [Fact]
    public void EnsureFactory_When_HasValue_Should_ReturnMaybeWithValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Ensure(TestValue, EnsureTrue);

        // Assert
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public void EnsureFactory_When_EnsureFalse_Should_ReturnNull()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Ensure(TestValue, EnsureFalse);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Ensure_When_IsNull_Should_NotInvokeEnsure_And_ReturnNull()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Ensure(EnsureTrue);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Ensure_When_IsValue_And_EnsureFalse_Should_InvokeEnsure_And_ReturnNull()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToMaybe()
            .Ensure(EnsureFalse);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Ensure_When_IsValue_And_EnsureTrue_Should_InvokeEnsure_And_ReturnValue()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToMaybe()
            .Ensure(EnsureTrue);

        // Assert
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public async Task EnsureAsync_When_IsNull_Should_NotInvokeEnsureTask_And_ReturnNull()
    {
        // Arrange & Act
        var maybe = await Maybe<int>.Null
            .Ensure(EnsureTrueAsync);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task EnsureAsync_When_HasValue_And_EnsureFalse_Should_InvokeEnsureTask_And_ReturnNull()
    {
        // Arrange & Act
        var maybe = await TestValue
            .ToMaybe()
            .Ensure(EnsureFalseAsync);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public async Task EnsureAsync_When_HasValue_And_EnsureTrue_Should_InvokeEnsureTask_And_ReturnValue()
    {
        // Arrange & Act
        var maybe = await TestValue
            .ToMaybe()
            .Ensure(EnsureTrueAsync);

        // Assert
        maybe.ShouldBeHas(TestValue);
    }
}