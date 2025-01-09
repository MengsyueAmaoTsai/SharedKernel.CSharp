using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultMatchTests : MonadTests
{
    [Fact]
    public void Match_When_IsSuccess_Should_InvokeOnSuccess_AndReturnResultValue()
    {
        // Arrange & Act
        var result = Result.Success
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(OnSuccess());
    }

    [Fact]
    public void Match_When_IsFailure_Should_InvokeOnFailureWithError_AndReturnResultValue()
    {
        // Arrange & Act
        var result = Result.Failure(TestError)
            .Match(OnSuccess, OnFailure);

        // Assert
        result.Should().Be(OnFailure(TestError));
    }
}