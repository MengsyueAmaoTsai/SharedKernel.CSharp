using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public async Task ToResult_Should_ConvertValueToResult()
    {
        // Arrange & Act
        var resultFromValue = IntValue.ToResult();
        var resultFromError = NotFoundError.ToResult<int>();
        var resultFromTask = await GetIntValueAsync().ToResult();
        var resultFromValueTask = await GetIntValueTaskAsync().ToResult();

        // Assert
        resultFromValue.IsSuccess.Should().BeTrue();
        resultFromValue.Value.Should().Be(IntValue);

        resultFromError.IsFailure.Should().BeTrue();
        resultFromError.Error.Should().Be(NotFoundError);

        resultFromTask.IsSuccess.Should().BeTrue();
        resultFromTask.Value.Should().Be(IntValue);

        resultFromValueTask.IsSuccess.Should().BeTrue();
        resultFromValueTask.Value.Should().Be(IntValue);
    }

    private static async Task<int> GetIntValueAsync() => await Task.FromResult(IntValue);

    private static async ValueTask<int> GetIntValueTaskAsync() => await new ValueTask<int>(IntValue);
}