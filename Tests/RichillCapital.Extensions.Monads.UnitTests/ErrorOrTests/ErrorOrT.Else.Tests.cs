using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTElseTests : MonadTests
{
    [Fact]
    public void Else_When_IsValue_Should_ReturnErrorOrWithOriginalValue()
    {
        // Arrange & Act
        var errorOr = Value
            .ToErrorOr()
            .Else(10);

        // Assert
        errorOr.ShouldBeValue(Value);
    }

    [Fact]
    public void Else_When_IsError_Should_ReturnErrorOrWithElseValue()
    {
        // Arrange & Act
        var expectedValue = 10;
        var errorOr = UnexpectedError
            .ToErrorOr<int>()
            .Else(expectedValue);

        // Assert
        errorOr.ShouldBeValue(expectedValue);
    }
}