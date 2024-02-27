using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public async Task ToMaybe_Should_ConvertValueToMaybe()
    {
        // Arrange & Act
        Maybe<int> maybeInt = default(int).ToMaybe();
        Maybe<bool> maybeBool = default(bool).ToMaybe();
        Maybe<DateTime> maybeDateTime = default(DateTime).ToMaybe();
        Maybe<byte> maybeByte = default(byte).ToMaybe();
        Maybe<string> maybeString = default(string).ToMaybe()!;
        Maybe<int> maybeFromTask = await GetIntValueAsync().ToMaybe();
        Maybe<int> maybeFromValueTask = await GetIntValueTaskAsync().ToMaybe();

        // Assert
        maybeInt.HasValue.Should().BeTrue();
        maybeInt.Value.Should().Be(0);

        maybeBool.HasValue.Should().BeTrue();
        maybeBool.Value.Should().BeFalse();

        maybeDateTime.HasValue.Should().BeTrue();
        maybeDateTime.Value.Should().Be(DateTime.MinValue);

        maybeByte.HasValue.Should().BeTrue();
        maybeByte.Value.Should().Be(0);

        maybeString.HasValue.Should().BeFalse();
        maybeString.HasNoValue.Should().BeTrue();

        maybeFromTask.HasValue.Should().BeTrue();
        maybeFromTask.Value.Should().Be(IntValue);

        maybeFromValueTask.HasValue.Should().BeTrue();
        maybeFromValueTask.Value.Should().Be(IntValue);
    }

    private static async Task<int> GetIntValueAsync() => await Task.FromResult(IntValue);

    private static async ValueTask<int> GetIntValueTaskAsync() => await new ValueTask<int>(IntValue);
}