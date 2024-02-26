using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public async Task Then_When_MaybeHasValue_Should_InvokeTaskAndReturnMaybeWithValue()
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
    public async Task Then_When_MaybeIsEmpty_ShouldNot_InvokeTaskAndReturnMaybeEmpty()
    {
        // Arrange & Act
        var maybe = await Maybe<int>
            .Null
            .Then(UpdateValueAsync);

        // Assert
        maybe.HasNoValue.Should().BeTrue();
    }

    [Fact]
    public void Then_When_MaybeHasValue_Should_InvokeFactoryAndReturnMaybeWithValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>
            .Have(IntValue)
            .Then(CreateValue);

        // Assert
        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(5);
    }

    [Fact]
    public void Then_When_MaybeIsEmpty_ShouldNot_InvokeFactoryAndReturnMaybeEmpty()
    {
        // Arrange & Act
        var maybe = Maybe<int>
            .Null
            .Then(CreateValue);

        // Assert
        maybe.HasNoValue.Should().BeTrue();
    }

    public static async Task<Maybe<int>> UpdateValueAsync(int value) =>
        await Task.FromResult(Maybe<int>.Have(value * 2));

    public static int CreateValue() => 5;
}