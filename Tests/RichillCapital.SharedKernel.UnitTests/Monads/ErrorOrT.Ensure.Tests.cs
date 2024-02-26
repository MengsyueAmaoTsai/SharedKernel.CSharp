using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Ensure_When_PredicateIsFalse_Should_ReturnErrorOrWithErrors()
    {
        // Arrange
        ErrorOr<int> errorOrInt = ErrorOr<int>
            .Is(IntValue)
            .Ensure(value => value < 10, NotFoundError);

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.Errors.Should().Contain(NotFoundError);
        errorOrInt.ErrorsOrEmpty.Should().Contain(NotFoundError);
        errorOrInt.ErrorsOrEmpty.Should().HaveCount(1);
    }

    [Fact]
    public void Ensure_When_PredicateIsTrue_Should_ReturnErrorOrWithValue()
    {
        // Arrange
        ErrorOr<int> errorOrInt = ErrorOr<int>
            .Is(IntValue)
            .Ensure(value => value >= 10, NotFoundError);

        // Assert
        errorOrInt.IsValue.Should().BeTrue();
        errorOrInt.Value.Should().Be(IntValue);
        errorOrInt.Errors.Should().HaveCount(1);
        errorOrInt.ErrorsOrEmpty.Should().BeEmpty();
    }
}