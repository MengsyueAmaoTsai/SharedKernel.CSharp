using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrExplicitConversionsTests : MonadTests
{
    [Fact]
    public void ToErrorOr_When_GivenValue_Should_CreateErrorOrWithValue()
    {
        // Arrange & Act
        ErrorOr<int> errorOr = Value.ToErrorOr();

        // Assert
        errorOr.ShouldBeValue(Value);
    }

    [Fact]
    public void ToErrorOr_When_GivenError_Should_CreateErrorOrWithError()
    {
        // Arrange & Act
        ErrorOr<int> errorOr = UnexpectedError.ToErrorOr<int>();

        // Assert
        errorOr.ShouldBeError(UnexpectedError);
    }

    [Fact]
    public void ToErrorOr_When_GivenErrorList_Should_CreateErrorOrWithErrors()
    {
        // Arrange & Act
        ErrorOr<int> errorOr = Errors.ToErrorOr<int>();

        // Assert
        errorOr.ShouldBeErrors(Errors);
    }

    [Fact]
    public void ToErrorOr_When_GivenErrorArray_Should_CreateErrorOrWithErrors()
    {
        // Arrange & Act
        ErrorOr<int> errorOr = Errors.ToArray().ToErrorOr<int>();

        // Assert
        errorOr.ShouldBeErrors(Errors);
    }
}