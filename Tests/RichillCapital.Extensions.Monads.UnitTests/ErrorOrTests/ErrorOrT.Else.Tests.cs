using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTElseTests : MonadTests
{
    [Fact]
    public void Else_When_HasError_Should_ReturnElseValue()
    {
        // Arrange & Act
        var errorOr = TestError.ToErrorOr<int>()
            .Else(TestValue);

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }

    [Fact]
    public void Else_When_HasValue_Should_ReturnOriginal()
    {
        // Arrange & Act
        var errorOr = TestValue.ToErrorOr()
            .Else(0);

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }
}