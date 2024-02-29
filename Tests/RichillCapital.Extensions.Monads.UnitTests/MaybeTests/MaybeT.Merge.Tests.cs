using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTMergeTests
{
    [Fact]
    public void Merge_When_OriginalHaveValue_And_AllMaybesHaveValue_Should_ReturnLastValue()
    {
        // Arrange & Act
        var maybe = 10.ToMaybe().Merge(
            20.ToMaybe(),
            30.ToMaybe());

        // Assert
        maybe.ShouldBeHasValueWith(30);
    }

    [Fact]
    public void Merge_When_OriginalIsEmpty_And_AllMaybesHaveValue_Should_ReturnNull()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Merge(10.ToMaybe(), 20.ToMaybe());

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Merge_When_OriginalHaveValue_And_ContainsNull_Should_ReturnNull()
    {
        // Arrange & Act
        var maybe = 10.ToMaybe()
            .Merge(
                Maybe<int>.Null,
                20.ToMaybe(),
                Maybe<int>.Null);

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Merge_When_OriginalIsNull_And_ContainsNull_Should_ReturnNull()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Merge(
                20.ToMaybe(),
                Maybe<int>.Null,
                Maybe<int>.Null);

        // Assert
        maybe.ShouldBeNull();
    }
}