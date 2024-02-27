using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public async Task ToErrorOr_Should_ConvertValueToErrorOr()
    {
        // Arrange & Act
        ErrorOr<int> errorOrFromValue = IntValue.ToErrorOr();
        ErrorOr<string> errorOrFromError = NotFoundError.ToErrorOr<string>();
        ErrorOr<string> errorOrFromListOfErrors = ValidationErrors.ToErrorOr<string>();
        ErrorOr<string> errorOrFromArrayOfErrors = ValidationErrors.ToArray().ToErrorOr<string>();
        ErrorOr<int> errorOrFromTask = await GetIntValueAsync().ToErrorOr();
        ErrorOr<int> errorOrFromValueTask = await GetIntValueTaskAsync().ToErrorOr();

        // Assert
        errorOrFromValue.IsValue.Should().BeTrue();
        errorOrFromValue.Value.Should().Be(IntValue);

        errorOrFromError.IsError.Should().BeTrue();
        errorOrFromError.Errors.Should().Contain(NotFoundError);

        errorOrFromListOfErrors.IsError.Should().BeTrue();
        errorOrFromListOfErrors.Errors.Should().BeEquivalentTo(ValidationErrors);

        errorOrFromArrayOfErrors.IsError.Should().BeTrue();
        errorOrFromArrayOfErrors.Errors.Should().BeEquivalentTo(ValidationErrors);

        errorOrFromTask.IsValue.Should().BeTrue();
        errorOrFromTask.Value.Should().Be(IntValue);

        errorOrFromValueTask.IsValue.Should().BeTrue();
        errorOrFromValueTask.Value.Should().Be(IntValue);
    }

    private static async Task<int> GetIntValueAsync() => await Task.FromResult(IntValue);

    private static async ValueTask<int> GetIntValueTaskAsync() => await new ValueTask<int>(IntValue);
}