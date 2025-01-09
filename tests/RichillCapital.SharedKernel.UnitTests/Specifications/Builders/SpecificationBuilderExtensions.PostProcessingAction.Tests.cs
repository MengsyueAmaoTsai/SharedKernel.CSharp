using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public sealed class SpecificationBuilderExtensionsPostProcessingActionTests
{
    [Fact]
    public void Should_SetsNothing_When_GivenNoPostProcessingAction()
    {
        // Arrange
        var spec = new StoreEmptySpec();

        // Act & Assert
        spec.PostProcessingAction.Should().BeNull();
    }

    [Fact]
    public void Should_SetsNothing_When_GivenSelectorSpecWithNoPostProcessingAction()
    {
        // Arrange
        var spec = new StoreNamesEmptySpec();

        // Act & Assert
        spec.PostProcessingAction.Should().BeNull();
    }

    [Fact]
    public void Should_SetsPostProcessingPredicate_When_GivenPostProcessingAction()
    {
        // Arrange
        var spec = new StoreWithPostProcessingActionSpec();

        // Act & Assert
        spec.PostProcessingAction.Should().NotBeNull();
    }

    [Fact]
    public void Should_SetsPostProcessingPredicate_When_GivenSelectorSpecWithPostProcessingAction()
    {
        // Arrange
        var spec = new StoreNamesWithPostProcessingActionSpec();

        // Act & Assert
        spec.PostProcessingAction.Should().NotBeNull();
    }
}