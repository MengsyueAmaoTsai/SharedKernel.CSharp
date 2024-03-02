using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTMergeTests : MonadTests
{
    [Fact]
    public void Merge_When_IsNull_And_AnyIsNull_Should_ReturnFirstNullMaybe()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null;

        var maybes = new[]
        {
            Maybe<int>.Null,
            Maybe<int>.Null,
            Maybe<int>.Null,
            Maybe<int>.Null,
        };

        // Act
        var mergedMaybe = maybe
            .Merge(maybes);

        // Assert
        mergedMaybe.ShouldBeNull();
    }

    [Fact]
    public void Merge_When_IsNull_And_AllHasValue_Should_ReturnFirstNullMaybe()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null;

        var values = new[] { 1, 2, 3 };

        // Act
        var mergedMaybe = maybe
            .Merge(values
                .Select(value => value.ToMaybe())
                .ToArray());

        // Assert
        mergedMaybe.ShouldBeNull();
    }

    [Fact]
    public void Merge_When_HasValue_And_AnyIsNull_Should_ReturnFirstNullMaybe()
    {
        // Arrange & Act
        var maybe = 1.ToMaybe();

        var maybes = new[]
        {
            Maybe<int>.Null,
            Maybe<int>.Null,
            Maybe<int>.Null,
            Maybe<int>.Null,
        };

        // Act
        var mergedMaybe = maybe
            .Merge(maybes);

        // Assert
        mergedMaybe.ShouldBeNull();
    }

    [Fact]
    public void Merge_When_HasValue_And_AllHasValue_Should_ReturnLastMaybeWithValue()
    {
        // Arrange & Act
        var maybe = 1.ToMaybe();

        var values = new[] { 1, 2, 3 };

        // Act
        var mergedMaybe = maybe
            .Merge(values
                .Select(value => value.ToMaybe())
                .ToArray());

        // Assert
        mergedMaybe.ShouldBeHas(values.Last());
    }
}