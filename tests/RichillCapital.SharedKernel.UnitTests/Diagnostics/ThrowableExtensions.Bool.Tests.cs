using FluentAssertions;

using RichillCapital.SharedKernel.Diagnostics;

namespace RichillCapital.SharedKernel.UnitTests.Diagnostics;

public sealed partial class ThrowableExtensionsTests
{
    private sealed record Person(int Age);

    [Fact]
    public void Throw_IfTrue_When_PropertyIsTrue_Should_ThrowArgumentException()
    {
        // Arrange
        var person = new Person(18);
        var expectedMessage = $"Value should not meet condition (condition: 'person => person.Age == 18'). (Parameter '{nameof(person)}')";

        // Act
        Action action = () => person.Throw().IfTrue(person => person.Age == 18);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage(expectedMessage);
    }

    [Fact]
    public void Throw_IfTrue_When_PropertyIsFalse_Should_NotThrow()
    {
        // Arrange
        var person = new Person(18);

        // Act
        Action action = () => person.Throw().IfTrue(person => person.Age == 19);

        // Assert
        action.Should().NotThrow();
    }

    [Fact]
    public void Throw_IfFalse_When_PropertyIsFalse_Should_ThrowArgumentException()
    {
        // Arrange
        var person = new Person(18);
        var expectedMessage = $"Value should meet condition (condition: 'person => person.Age == 15'). (Parameter '{nameof(person)}')";

        // Act
        Action action = () => person.Throw().IfFalse(person => person.Age == 15);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage(expectedMessage);
    }

    [Fact]
    public void Throw_IfFalse_When_PropertyIsTrue_Should_NotThrow()
    {
        // Arrange
        var person = new Person(18);

        // Act
        Action action = () => person.Throw().IfFalse(person => person.Age == 18);

        // Assert
        action.Should().NotThrow();
    }
}