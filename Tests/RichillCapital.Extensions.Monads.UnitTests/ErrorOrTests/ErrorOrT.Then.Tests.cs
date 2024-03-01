using RichillCapital.Extensions.Monads.UnitTests.Shared;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class ErrorOrTThenTests : MonadTests
{
    [Fact]
    public void Then_When_HasError_Should_NotInvokeFactory_And_ReturnErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOr = TestErrors
            .ToErrorOr<int>()
            .Then(MapValueToResult);

        // Assert
        errorOr.ShouldBeErrors(TestErrors);
    }

    [Fact]
    public void Then_When_HasValue_Should_InvokeFactory_And_ReturnErrorOrWithResultValue()
    {
        // Arrange & Act
        var errorOr = TestValue
            .ToErrorOr()
            .Then(MapValueToResult);

        // Assert
        errorOr.ShouldBeValue(MapValueToResult(TestValue));
    }
}