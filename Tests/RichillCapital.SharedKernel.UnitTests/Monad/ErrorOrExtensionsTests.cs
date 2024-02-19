using FluentAssertions;

using RichillCapital.SharedKernel.Monad;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed class ErrorOrExtensionsTests
{
    [Fact]
    public void Then_Should_ReturnErrorOrWithNextValue_WhenErrorOrIsNoError()
    {
        // Arrange
        var value = 1;

        // Act
        ErrorOr<int> errorOr = value;
        ErrorOr<string> errorOrString = errorOr.Then(v => v.ToString());

        // Assert
        errorOrString.Value.Should().Be(value.ToString());
    }

    [Fact]
    public void Then_Should_ReturnErrorOrWithOriginalError_WhenErrorOrIsError()
    {
        // Arrange
        var errorMessage = "error";
        var error = Error.Invalid(errorMessage);

        // Act
        ErrorOr<int> errorOr = error;
        ErrorOr<string> errorOrString = errorOr.Then(v => v.ToString());

        // Assert
        errorOrString.IsError.Should().BeTrue();
        errorOrString.Error.Should().Be(error);
        errorOrString.Error.Message.Should().Be(errorMessage);
    }

    [Fact]
    public void Then_Should_ExecuteNextFunction_WhenErrorOrIsNoError()
    {
        // Arrange
        var value = 1;
        var executed = false;

        // Act
        ErrorOr<int> errorOr = value;
        ErrorOr<string> errorOrString = errorOr.Then(v =>
        {
            executed = true;
            return v.ToString();
        });

        // Assert
        executed.Should().BeTrue();
    }

    [Fact]
    public void Then_Should_NotExecuteNextFunction_WhenErrorOrIsError()
    {
        // Arrange
        var errorMessage = "error";
        var error = Error.Invalid(errorMessage);
        var executed = false;

        // Act
        ErrorOr<int> errorOr = error;
        ErrorOr<string> errorOrString = errorOr.Then(v =>
        {
            executed = true;
            return v.ToString();
        });

        // Assert
        executed.Should().BeFalse();
    }

    [Fact]
    public void Map_Should_ReturnErrorOrWithMappedValue_WhenErrorOrIsSuccess()
    {
        // Arrange
        var value = 1;

        // Act
        ErrorOr<int> errorOr = value;
        var mappedErrorOr = errorOr.Map(v => v + 1);

        // Assert
        mappedErrorOr.Value.Should().Be(value + 1);
    }

    [Fact]
    public void Map_Should_ReturnErrorOrWithOriginalError_WhenErrorOrIsError()
    {
        // Arrange
        var errorMessage = "error";
        var error = Error.Invalid(errorMessage);

        // Act
        ErrorOr<int> errorOr = error;
        var mappedErrorOr = errorOr.Map(v => v + 1);

        // Assert
        mappedErrorOr.IsError.Should().BeTrue();
        mappedErrorOr.Error.Should().Be(error);
        mappedErrorOr.Error.Message.Should().Be(errorMessage);
    }

    [Fact]
    public void ThrowIfError_Should_ThrowException_WhenErrorOrIsError()
    {
        // Arrange
        var errorMessage = "error";
        ErrorOr errorOr = Error.Invalid(errorMessage);
        ErrorOr<string> errorOr2 = Error.Invalid(errorMessage);

        // Act
        Action action = () => errorOr.ThrowIfError();
        Action action2 = () => errorOr2.ThrowIfError();

        // Assert
        action.Should()
            .Throw<InvalidOperationException>()
            .WithMessage(errorMessage);

        action2.Should()
            .Throw<InvalidOperationException>()
            .WithMessage(errorMessage);
    }
}