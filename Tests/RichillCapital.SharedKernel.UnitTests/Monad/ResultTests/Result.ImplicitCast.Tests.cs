using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed partial class ResultTests : MonadTests
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