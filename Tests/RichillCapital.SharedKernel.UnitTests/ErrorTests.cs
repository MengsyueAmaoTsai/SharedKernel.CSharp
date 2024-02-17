using FluentAssertions;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed class ErrorTests
{
    [Fact]
    public void Should_Create_ValidationError()
    {
        // Arrange
        var message = "Invalid input.";

        // Act
        var error = Error.Invalid(message);

        // Assert
        error.Type.Should().Be(ErrorType.Validation);
        error.Message.Should().Be(message);
    }

    [Fact]
    public void Should_Create_UnauthorizedError()
    {
        // Arrange
        var message = "Unauthorized access.";

        // Act
        var error = Error.Unauthorized(message);

        // Assert
        error.Type.Should().Be(ErrorType.Unauthorized);
        error.Message.Should().Be(message);
    }

    [Fact]
    public void Should_Create_ForbiddenError()
    {
        // Arrange
        var message = "Forbidden access.";

        // Act
        var error = Error.Forbidden(message);

        // Assert
        error.Type.Should().Be(ErrorType.Forbidden);
        error.Message.Should().Be(message);
    }

    [Fact]
    public void Should_Create_NotFoundError()
    {
        // Arrange
        var message = "Resource not found.";

        // Act
        var error = Error.NotFound(message);

        // Assert
        error.Type.Should().Be(ErrorType.NotFound);
        error.Message.Should().Be(message);
    }

    [Fact]
    public void Should_Create_ConflictError()
    {
        // Arrange
        var message = "Resource conflict.";

        // Act
        var error = Error.Conflict(message);

        // Assert
        error.Type.Should().Be(ErrorType.Conflict);
        error.Message.Should().Be(message);
    }
}