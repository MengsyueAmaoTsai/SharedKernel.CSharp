
using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericResultTests : MonadTests
{
    // Match
    [Fact]
    public void Match_When_ResultIsFailure_Should_InvokeOnFailure()
    {
        // Arrange & Act
        var intValue = Result<int>
            .Failure(NotFoundError)
            .Match(OnSuccess, OnFailure);

        // Assert
        intValue.Should().Be(0);
    }

    [Fact]
    public void Match_When_ResultIsSuccess_Should_InvokeOnSuccess()
    {
        // Arrange & Act
        var intValue = Result<int>
            .Success(IntValue)
            .Match(OnSuccess, OnFailure);

        // Assert
        intValue.Should().Be(IntValue + 10);
    }

    // MatchAsync

    [Fact]
    public async Task MatchAsync_When_ResultIsFailure_Should_InvokeOnFailure()
    {
        // Arrange & Act
        var intValue = await Result<int>
            .Failure(NotFoundError)
            .Match(OnSuccessAsync, OnFailureAsync);

        // Assert
        intValue.Should().Be(0);
    }

    [Fact]
    public async Task MatchAsync_When_ResultIsSuccess_Should_InvokeOnSuccess()
    {
        // Arrange & Act
        var intValue = await Result<int>
            .Success(IntValue)
            .Match(OnSuccessAsync, OnFailureAsync);

        // Assert
        intValue.Should().Be(IntValue + 10);
    }
}