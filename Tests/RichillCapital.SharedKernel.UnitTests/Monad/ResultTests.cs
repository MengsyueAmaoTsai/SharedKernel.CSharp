using FluentAssertions;

using RichillCapital.SharedKernel.Monad;

namespace RichillCapital.SharedKernel.UnitTests.Monad;

public sealed class ResultTests
{
    [Fact]
    public void Success_Should_CreateSuccessResult()
    {
        // Arrange & Act
        var result = Result.Success;

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void From_Should_CreateSuccessResult()
    {
        // Arrange & Act
        Result result = Result.From(1);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void From_Should_CreateSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> result = Result<int>.From(1);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
    }

    [Fact]
    public void ImplicitConversion_Should_CreateFailureResult()
    {
        // Arrange & Act
        Result result = Error.Invalid("Error message");

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Message.Should().Be("Error message");
    }

    [Fact]
    public void ImplicitConversion_Should_CreateSuccessResult()
    {
        // Arrange & Act
        Result<int> result = 1;

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
    }

    [Fact]
    public void ImplicitConversion_Should_CreateFailureResultWithValue()
    {
        // Arrange & Act
        Result<int> result = Error.Invalid("Error message");

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Message.Should().Be("Error message");
    }

    [Fact]
    public void ImplicitConversion_Should_CreateSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> result = 1;

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(1);
    }
}