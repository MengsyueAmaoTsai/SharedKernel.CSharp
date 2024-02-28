using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests.Shared;

public static class MaybeAssertionExtensions
{
    public static void ShouldBeHasValueWith<TValue>(
        this Maybe<TValue> maybe,
        TValue expectedValue)
    {
        maybe.HasValue.Should().BeTrue();
        maybe.IsNull.Should().BeFalse();

        maybe.Value.Should().Be(expectedValue);
        maybe.ValueOrDefault.Should().Be(expectedValue);
    }
}