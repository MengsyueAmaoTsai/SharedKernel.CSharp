using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Is_When_GivenValue_Should_ReturnErrorOrWithValue()
    {
        // Arrange & Act
        ErrorOr<int> errorOrInt = ErrorOr<int>.Is(IntValue);

        ErrorOr<string> errorOrString = ErrorOr<string>.Is(string.Empty);

        // Assert
        errorOrInt.IsValue.Should().BeTrue();
        errorOrInt.Value.Should().Be(IntValue);

        errorOrString.IsValue.Should().BeTrue();
        errorOrString.Value.Should().Be(string.Empty);
    }

    [Fact]
    public void Is_When_GivenError_Should_ReturnErrorOrWithError()
    {
        // Arrange & Act
        ErrorOr<int> errorOrInt = ErrorOr<int>.Is(NotFoundError);

        ErrorOr<string> errorOrString = ErrorOr<string>.Is(NotFoundError);

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.Errors.Should().Contain(NotFoundError);

        errorOrString.IsError.Should().BeTrue();
        errorOrString.Errors.Should().Contain(NotFoundError);
    }

    [Fact]
    public void Is_When_GivenListOfErrors_Should_ReturnErrorOrWithErrors()
    {
        // Arrange & Act
        ErrorOr<int> errorOrInt = ErrorOr<int>.Is(ValidationErrors);
        ErrorOr<string> errorOrString = ErrorOr<string>.Is(ValidationErrors);

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.Errors.Should().Contain(ValidationErrors);

        errorOrString.IsError.Should().BeTrue();
        errorOrString.Errors.Should().Contain(ValidationErrors);
    }

    [Fact]
    public void Is_When_GivenArrayOfErrors_Should_ReturnErrorOrWithErrors()
    {
        // Arrange & Act
        ErrorOr<int> errorOrInt = ErrorOr<int>.Is(ValidationErrors.ToArray());
        ErrorOr<string> errorOrString = ErrorOr<string>.Is(ValidationErrors.ToArray());

        // Assert
        errorOrInt.IsError.Should().BeTrue();
        errorOrInt.Errors.Should().Contain(ValidationErrors);

        errorOrString.IsError.Should().BeTrue();
        errorOrString.Errors.Should().Contain(ValidationErrors);
    }
}