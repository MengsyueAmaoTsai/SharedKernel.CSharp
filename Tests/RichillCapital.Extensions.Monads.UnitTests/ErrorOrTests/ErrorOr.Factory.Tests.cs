using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrFactoryTests : MonadTests
{
    [Fact]
    public void With_When_GivenValue_Should_CreateErrorOrWithValue()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>.With(TestValue);

        // Assert
        errorOr.ShouldBeValue(TestValue);
    }

    [Fact]
    public void WithError_When_GivenError_Should_CreateErrorOrWithError()
    {
        // Arrange & Act
        var errorOr = ErrorOr<Error>
            .WithError(TestError);

        // Assert
        errorOr.ShouldBeError(TestError);
    }

    [Fact]
    public void WithErrors_When_GivenErrorsArray_Should_CreateErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>
            .WithErrors(TestErrors.ToArray());

        // Assert
        errorOr.ShouldBeErrors(TestErrors);
    }

    [Fact]
    public void WithErrors_When_GivenErrorsList_Should_CreateErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>
            .WithErrors(TestErrors.ToList());

        // Assert
        errorOr.ShouldBeErrors(TestErrors);
    }
}