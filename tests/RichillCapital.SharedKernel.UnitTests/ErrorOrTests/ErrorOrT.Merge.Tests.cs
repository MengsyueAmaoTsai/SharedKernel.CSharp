using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTMergeTests : MonadTests
{
    [Fact]
    public void Merge_When_HasError_And_AnyHasError_Should_ReturnErrorOrWithErrors()
    {
        // Arrange & Act
        var otherErrors = new[]
        {
            Error.Invalid("Invalid"),
            Error.NotFound("NotFound"),
            Error.Unauthorized("Unauthorized"),
            Error.Unauthorized("Unauthorized"),
        };

        var errorOr = TestError
            .ToErrorOr<int>();

        // Act
        var merged = errorOr
            .Merge(otherErrors
                .Select(error => error.ToErrorOr<int>())
            .ToArray());

        // Assert
        merged.ShouldBeErrors([
            TestError,
            Error.Invalid("Invalid"),
            Error.NotFound("NotFound"),
            Error.Unauthorized("Unauthorized"),
        ]);
    }

    [Fact]
    public void Merge_When_HasError_And_AllAreValues_Should_ReturnFirstErrorOrWithErrors()
    {
        // Arrange & Act
        var values = new[] { 1, 2, 3 };

        var errorOr = TestErrors
            .ToErrorOr<int>();

        // Act
        var merged = errorOr
            .Merge(values
                .Select(value => value.ToErrorOr())
            .ToArray());

        // Assert
        merged.ShouldBeErrors(TestErrors);
    }

    [Fact]
    public void Merge_When_IsValue_And_AnyHasError_ShouldReturnErrorOrWithErrors()
    {
        // Arrange & Act
        var otherErrors = new[]
        {
            Error.NotFound("NotFound"),
            Error.Unauthorized("Unauthorized"),
            Error.Unauthorized("Unauthorized"),
        };

        // Act
        var merged = TestValue
            .ToErrorOr()
            .Merge(TestValue.ToErrorOr())
            .Merge(otherErrors
                .Select(error => error.ToErrorOr<int>())
            .ToArray());

        // Assert
        merged.ShouldBeErrors([
            Error.NotFound("NotFound"),
            Error.Unauthorized("Unauthorized"),
        ]);
    }

    [Fact]
    public void Merge_When_IsValid_And_AllAreValues_Should_ReturnLastErrorOrWithValue()
    {
        // Arrange & Act
        var values = new[] { 1, 2, 3 };

        // Act
        var merged = TestValue
            .ToErrorOr()
            .Merge(TestValue.ToErrorOr())
            .Merge(values
                .Select(value => value.ToErrorOr())
            .ToArray());

        // Assert
        merged.ShouldBeValue(values.Last());
    }
}