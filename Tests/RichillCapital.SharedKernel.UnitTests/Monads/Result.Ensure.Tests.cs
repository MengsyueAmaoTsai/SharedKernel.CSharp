using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class ResultTests
{
    [Fact]
    public void Ensure_When_PredicateIsFalse_Should_ReturnFailureResult()
    {
        // Arrange 
        Result result = Result.Ensure(IntValue, value => value < 10, NotFoundError);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(NotFoundError);
    }

    [Fact]
    public void Ensure_When_PredicateIsTrue_Should_ReturnSuccessResult()
    {
        // Arrange 
        Result result = Result.Ensure(IntValue, value => value >= 10, NotFoundError);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }
}