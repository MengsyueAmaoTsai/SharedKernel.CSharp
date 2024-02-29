using FluentAssertions;

using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests.Shared;

public static class ErrorOrAssertionExtensions
{
    public static void ShouldBeValue<TValue>(
        this ErrorOr<TValue> errorOr,
        TValue expectedValue)
    {
        errorOr.HasError.Should().BeFalse();
        errorOr.IsValue.Should().BeTrue();

        errorOr.Value.Should().Be(expectedValue);
        errorOr.ValueOrDefault.Should().Be(expectedValue);

        errorOr.Errors.Should().HaveCount(1);
        errorOr.Errors.First().Message.Should().Be($"ErrorOr<{typeof(TValue)}> is not error");
        errorOr.ErrorsOrEmpty.Should().BeEmpty();
    }

    public static void ShouldBeError<TValue>(
        this ErrorOr<TValue> errorOr,
        Error expectedError)
    {
        errorOr.ShouldBeError();

        errorOr.Errors.Should().HaveCount(1);
        errorOr.Errors.First().Should().Be(expectedError);

        errorOr.ErrorsOrEmpty.Should().HaveCount(1);
        errorOr.ErrorsOrEmpty.Should().BeEquivalentTo([expectedError]);
    }

    public static void ShouldBeErrors<TValue>(
        this ErrorOr<TValue> errorOr,
        IEnumerable<Error> expectedErrors)
    {
        errorOr.ShouldBeError();

        errorOr.Errors.Should().HaveCount(expectedErrors.Count());
        errorOr.Errors.Should().BeEquivalentTo(expectedErrors);

        errorOr.ErrorsOrEmpty.Should().HaveCount(expectedErrors.Count());
        errorOr.ErrorsOrEmpty.Should().BeEquivalentTo(expectedErrors);
    }

    // public static void ShouldBeErrors<TValue>(
    //      this ErrorOr<TValue> errorOr,
    //      Error[] expectedErrors)
    // {
    //     errorOr.ShouldBeError();

    //     errorOr.Errors.Should().HaveCount(expectedErrors.Length);
    //     errorOr.Errors.Should().BeEquivalentTo(expectedErrors);

    //     errorOr.ErrorsOrEmpty.Should().HaveCount(expectedErrors.Length);
    //     errorOr.ErrorsOrEmpty.Should().BeEquivalentTo(expectedErrors);
    // }

    private static void ShouldBeError<TValue>(this ErrorOr<TValue> errorOr)
    {
        errorOr.HasError.Should().BeTrue();
        errorOr.IsValue.Should().BeFalse();

        errorOr.Invoking(e => e.Value).Should().Throw<InvalidOperationException>()
            .WithMessage($"ErrorOr<{typeof(TValue)}> is not value");

        errorOr.ValueOrDefault.Should().Be(default(TValue));
    }
}