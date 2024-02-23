using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Common.Assertions;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public async Task Then_When_IsError_Should_ReturnsErrorOrWithErrors()
    {
        // Arrange
        var errorOr = ErrorOr<int>.From(TestError);

        // Act
        var result = await errorOr.Then(value => Task.FromResult(ErrorOr<string>.Is(value.ToString())));

        // Assert
        result.ShouldBeErrors([TestError]);
    }

    [Fact]
    public async Task Then_When_IsNotError_Should_Returns_ErrorOrWithValue()
    {
        // Arrange
        var errorOr = ErrorOr<int>.Is(1);

        // Act
        var result = await errorOr.Then(value => Task.FromResult(ErrorOr<string>.Is(value.ToString())));

        // Assert
        result.ShouldBeValue("1");
    }

    [Fact]
    public void Then_When_IsError_Should_ReturnsErrorOrWithErrorsSync()
    {
        // Arrange
        var errorOr = ErrorOr<int>.From(TestError);

        // Act
        var result = errorOr.Then(() => ErrorOr<string>.Is("1"));

        // Assert
        result.ShouldBeErrors([TestError]);
    }

    [Fact]
    public void Then_When_IsNotError_Should_ReturnsErrorOrWithValueSync()
    {
        // Arrange
        var errorOr = ErrorOr<int>.Is(1);

        // Act
        var result = errorOr.Then(() => ErrorOr<string>.Is("1"));

        // Assert
        result.ShouldBeValue("1");
    }
}