using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeExtensionsConvertersTests : MonadTests
{
    [Fact]
    public void ToMaybe_When_FromValue_Should_ConvertValueToMaybeWithValue()
    {
        // Arrange & Act
        var maybe = TestValue
            .ToMaybe();

        // Assert
        maybe.ShouldBeHas(TestValue);
    }
}