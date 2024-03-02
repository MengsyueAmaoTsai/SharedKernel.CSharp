using FluentAssertions;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed partial class ErrorFactoryTests
{
    [Fact]
    public void Null_Should_ReturnNullError()
    {
        // Arrange
        var error = Error.Null;

        // Act & Assert
        error.Type.Should().Be(ErrorType.Null);
        error.Message.Should().BeEmpty();
    }

    [Fact]
    public void Invalid_Should_ReturnValidationError()
    {
        // Arrange
        var message = "Invalid";
        var error = Error.Invalid(message);

        // Act & Assert
        error.Should().BeOfType<Error>();
        error.Type.Should().Be(ErrorType.Validation);
        error.Message.Should().Be(message);
    }

    [Fact]
    public void Unauthorized_Should_ReturnUnauthorizedError()
    {
        // Arrange
        var message = "Unauthorized";
        var error = Error.Unauthorized(message);

        // Act & Assert
        error.Should().BeOfType<Error>();
        error.Type.Should().Be(ErrorType.Unauthorized);
        error.Message.Should().Be(message);
    }

    [Fact]
    public void Forbidden_Should_ReturnForbiddenError()
    {
        // Arrange
        var message = "Forbidden";
        var error = Error.Forbidden(message);

        // Act & Assert
        error.Should().BeOfType<Error>();
        error.Type.Should().Be(ErrorType.Forbidden);
        error.Message.Should().Be(message);
    }

    [Fact]
    public void NotFound_Should_ReturnNotFoundError()
    {
        // Arrange
        var message = "Not Found";
        var error = Error.NotFound(message);

        // Act & Assert
        error.Should().BeOfType<Error>();
        error.Type.Should().Be(ErrorType.NotFound);
        error.Message.Should().Be(message);
    }

    [Fact]
    public void Conflict_Should_ReturnConflictError()
    {
        // Arrange
        var message = "Conflict";
        var error = Error.Conflict(message);

        // Act & Assert
        error.Should().BeOfType<Error>();
        error.Type.Should().Be(ErrorType.Conflict);
        error.Message.Should().Be(message);
    }

    [Fact]
    public void Unexpected_Should_ReturnUnexpectedError()
    {
        // Arrange
        var message = "Unexpected";
        var error = Error.Unexpected(message);

        // Act & Assert
        error.Should().BeOfType<Error>();
        error.Type.Should().Be(ErrorType.Unexpected);
        error.Message.Should().Be(message);
    }

    [Fact]
    public void Unavailable_Should_ReturnUnavailableError()
    {
        // Arrange
        var message = "Unavailable";
        var error = Error.Unavailable(message);

        // Act & Assert
        error.Should().BeOfType<Error>();
        error.Type.Should().Be(ErrorType.Unavailable);
        error.Message.Should().Be(message);
    }
}