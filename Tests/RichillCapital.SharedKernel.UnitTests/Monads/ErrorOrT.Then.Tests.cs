using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Then_When_ErrorOrIsError_Should_ReturnErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOrInt = ErrorOr<int>
            .From(NotFoundError)
            .Then(() => "Execute then");

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.IsValue.Should().BeFalse();
        errorOrInt.Errors
            .Should().HaveCount(1)
            .And.BeEquivalentTo(new[] { NotFoundError });
    }

    [Fact]
    public void Then_When_ErrorOrIsValue_Should_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        var expectedValue = "Execute then";
        var errorOrInt = ErrorOr<int>
            .Is(IntValue)
            .Then(() => expectedValue);

        // Assert
        errorOrInt.IsError.Should().BeFalse();
        errorOrInt.IsValue.Should().BeTrue();
        errorOrInt.Value.Should().Be(expectedValue);
    }
}