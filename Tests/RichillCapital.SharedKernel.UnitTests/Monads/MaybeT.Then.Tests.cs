using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public async Task Then_When_MaybeHasValue_Should_ReturnMaybeWithValue()
    {
        // Arrange & Act
        var maybe = await Maybe<int>
            .Have(IntValue)
            .Then(UpdateValueAsync);

        // Assert
        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(IntValue * 2);
    }

    [Fact]
    public async Task Then_When_MaybeIsEmpty_Should_ReturnMaybeEmpty()
    {
        // Arrange & Act
        var maybe = await Maybe<int>
            .Null
            .Then(UpdateValueAsync);

        // Assert
        maybe.HasNoValue.Should().BeTrue();
    }

    public static async Task<Maybe<int>> UpdateValueAsync(int value) =>
        await Task.FromResult(Maybe<int>.Have(value * 2));
}