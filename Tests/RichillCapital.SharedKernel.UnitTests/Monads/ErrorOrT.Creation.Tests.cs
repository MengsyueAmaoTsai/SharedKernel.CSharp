using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Is_When_GivenPrimitiveValue_Should_CreateErrorOrWithValue()
    {
        // Arrange & Act
        var errorOrInt = ErrorOr<int>.Is(IntValue);

        // Assert
        errorOrInt.IsError.Should().BeFalse();
        errorOrInt.IsValue.Should().BeTrue();
        errorOrInt.Value.Should().Be(IntValue);
    }

    [Fact]
    public void From_When_GivenError_Should_CreateErrorOrWithError()
    {
        // Arrange & Act
        var errorOrInt = ErrorOr<int>.From(NotFoundError);

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.IsValue.Should().BeFalse();
        errorOrInt.Errors
            .Should().HaveCount(1)
            .And.BeEquivalentTo(new[] { NotFoundError });
    }

    [Fact]
    public void From_When_GivenErrorList_Should_CreateErrorOrWithErrors()
    {
        // Arrange
        var errorList = ValidationErrors.ToList();

        // Act
        var errorOrInt = ErrorOr<int>.From(errorList);

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.IsValue.Should().BeFalse();
        errorOrInt.Errors
            .Should().HaveCount(errorList.Count)
            .And.BeEquivalentTo(errorList);
    }

    [Fact]
    public void From_When_GivenErrorArray_Should_CreateErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOrInt = ErrorOr<int>.From(ValidationErrors);

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.IsValue.Should().BeFalse();
        errorOrInt.Errors
            .Should().HaveCount(ValidationErrors.Length)
            .And.BeEquivalentTo(ValidationErrors);
    }

    [Fact]
    public void Ensure_When_GivenPredicateThatReturnsTrue_Should_CreateErrorOrWithValue()
    {
        // Arrange & Act
        var ensuredErrorOr = ErrorOr<int>.Ensure(IntValue, value => value != 0, NotFoundError);

        // Assert
        ensuredErrorOr.IsError.Should().BeFalse();
        ensuredErrorOr.IsValue.Should().BeTrue();
        ensuredErrorOr.Value.Should().Be(IntValue);
    }

    [Fact]
    public void Ensure_When_GivenPredicateThatReturnsFalse_Should_CreateErrorOrWithError()
    {
        // Arrange & Act
        var ensuredErrorOr = ErrorOr<int>.Ensure(IntValue, value => value == 0, NotFoundError);

        // Assert
        ensuredErrorOr.IsError.Should().BeTrue();
        ensuredErrorOr.IsValue.Should().BeFalse();
        ensuredErrorOr.Errors
            .Should().HaveCount(1)
            .And.BeEquivalentTo(new[] { NotFoundError });
    }

    [Fact]
    public void Combine_When_GivenErrorOrsWithNoErrors_Should_CreateErrorOrWithValue()
    {
        // Arrange
        var errorOrs = new[]
        {
            ErrorOr<int>.Is(10),
            ErrorOr<int>.Is(5),
        };

        // Act
        ErrorOr<int> combinedErrorOr = ErrorOr<int>.Combine(errorOrs);

        // Assert
        combinedErrorOr.IsError.Should().BeFalse();
        combinedErrorOr.IsValue.Should().BeTrue();
        combinedErrorOr.Value.Should().Be(IntValue);
    }

    [Fact]
    public void Combine_When_GivenErrorsAndContainsAnyNonValidationErrors_Should_CreateErrorOrWithFirstError()
    {
        // Arrange
        var errorOrs = new[]
        {
            ErrorOr<int>.Is(IntValue),
            ErrorOr<int>.From(NotFoundError),
            ErrorOr<int>.From(ValidationErrors),
        };

        // Act
        ErrorOr<int> combinedErrorOr = ErrorOr<int>.Combine(errorOrs);

        // Assert
        combinedErrorOr.IsError.Should().BeTrue();
        combinedErrorOr.IsValue.Should().BeFalse();
        combinedErrorOr.Errors
            .Should().HaveCount(1)
            .And.BeEquivalentTo(new[] { NotFoundError });
    }

    [Fact]
    public void Combine_When_GivenErrorsAndContainsOnlyValidationErrors_Should_CreateErrorOrWithErrors()
    {
        // Arrange
        var errorOrs = new[]
        {
            ErrorOr<int>.From(ValidationErrors),
            ErrorOr<int>.From(ValidationErrors),
        };

        // Act
        ErrorOr<int> combinedErrorOr = ErrorOr<int>.Combine(errorOrs);

        // Assert
        combinedErrorOr.IsError.Should().BeTrue();
        combinedErrorOr.IsValue.Should().BeFalse();
        combinedErrorOr.Errors
            .Should().HaveCount(ValidationErrors.Length * 2)
            .And.BeEquivalentTo(ValidationErrors.Concat(ValidationErrors));
    }
}