using RichillCapital.Extensions.Monads.UnitTests.Shared;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class MaybeTEnsureTests : MonadTests
{
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
}