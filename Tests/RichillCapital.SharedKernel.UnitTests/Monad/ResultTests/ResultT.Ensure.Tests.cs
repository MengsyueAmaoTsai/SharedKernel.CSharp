
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericResultEnsureTests : MonadTests
{
    [Fact]
    public void Ensure_When_PredicateIsTrue_Should_CreateSuccessResultWithProvidedValue()
    {
        // Arrange & Act
        Result<int> result = Result<int>
            .Success(IntValue)
            .Ensure(value => value == IntValue, TestError);

        // Assert
        result.ShouldBeSuccessResultWithValue(IntValue);
    }

    [Fact]
    public void Ensure_When_PredicateIsFalse_Should_CreateFailureResultWithProvidedError()
    {
        // Arrange & Act
        Result<int> result = Result<int>
            .Success(IntValue)
            .Ensure(value => value == 2, TestError);

        // Assert
        result.ShouldBeFailureResultWithError(TestError);
    }
}