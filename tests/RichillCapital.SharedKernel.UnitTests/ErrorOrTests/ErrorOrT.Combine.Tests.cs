using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;

namespace RichillCapital.SharedKernel.Monads.UnitTests;

public sealed class ErrorOrTCombineTests : MonadTests
{
    [Fact]
    public void Combine_When_AllErrorOrsAreValue_Should_ReturnLastErrorOr()
    {
        // Arrange
        var errorOr1 = 1.ToErrorOr();
        var errorOr2 = 2.ToErrorOr();
        var errorOr3 = 3.ToErrorOr();

        // Act
        var combinedErrorOr = ErrorOr<int>.Combine(errorOr1, errorOr2, errorOr3);

        // Assert
        combinedErrorOr.ShouldBeValue(3);
    }

    [Fact]
    public void Combine_When_AnyErrorOrHasError_Should_ReturnErrorOrWithDistinctErrors()
    {
        // Arrange
        var errorOr1 = TestError.ToErrorOr<int>();
        var errorOr2 = TestErrors.ToErrorOr<int>();
        var errorOr3 = 3.ToErrorOr();

        // Act
        var combinedErrorOr = ErrorOr<int>.Combine(errorOr1, errorOr2, errorOr3);

        // Assert
        combinedErrorOr.ShouldBeErrors([TestError, .. TestErrors]);
        combinedErrorOr.Errors.First().Should().Be(TestError);
    }
}