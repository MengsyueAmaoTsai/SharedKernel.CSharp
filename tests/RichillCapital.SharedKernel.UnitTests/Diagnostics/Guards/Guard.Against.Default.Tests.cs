namespace RichillCapital.SharedKernel.UnitTests.Diagnostics;

public sealed partial class GuardTests
{
    [Fact]
    public void Against_Default_When_GivenNonDefaultValue_ShouldNotThrow()
    {
        // Arrange
    }

    [Fact]
    public void Against_Default_When_GivenDefaultValue_Should_ThrowArgumentException()
    {
    }
}