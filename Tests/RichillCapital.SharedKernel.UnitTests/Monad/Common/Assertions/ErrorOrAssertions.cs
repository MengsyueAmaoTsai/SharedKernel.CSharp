using FluentAssertions;

using RichillCapital.SharedKernel.Monad;

namespace RichillCapital.SharedKernel.UnitTests.Monad.Common.Assertions;

public static class ErrorOrAssertions
{
    public static void ShouldBeErrors<TValue>(
        this ErrorOr<TValue> errorOr,
        IEnumerable<Error> errors)
    {
        var action = () => _ = errorOr.Value;

        errorOr.IsError.Should().BeTrue();
        errorOr.IsValue.Should().BeFalse();
        errorOr.Errors.Should().BeEquivalentTo(errors);
        errorOr.Errors.Should().HaveCount(errors.Count());

        action.Should()
            .Throw<InvalidOperationException>()
            .WithMessage("Cannot access value for an error result.");
    }

    public static void ShouldBeValue<TValue>(
        this ErrorOr<TValue> errorOr,
        TValue value)
    {
        errorOr.IsError.Should().BeFalse();
        errorOr.IsValue.Should().BeTrue();
        errorOr.Value.Should().BeOfType<TValue>();
        errorOr.Value.Should().Be(value);
        errorOr.Errors.Should().HaveCount(1);
        errorOr.Errors.First().Should().Be(Error.Null);
    }
}