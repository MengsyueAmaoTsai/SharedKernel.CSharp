namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed class MaybeTests
{
    [Fact]
    public void With_GivenNullValue_Should_ReturnNullMaybe()
    {
        Maybe<string> maybe = Maybe<string>.With(null!);

        maybe.IsNull.ShouldBeTrue();
        maybe.HasValue.ShouldBeFalse();
        Should.Throw<InvalidOperationException>(
            () => maybe.Value,
            Maybe<string>.AccessValueOnNullMaybeMessage);
    }

    [Fact]
    public void With_GivenNonNullValue_Should_ReturnMaybeWithValue()
    {
        var stringValue = "value";
        Maybe<string> maybe = Maybe<string>.With(stringValue);

        maybe.HasValue.ShouldBeTrue();
        maybe.IsNull.ShouldBeFalse();
        maybe.Value.ShouldBe(stringValue);
    }

    [Fact]
    public void Null_Should_ReturnNullMaybe()
    {
        Maybe<string> maybe = Maybe<string>.Null();

        maybe.IsNull.ShouldBeTrue();
        maybe.HasValue.ShouldBeFalse();
        Should.Throw<InvalidOperationException>(
            () => maybe.Value,
            Maybe<string>.AccessValueOnNullMaybeMessage);
    }

    [Fact]
    public void Maybes_WithSameValue_Should_BeEqual()
    {
        var sameValue = "value";

        (Maybe<string> maybe1, Maybe<string> maybe2) = (
            Maybe<string>.With(sameValue),
            Maybe<string>.With(sameValue));

        maybe1.ShouldBe(maybe2);
    }

    [Fact]
    public void Maybes_WithDifferentValues_ShouldNotBeEqual()
    {
        (Maybe<string> maybe1, Maybe<string> maybe2) = (
            Maybe<string>.With("value1"),
            Maybe<string>.With("value2"));

        maybe1.ShouldNotBe(maybe2);
    }

    [Fact]
    public void NullMaybes_Should_BeEqual()
    {
        (Maybe<string> maybe1, Maybe<string> maybe2) = (
            Maybe<string>.Null(),
            Maybe<string>.Null());

        maybe1.ShouldBe(maybe2);
    }

    [Fact]
    public void NullMaybe_Should_NotBeEqualToValueMaybe()
    {
        var value = "value";

        (Maybe<string> maybe1, Maybe<string> maybe2) = (
            Maybe<string>.Null(),
            Maybe<string>.With(value));

        maybe1.ShouldNotBe(maybe2);
    }
}
