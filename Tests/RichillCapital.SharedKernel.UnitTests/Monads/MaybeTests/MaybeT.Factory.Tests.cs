using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void Create_Should_CreateMaybeWithValue()
    {
        // Arrange & Act
        var maybeInt = Maybe<int>.Have(default);
        var maybeBool = Maybe<bool>.Have(default);
        var maybeByte = Maybe<byte>.Have(default);
        var maybeDateTime = Maybe<DateTime>.Have(default);

        // Assert
        maybeInt.HasValue.Should().BeTrue();
        maybeInt.Value.Should().Be(0);

        maybeBool.HasValue.Should().BeTrue();
        maybeBool.Value.Should().BeFalse();

        maybeByte.HasValue.Should().BeTrue();
        maybeByte.Value.Should().Be(0);

        maybeDateTime.HasValue.Should().BeTrue();
        maybeDateTime.Value.Should().Be(DateTime.MinValue);
    }

    [Fact]
    public void Create_Should_CreateMaybeWithNullValue()
    {
        // Arrange & Act
        var maybeEmptyString = Maybe<string>.Have(default!);

        // Assert
        maybeEmptyString.HasValue.Should().BeFalse();
        maybeEmptyString.HasNoValue.Should().BeTrue();
    }
}