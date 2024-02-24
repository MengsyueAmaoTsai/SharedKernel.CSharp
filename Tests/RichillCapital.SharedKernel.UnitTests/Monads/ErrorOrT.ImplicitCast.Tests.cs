using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void ImplicitCast_When_GivenPrimitiveValue_Should_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        ErrorOr<int> errorOrInt = IntValue;

        // Assert
        errorOrInt.IsError.Should().BeFalse();
        errorOrInt.IsValue.Should().BeTrue();
        errorOrInt.Value.Should().Be(IntValue);
    }

    [Fact]
    public void ImplicitCast_When_GivenError_Should_ReturnErrorOrWithError()
    {
        // Arrange & Act
        ErrorOr<int> errorOrInt = NotFoundError;

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.IsValue.Should().BeFalse();
        errorOrInt.Errors
            .Should().HaveCount(1)
            .And.BeEquivalentTo([NotFoundError]);
    }

    [Fact]
    public void ImplicitCast_When_GivenErrorList_Should_ReturnErrorOrWithErrors()
    {
        // Arrange & Act
        var errorList = ValidationErrors.ToList();
        ErrorOr<int> errorOrInt = errorList;

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.IsValue.Should().BeFalse();
        errorOrInt.Errors
            .Should().HaveCount(errorList.Count)
            .And.BeEquivalentTo(errorList);
    }

    [Fact]
    public void ImplicitCast_When_GivenErrorArray_Should_ReturnErrorOrWithErrors()
    {
        // Arrange & Act
        ErrorOr<int> errorOrInt = ValidationErrors;

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.IsValue.Should().BeFalse();
        errorOrInt.Errors
            .Should().HaveCount(ValidationErrors.Length)
            .And.BeEquivalentTo(ValidationErrors);
    }

    [Fact]
    public void ImplicitCast_When_GivenSuccessResultWithValue_Should_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        Result<int> result = Result.Success(IntValue);
        ErrorOr<int> errorOrInt = result;

        // Assert
        errorOrInt.IsError.Should().BeFalse();
        errorOrInt.IsValue.Should().BeTrue();
        errorOrInt.Value.Should().Be(IntValue);
    }

    [Fact]
    public void ImplicitCast_When_GivenFailureResult_Should_ReturnErrorOrWithError()
    {
        // Arrange & Act
        Result<int> result = Result.Failure<int>(NotFoundError);
        ErrorOr<int> errorOrInt = result;

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.IsValue.Should().BeFalse();
        errorOrInt.Errors
            .Should().HaveCount(1)
            .And.BeEquivalentTo([NotFoundError]);
    }
}