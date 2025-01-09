using RichillCapital.Extensions.Monads.UnitTests.Shared;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class MaybeTCombineTests
{
    [Fact]
    public void Combine_When_AllMaybesAreHaveValue_Should_ReturnLastValue()
    {
        // Arrange
        var maybe1 = 1.ToMaybe();
        var maybe2 = 2.ToMaybe();
        var maybe3 = 3.ToMaybe();

        // Act
        var combinedMaybe = Maybe<int>.Combine(maybe1, maybe2, maybe3);

        // Assert
        combinedMaybe.ShouldBeHas(3);
    }

    [Fact]
    public void Combine_When_AnyMaybeIsNull_Should_ReturnNull()
    {
        // Arrange
        var maybe1 = 1.ToMaybe();
        var maybe2 = Maybe<int>.Null;
        var maybe3 = 3.ToMaybe();

        // Act
        var combinedMaybe = Maybe<int>.Combine(maybe1, maybe2, maybe3);

        // Assert
        combinedMaybe.ShouldBeNull();
    }
}