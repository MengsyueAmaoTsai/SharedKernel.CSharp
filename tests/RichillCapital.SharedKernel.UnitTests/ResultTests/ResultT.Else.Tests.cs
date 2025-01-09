using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTElseTests : MonadTests
{
    [Fact]
    public void Else_When_IsFailure_Should_ReturnElseValue()
    {
        // Arrange & Act
        var result = TestError.ToResult<int>()
            .Else(TestValue);

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }

    [Fact]
    public void Else_When_IsSuccess_Should_ReturnOriginal()
    {
        // Arrange & Act
        var result = TestValue.ToResult()
            .Else(0);

        // Assert
        result.ShouldBeSuccessWith(TestValue);
    }
}