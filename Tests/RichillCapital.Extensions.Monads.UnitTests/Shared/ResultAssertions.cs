using FluentAssertions;

using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests.Shared;

public static partial class ResultAssertionExtensions
{
    public static void ShouldBeSuccessWith<TValue>(
        this Result<TValue> result,
        TValue expectedValue)
    {
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();

        result.Value.Should().Be(expectedValue);
        result.ValueOrDefault.Should().Be(expectedValue);

        result.Error.Should().Be(Error.Null);
    }

    public static void ShouldBeFailureWith<TValue>(
        this Result<TValue> result,
        Error expectedError)
    {
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();

        result.Invoking(maybe => maybe.Value)
            .Should().Throw<InvalidOperationException>()
            .WithMessage($"Cannot access the value of a failed result.");

        result.ValueOrDefault.Should().Be(default(TValue));

        result.Error.Should().Be(expectedError);
    }
}