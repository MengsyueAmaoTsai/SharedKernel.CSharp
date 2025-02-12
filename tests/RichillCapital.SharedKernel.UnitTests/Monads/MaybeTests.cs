namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed class MaybeTests
{
    [Fact]
    public void WithValue_GivenNullValue_Should_ReturnNullMaybe()
    {
        Maybe<string> maybe = Maybe<string>.WithValue(null!);

        maybe.IsNull.ShouldBeTrue();
        maybe.HasValue.ShouldBeFalse();
        Should.Throw<InvalidOperationException>(
            () => maybe.Value,
            Maybe<string>.AccessValueOnNullMaybeMessage);
    }

    [Fact]
    public void WithValue_GivenNonNullValue_Should_ReturnMaybeWithValue()
    {
        var stringValue = "value";
        Maybe<string> maybe = Maybe<string>.WithValue(stringValue);

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
            Maybe<string>.WithValue(sameValue),
            Maybe<string>.WithValue(sameValue));

        maybe1.ShouldBe(maybe2);
    }

    [Fact]
    public void Maybes_WithDifferentValues_ShouldNotBeEqual()
    {
        (Maybe<string> maybe1, Maybe<string> maybe2) = (
            Maybe<string>.WithValue("value1"),
            Maybe<string>.WithValue("value2"));

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
            Maybe<string>.WithValue(value));

        maybe1.ShouldNotBe(maybe2);
    }
}
