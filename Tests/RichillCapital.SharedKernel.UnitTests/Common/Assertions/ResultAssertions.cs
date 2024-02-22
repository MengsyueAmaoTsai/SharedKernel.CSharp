using FluentAssertions;

using RichillCapital.SharedKernel.Monad;

namespace RichillCapital.SharedKernel.UnitTests.Common.Assertions;

internal static class ResultAssertions
{
    public static void ShouldBeSuccessResult(this Result result)
    {
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().BeEquivalentTo(Error.Null);
    }

    public static void ShouldBeSuccessResultWithValue<TValue>(
        this Result<TValue> result,
        TValue value)
    {
        result.ShouldBeSuccessResult();
        result.Value.Should().NotBeNull();
        result.Value.Should().BeOfType<TValue>();
        result.Value.Should().BeEquivalentTo(value);
    }

    public static void ShouldBeFailureResultWithError<TValue>(
        this Result<TValue> result,
        Error error)
    {
        result.IsFailure.Should().BeTrue();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBeNull();
        result.Error.Should().BeEquivalentTo(error);

        var action = () => result.Value;

        action.Should()
            .Throw<InvalidOperationException>()
            .WithMessage("Cannot access value for a failure result.");
    }

    public static void ShouldBeFailureResultWithError(
        this Result result,
        Error error)
    {
        result.IsFailure.Should().BeTrue();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBeNull();
        result.Error.Should().BeEquivalentTo(error);
    }
}