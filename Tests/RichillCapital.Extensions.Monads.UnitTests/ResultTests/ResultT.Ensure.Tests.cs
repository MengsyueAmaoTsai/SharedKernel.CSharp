using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTEnsureTests : MonadTests
{
    [Fact]
    public void EnsureFactory_When_EnsureFailure_Should_Create_FailureResultWithError()
    {
        // Arrange & Act
        var expectedError = Error.Invalid("Wrong number");

        var result = Result<int>
            .Ensure(Value, value => value == 3, expectedError);

        // Assert
        result.ShouldBeFailureWith(expectedError);
    }

    [Fact]
    public void EnsureFactory_When_EnsureSuccess_Should_Create_SuccessResult()
    {
        // Arrange & Act
        var result = Result<int>
            .Ensure(Value, value => value == Value, Error.Invalid("Wrong number"));

        // Assert
        result.ShouldBeSuccessWith(Value);
    }

    [Fact]
    public void EnsureFactory_When_AnyFailure_Should_Create_FailureResultWithError()
    {
        // Arrange & Act
        var expectedError = Error.Invalid("Wrong number");

        var result = Result<int>
            .Ensure(
                Value,
                (value => value >= 10, expectedError),
                (value => value <= 20, Error.Invalid("Value is greater than 20")));

        // Assert
        result.ShouldBeFailureWith(expectedError);
    }

    [Fact]
    public void EnsureFactory_When_NoFailure_Should_Create_SuccessResult()
    {
        // Arrange & Act
        var result = Result<int>
            .Ensure(
                Value,
                (value => value <= 10, Error.Invalid("Value is less than 10")),
                (value => value <= 20, Error.Invalid("Value is greater than 20")),
                (value => value % 2 == 1, Error.Invalid("Value is not even")));

        // Assert
        result.ShouldBeSuccessWith(Value);
    }
}