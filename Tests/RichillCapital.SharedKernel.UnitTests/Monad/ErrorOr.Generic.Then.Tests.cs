using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monad;
using RichillCapital.SharedKernel.UnitTests.Monad.Common;
using RichillCapital.SharedKernel.UnitTests.Monad.Common.Assertions;

public sealed partial class GenericErrorOrTests : MonadTests
{
    private sealed record SomeCommand(string Id);

    private static readonly SomeCommand TestCommand = new("1");

    [Fact]
    public void Then_Should_ReturnErrorOrWithValue_WhenNoErrors()
    {
        // Arrange & Act
        var errorOr = ErrorOr
            .Is(TestCommand)
            .Then(HandleWillSuccess);

        // Assert
        errorOr.ShouldBeValue(1);
    }

    [Fact]
    public void Then_Should_ReturnErrorOrWithError_WhenErrors()
    {
        // Arrange & Act
        var errorOr = ErrorOr
            .Is(TestCommand)
            .Then(HandleWillFailed);

        // Assert
        errorOr.ShouldBeErrors([TestError]);
    }

    [Fact]
    public async Task ThenAsync_Should_ReturnErrorOrWithValue_WhenNoErrors()
    {
        // Arrange & Act
        var errorOr = await ErrorOr
            .Is(TestCommand)
            .Then(HandleWillSuccessAsync);

        // Assert
        errorOr.ShouldBeValue(1);
    }

    [Fact]
    public async Task ThenAsync_Should_ReturnErrorOrWithError_WhenErrors()
    {
        // Arrange & Act
        var errorOr = await ErrorOr
            .Is(TestCommand)
            .Then(async command => await HandleWillFailedAsync(command));

        // Assert
        errorOr.ShouldBeErrors([TestError]);
    }

    private static ErrorOr<int> HandleWillSuccess(SomeCommand command) =>
        ErrorOr.Is(int.Parse(command.Id));

    private static ErrorOr<int> HandleWillFailed(SomeCommand command) =>
        ErrorOr<int>.From(TestError);

    private static async Task<ErrorOr<int>> HandleWillSuccessAsync(SomeCommand command) =>
        await Task.FromResult(ErrorOr.Is(int.Parse(command.Id)));

    private static async Task<ErrorOr<int>> HandleWillFailedAsync(SomeCommand command) =>
        await Task.FromResult(ErrorOr<int>.From(TestError));
}