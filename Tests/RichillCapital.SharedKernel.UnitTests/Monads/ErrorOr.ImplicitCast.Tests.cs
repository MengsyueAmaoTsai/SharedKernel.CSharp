using FluentAssertions;

using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class ErrorOrTests
{
    private static readonly int IntValue = 10;
    private static readonly Error NotFoundError = Error.NotFound("Not found");
    private static readonly Error[] ValidationErrors =
    [
        Error.Invalid("Invalid"),
        Error.Invalid("Invalid 2"),
        Error.Invalid("Invalid 3"),
        Error.Invalid("Invalid 4"),
        Error.Invalid("Invalid 5"),
    ];

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
}