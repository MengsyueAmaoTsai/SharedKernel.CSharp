using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericMaybeTests : MonadTests
{
    [Fact]
    public void Switch_WhenMaybeHasValue_Should_ExecutesOnHasValueAction()
    {
        // Arrange
        Maybe<int> maybe = IntValue
            .ToMaybe();

        // Act & Assert
        maybe
            .Switch(
                value => value.Should().Be(IntValue),
                () => throw new Exception("Should not execute this action"));
    }

    [Fact]
    public void Switch_WhenMaybeHasNoValue_Should_ExecutesOnHasNoValueAction()
    {
        // Arrange
        Maybe<int> maybe = Maybe<int>.Null;

        // Act & Assert
        maybe
            .Switch(
                value => throw new Exception("Should not execute this action"),
                () => true.Should().BeTrue());
    }
}