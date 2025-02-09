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
}
