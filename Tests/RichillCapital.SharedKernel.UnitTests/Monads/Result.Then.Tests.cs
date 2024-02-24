using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class ResultTests
{
    [Fact]
    public void Then_When_ResultIsSuccess_Should_ExecuteActionAndReturnSuccessResult()
    {
        // Arrange
        Result result = Result.Success();
        Result<int> resultT = Result.Success(IntValue);

        // Act
        Result result2 = result.Then(() => { });
        Result<int> resultT2 = resultT.Then(() => { });

        // Assert
        result2.IsSuccess.Should().BeTrue();
        resultT2.IsSuccess.Should().BeTrue();
        resultT2.Value.Should().Be(IntValue);
    }
}