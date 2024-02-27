using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads.Common;

public static partial class ErrorOrAssertionExtensions
{
    public static void ShouldBeErrorOrWithValue<TValue>(
        this ErrorOr<TValue> errorOr,
        TValue expectedValue)
    {
        errorOr.IsValue.Should().BeTrue();
        errorOr.IsError.Should().BeFalse();
        errorOr.Value.Should().Be(expectedValue);
        errorOr.Errors.Should().HaveCount(1);
        errorOr.ErrorsOrEmpty.Should().BeEmpty();
    }

    public static void ShouldBeErrorOrWithError<TValue>(
        this ErrorOr<TValue> errorOr,
        Error error)
    {
        errorOr
            .ShouldBeErrorOrWithError();

        errorOr.Errors.Should().Contain(error);
    }

    public static void ShouldBeErrorOrWithErrors<TValue>(
        this ErrorOr<TValue> errorOr,
        IEnumerable<Error> errors)
    {
        errorOr
            .ShouldBeErrorOrWithError();

        errorOr.Errors.Should().BeEquivalentTo(errors);
        errorOr.Errors.Should().HaveCount(errors.Count());
    }

    private static void ShouldBeErrorOrWithError<TValue>(this ErrorOr<TValue> errorOr)
    {
        errorOr.IsValue.Should().BeFalse();
        errorOr.IsError.Should().BeTrue();
        errorOr.ErrorsOrEmpty.Should().NotBeEmpty();
    }
}