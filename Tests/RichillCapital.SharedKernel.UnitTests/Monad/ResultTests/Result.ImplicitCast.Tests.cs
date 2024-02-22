using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class ResultTests
{
    [Fact]
    public void ImplicitCast_Should_ConvertErrorToFailureResult()
    {
        // Arrange & Act
        Result failureResult = TestError;

        // Assert
        failureResult.ShouldBeFailureResultWithError(TestError);
    }
}