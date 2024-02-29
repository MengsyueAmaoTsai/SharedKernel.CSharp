using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class ErrorOrTMatchTests : MonadTests
{
    [Fact]
    public void Match_When_HasError_Should_InvokeOnError_And_ReturnResult()
    {
        // Arrange & Act
        var errorOr = UnexpectedError.ToErrorOr<int>()
            .Match(OnError, OnValue);

        // Assert
        errorOr.Should().Be(0);
    }

    [Fact]
    public void Match_When_HasValue_Should_InvokeOnValue_And_ReturnResult()
    {
        // Arrange & Act
        var errorOr = Value.ToErrorOr()
            .Match(OnError, OnValue);

        // Assert
        errorOr.Should().Be(Value * 2);
    }

    private static int OnError(IEnumerable<Error> _) => 0;

    private static int OnValue(int value) => value * 2;
}