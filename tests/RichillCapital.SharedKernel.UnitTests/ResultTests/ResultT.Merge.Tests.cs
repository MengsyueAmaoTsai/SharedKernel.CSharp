using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTMergeTests : MonadTests
{
    [Fact]
    public void Merge_When_IsFailure_And_AnyFailureResult_Should_ReturnFirstFailureResultWithError()
    {
        // Arrange & Act
        var result = TestError.ToResult<int>();

        var errors = new[]
        {
            Error.Invalid("Invalid"),
            Error.NotFound("NotFound"),
            Error.Unauthorized("Unauthorized"),
            Error.Unauthorized("Unauthorized"),
        };

        // Act
        var mergedResult = result
            .Merge(errors
                .Select(error => error.ToResult<int>())
                .ToArray());

        // Assert
        mergedResult.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public void Merge_When_IsFailure_And_AllSuccess_Should_ReturnFirstFailureResultWithError()
    {
        // Arrange & Act
        var result = TestError.ToResult<int>();

        var values = new[] { 1, 2, 3 };

        // Act
        var mergedResult = result
            .Merge(values
                .Select(value => value.ToResult())
                .ToArray());

        // Assert
        mergedResult.ShouldBeFailureWith(TestError);
    }

    [Fact]
    public void Merge_When_IsSuccess_And_AnyFailureResult_Should_ReturnFirstFailureResultWithError()
    {
        // Arrange & Act
        var result = TestValue.ToResult();

        var errors = new[]
        {
            Error.Invalid("Invalid"),
            Error.NotFound("NotFound"),
            Error.Unauthorized("Unauthorized"),
            Error.Unauthorized("Unauthorized"),
        };

        // Act
        var mergedResult = result
            .Merge(errors
                .Select(error => error.ToResult<int>())
                .ToArray());

        // Assert
        mergedResult.ShouldBeFailureWith(errors.First());
    }

    [Fact]
    public void Merge_When_IsSuccess_And_AllSuccess_Should_ReturnLastSuccessResultWithValue()
    {
        // Arrange & Act
        var result = TestValue.ToResult();

        var values = new[] { 1, 2, 3 };

        // Act
        var mergedResult = result
            .Merge(values
                .Select(value => value.ToResult())
                .ToArray());

        // Assert
        mergedResult.ShouldBeSuccessWith(values.Last());
    }
}