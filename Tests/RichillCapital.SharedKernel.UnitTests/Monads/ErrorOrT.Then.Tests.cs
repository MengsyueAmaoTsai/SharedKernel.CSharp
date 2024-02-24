using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Then_When_ErrorOrIsError_ShouldNot_ExecuteFunctionAndReturnErrorOrWithErrors()
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
    public void Then_When_ErrorOrIsValue_Should_ExecuteFunctionAndReturnErrorOrWithValue()
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

    [Fact]
    public void Then_When_ErrorOrIsError_ShouldNot_ExecutionActionAndReturnErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOrInt = ErrorOr<int>
            .From(NotFoundError)
            .Then(() => { });

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.IsValue.Should().BeFalse();
        errorOrInt.Errors
            .Should().HaveCount(1)
            .And.BeEquivalentTo(new[] { NotFoundError });
    }

    [Fact]
    public void Then_When_ErrorOrIsValue_Should_ExecuteActionAndReturnErrorOrWithValue()
    {
        // Arrange & Act
        var errorOrInt = ErrorOr<int>
            .Is(IntValue)
            .Then(() => { });


        // Assert
        errorOrInt.IsError.Should().BeFalse();
        errorOrInt.IsValue.Should().BeTrue();
        errorOrInt.Value.Should().Be(IntValue);
    }

    [Fact]
    public void Then_When_ErrorOrIsError_ShouldNot_ExecuteActionWithValueAndReturnErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOrInt = ErrorOr<int>
            .From(NotFoundError)
            .Then(value => value += 9);

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.IsValue.Should().BeFalse();
        errorOrInt.Errors
            .Should().HaveCount(1)
            .And.BeEquivalentTo(new[] { NotFoundError });
    }

    [Fact]
    public void Then_When_ErrorOrIsValue_Should_ExecuteActionWithValueAndReturnErrorOrWithValue()
    {
        // Arrange & Act
        var errorOrInt = ErrorOr<int>
            .Is(IntValue)
            .Then(value => value += 9);

        // Assert
        errorOrInt.IsError.Should().BeFalse();
        errorOrInt.IsValue.Should().BeTrue();
        errorOrInt.Value.Should().Be(10);
    }
}