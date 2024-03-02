using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests.Shared;

public static class MaybeAssertionExtensions
{
    public static void ShouldBeHas<TValue>(
        this Maybe<TValue> maybe,
        TValue expectedValue)
    {
        maybe.HasValue.Should().BeTrue();
        maybe.IsNull.Should().BeFalse();

        maybe.Value.Should().Be(expectedValue);
        maybe.ValueOrDefault.Should().Be(expectedValue);
    }

    public static void ShouldBeNull<TValue>(
        this Maybe<TValue> maybe)
    {
        maybe.HasValue.Should().BeFalse();
        maybe.IsNull.Should().BeTrue();

        maybe.Invoking(maybe => maybe.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage($"Maybe<{typeof(TValue)}> is not value");

        maybe.ValueOrDefault.Should().Be(default(TValue));
    }
}