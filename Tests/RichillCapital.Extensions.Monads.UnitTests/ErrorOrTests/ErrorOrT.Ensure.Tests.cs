using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTEnsureTests : MonadTests
{
    [Fact]
    public void EnsureFactory_When_EnsureFailure_Should_CreateErrorOrWithError()
    {
        // Arrange & Act
        var expectedError = Error.Invalid("Wrong number");

        var errorOr = ErrorOr<int>
            .Ensure(3, value => value == 4, expectedError);

        // Assert
        errorOr.ShouldBeError(expectedError);
    }

    [Fact]
    public void EnsureFactory_When_EnsureSuccess_Should_CreateErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>
            .Ensure(3, value => value == 3, Error.Invalid("Wrong number"));

        // Assert
        errorOr.ShouldBeValue(3);
    }

    [Fact]
    public void EnsureFactory_When_AnyFailure_Should_CreateErrorOrWithError()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.Ensure(
            Value,
            (value => value == 10, UnexpectedError),
            (value => value == 20, NotFoundError),
            (value => value == 30, NotFoundError));

        // Assert
        errorOr.ShouldBeErrors([UnexpectedError, NotFoundError]);
    }

    [Fact]
    public void EnsureFactory_When_NoFailure_Should_CreateErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.Ensure(
            Value,
            (value => value == 5, UnexpectedError),
            (value => value < 10, NotFoundError),
            (value => value > 0, NotFoundError),
            (value => value <= 5, NotFoundError));

        // Assert
        errorOr.ShouldBeValue(Value);
    }

    [Fact]
    public void EnsureFactory_When_EnsureFailure_Should_InvokeErrorFactory_And_ReturnErrorOrWithError()
    {
        // Arrange
        var expectedError = ErrorFactory(Value);

        // Act
        var result = ErrorOr<int>.
            Ensure(Value, value => value == 3, ErrorFactory);

        // Assert
        result.ShouldBeError(expectedError);
    }

    [Fact]
    public void EnsureFactory_When_EnsureSuccess_Should_NotInvokeErrorFactory_And_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        var result = ErrorOr<int>
            .Ensure(Value, value => value == Value, ErrorFactory);

        // Assert
        result.ShouldBeValue(Value);
    }
}