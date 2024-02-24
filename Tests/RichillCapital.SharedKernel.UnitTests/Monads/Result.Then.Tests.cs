using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class ResultTests
{
    [Fact]
    public void Then_When_ResultIsSuccess_Should_ExecuteActionAndReturnSuccessResult()
    {
        // Arrange & Act
        Result result = Result
            .Success()
            .Then(() => { });

        Result<int> resultT = Result
            .Success(IntValue)
            .Then(() => { });

        // Assert
        result.IsSuccess.Should().BeTrue();
        resultT.IsSuccess.Should().BeTrue();
        resultT.Value.Should().Be(IntValue);
    }
    [Fact]
    public void Then_When_ResultIsFailure_ShouldNot_ExecuteActionAndReturnFailureResult()
    {
        // Arrange & Act
        Result result = Result
            .Failure(NotFoundError)
            .Then(() => { });

        Result<int> resultT = Result<int>
            .Failure(NotFoundError)
            .Then(() => { });

        // Assert
        result.IsSuccess.Should().BeFalse();
        resultT.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(NotFoundError);
        resultT.Error.Should().Be(NotFoundError);
    }

    [Fact]
    public void Then_When_ResultIsSuccess_Should_ExecuteFunctionReturnSuccessResultWithValue()
    {
        // Arrange
        var result = Result
            .Success()
            .Then(() => 100);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Value.Should().Be(100);
    }

    [Fact]
    public void Then_When_ResultIsFailure_ShouldNot_ExecuteFunctionAndReturnFailureResult()
    {
        // Arrange
        var result = Result
            .Failure(NotFoundError)
            .Then(() => 100);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(NotFoundError);
    }
}