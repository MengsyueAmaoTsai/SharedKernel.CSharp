using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests.ErrorOrTests.ErrorOrTTests;

public sealed class ErrorOrTFactoryTests : MonadTests
{
    [Fact]
    public void Is_When_GivenValue_Should_CreateErrorOrWithGivenValue()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.Is(Value);

        // Assert
        errorOr.ShouldBeValue(Value);
    }

    [Fact]
    public void Is_When_GivenErrorList_Should_CreateErrorOrWithGivenError()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.Is(Errors);

        // Assert
        errorOr.ShouldBeErrors(Errors);
    }

    [Fact]
    public void Is_When_GivenErrorArray_Should_CreateErrorOrWithGivenError()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.Is(Errors.ToArray());

        // Assert
        errorOr.ShouldBeErrors(Errors.ToArray());
    }

    [Fact]
    public void Is_When_GivenError_Should_CreateErrorOrWithGivenError()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.Is(UnexpectedError);

        // Assert
        errorOr.ShouldBeError(UnexpectedError);
    }
}