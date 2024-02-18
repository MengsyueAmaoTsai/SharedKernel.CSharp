
using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public sealed class SpecificationBuilderExtensionsSelectTests
{
    [Fact]
    public void Should_SetNothing_When_NoSelectExpression()
    {
        // Arrange
        var spec = new StoreNamesEmptySpec();

        // Act & Assert
        spec.Selector.Should().BeNull();
    }

    [Fact]
    public void Should_SetSelector_When_GivenSelectExpression()
    {
        // Arrange
        var spec = new StoreNamesSpec();

        // Act & Assert
        spec.Selector.Should().NotBeNull();
    }
}