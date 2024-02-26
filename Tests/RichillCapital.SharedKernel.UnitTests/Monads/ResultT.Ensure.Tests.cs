using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Ensure_When_PredicateIsFalse_Should_ReturnFailureResult()
    {
        // Arrange 
        Result<int> result = Result<int>
            .Success(IntValue)
            .Ensure(value => value < 10, NotFoundError);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(NotFoundError);
    }

    [Fact]
    public void Ensure_When_PredicateIsTrue_Should_ReturnSuccessResult()
    {
        // Arrange 
        Result<int> result = Result<int>
            .Success(IntValue)
            .Ensure(value => value >= 10, NotFoundError);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(IntValue);
    }

    [Fact]
    public void EnsureFactory_When_PredicateIsTrue_Should_ReturnSuccessResult()
    {
        // Arrange 
        var result = Result<int>
            .Ensure(IntValue, value => value >= 10, Error.Invalid("Value is invalid"));

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void EnsureFactory_When_PredicateIsFalse_Should_ReturnFailureResult()
    {
        // Arrange 
        var result = Result<int>
            .Ensure(IntValue, value => value < 10, Error.Invalid("Value is invalid"));

        // Assert
        result.IsFailure.Should().BeTrue();
    }

    [Fact]
    public void Ensure_When_PredicateInTupleIsFalse_Should_ReturnFailureResult()
    {
        // Arrange 
        var expectedError = Error.Invalid("Value is invalid");

        var result = Result<int>
            .Success(IntValue)
            .Ensure((value => value < 10, expectedError));

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(expectedError);
    }

    [Fact]
    public void Ensure_When_PredicateInTupleIsTrue_Should_ReturnSuccessResult()
    {
        // Arrange 
        var result = Result<int>
            .Success(IntValue)
            .Ensure((value => value >= 10, Error.Invalid("Value is invalid")));

        // Assert
        result.IsSuccess.Should().BeTrue();
    }
}