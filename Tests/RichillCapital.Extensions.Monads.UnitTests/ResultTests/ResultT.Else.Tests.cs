using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTElseTests : MonadTests
{
    [Fact]
    public void Else_When_IsSuccess_Should_ReturnSuccessResultWithOriginalValue()
    {
        // Arrange & Act
        var result = Value
            .ToResult()
            .Else(10);

        // Assert
        result.ShouldBeSuccessWith(Value);
    }

    [Fact]
    public void Else_When_IsFailure_Should_ReturnSuccessResultWithElseValue()
    {
        // Arrange & Act
        var expectedValue = 10;
        var result = UnexpectedError
            .ToResult<int>()
            .Else(expectedValue);

        // Assert
        result.ShouldBeSuccessWith(expectedValue);
    }
}