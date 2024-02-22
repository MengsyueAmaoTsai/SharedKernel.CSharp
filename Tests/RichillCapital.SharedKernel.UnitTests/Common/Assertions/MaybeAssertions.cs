using FluentAssertions;

using RichillCapital.SharedKernel.Monad;

namespace RichillCapital.SharedKernel.UnitTests.Common.Assertions;

internal static class MaybeAssertions
{
    public static void ShouldHasValue<TValue>(
        this Maybe<TValue> maybe,
        TValue value)
    {
        maybe.HasValue.Should().BeTrue();
        maybe.HasNoValue.Should().BeFalse();
        maybe.Value.Should().NotBeNull();
        maybe.Value.Should().BeEquivalentTo(value);
    }

    public static void ShouldHasNoValue<TValue>(this Maybe<TValue> maybe)
    {
        Action action = () => _ = maybe.Value;

        maybe.HasValue.Should().BeFalse();
        maybe.HasNoValue.Should().BeTrue();
        action.Should()
            .Throw<InvalidOperationException>()
            .WithMessage($"Maybe<{typeof(TValue)}> has no value.");
    }
}