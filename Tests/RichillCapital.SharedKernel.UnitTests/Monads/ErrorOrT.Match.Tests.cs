using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Match_When_ErrorOrIsError_Should_InvokeOnError()
    {
        // Arrange & Act
        var intValue = ErrorOr<int>
            .Is(NotFoundError)
            .Match(OnError, OnValue);

        // Assert
        intValue.Should().Be(0);
    }

    [Fact]
    public void Match_When_ErrorOrIsValue_Should_InvokeOnValue()
    {
        // Arrange & Act
        var intValue = ErrorOr<int>
            .Is(IntValue)
            .Match(OnError, OnValue);

        // Assert
        intValue.Should().Be(IntValue + 10);
    }

    [Fact]
    public async Task MatchAsync_When_ErrorOrIsError_Should_InvokeOnError()
    {
        // Arrange & Act
        var intValue = await ErrorOr<int>
            .Is(NotFoundError)
            .Match(OnErrorAsync, OnValueAsync);

        // Assert
        intValue.Should().Be(0);
    }

    [Fact]
    public async Task MatchAsync_When_ErrorOrIsValue_Should_InvokeOnValue()
    {
        // Arrange & Act
        var intValue = await ErrorOr<int>
            .Is(IntValue)
            .Match(OnErrorAsync, OnValueAsync);

        // Assert
        intValue.Should().Be(IntValue + 10);
    }

    [Fact]
    public async Task MatchAsync_When_ErrorOrTaskIsError_Should_InvokeOnError()
    {
        // Arrange & Act
        var intValue = await Task.FromResult(ErrorOr<int>
            .Is(NotFoundError))
            .Match(OnError, OnValue);

        // Assert
        intValue.Should().Be(0);
    }

    [Fact]
    public async Task MatchAsync_When_ErrorOrTaskIsValue_Should_InvokeOnValue()
    {
        // Arrange & Act
        var intValue = await Task.FromResult(ErrorOr<int>
            .Is(IntValue))
            .Match(OnError, OnValue);

        // Assert
        intValue.Should().Be(IntValue + 10);
    }
}