using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void OrElse_When_ErrorOrHasValue_Should_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        var expected = IntValue;

        ErrorOr<int> errorOrInt = ErrorOr<int>
            .Is(IntValue)
            .OrElse(50);

        // Assert
        errorOrInt.IsValue.Should().BeTrue();
        errorOrInt.Value.Should().Be(expected);
        errorOrInt.ValueOrDefault.Should().Be(expected);
    }

    [Fact]
    public void OrElse_When_ErrorOrHasNoValue_Should_ReturnErrorOrWithElseValue()
    {
        // Arrange & Act
        var expected = 50;

        ErrorOr<int> errorOrInt = ErrorOr<int>
            .Is(NotFoundError)
            .OrElse(expected);

        // Assert
        errorOrInt.IsValue.Should().BeTrue();
        errorOrInt.Value.Should().Be(expected);
        errorOrInt.ValueOrDefault.Should().Be(expected);
    }
}