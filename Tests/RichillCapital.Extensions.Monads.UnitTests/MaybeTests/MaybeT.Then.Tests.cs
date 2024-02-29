using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTThenTests : MonadTests
{
    [Fact]
    public void Then_When_IsNull_Should_NotInvokeResultFactory_And_ReturnMaybeTWithNull()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Null
            .Then(value => value.ToString());

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void Then_When_IsValue_Should_InvokeResultFactory_And_ReturnMaybeTWithValue()
    {
        // Arrange & Act
        var maybe = Value.ToMaybe()
            .Then(value => value.ToString());

        // Assert
        maybe.ShouldBeHasValueWith(Value.ToString());
    }
}