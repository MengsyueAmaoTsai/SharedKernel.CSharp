using FluentAssertions;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public sealed class SpecificationBuilderExtensionsSelectManyTests
{
    [Fact]
    public void Should_SetNothing_When_NoSelectManyExpression()
    {
        // Arrange
        var spec = new StoreProductNamesEmptySpec();

        // Act & Assert
        spec.SelectorMany.Should().BeNull();
    }

    [Fact]
    public void Should_SetSelectMany_When_GivenSelectManyExpression()
    {
        // Arrange
        var spec = new StoreProductNamesSpec();

        // Act & Assert
        spec.SelectorMany.Should().NotBeNull();
    }
}