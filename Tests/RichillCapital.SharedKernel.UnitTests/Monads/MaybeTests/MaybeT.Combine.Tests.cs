using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void Combine_When_AnyNullInMaybes_Should_ReturnMaybeWithNoValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>
            .Combine(
                Maybe<int>.Ensure(5, x => x > 10),
                Maybe<int>.Ensure(5, x => x < 3),
                Maybe<int>.Ensure(5, x => x > 0));

        // Assert
        maybe.HasNoValue.Should().BeTrue();
    }

    [Fact]
    public void Combine_When_NoNullInMaybes_Should_ReturnMaybeWithFirstValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>
            .Combine(
                Maybe<int>.Ensure(15, x => x > 0),
                Maybe<int>.Ensure(1, x => x < 7),
                Maybe<int>.Ensure(5, x => x > 2),
                Maybe<int>.Ensure(8, x => x > 3));

        // Assert
        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(15);
    }
}