using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public sealed class SpecificationBuilderExtensionsIgnoreQueryFiltersTests
{
    [Fact]
    public void Should_DoesNothing_When_GivenSpecWithoutIgnoreQueryFilters()
    {
        // Arrange  
        var spec = new StoreEmptySpec();

        // Act & Assert
        spec.IgnoreQueryFilters.Should().Be(false);
    }

    [Fact]
    public void Should_DoesNothing_When_GivenIgnoreQueryFiltersWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.IgnoreQueryFilters.Should().Be(false);
    }

    [Fact]
    public void Should_FlagsIgnoreQueryFilters_When_GivenSpecWithIgnoreQueryFilters()
    {
        // Arrange
        var spec = new CompanyByIdIgnoreQueryFilters(1);

        // Act & Assert
        spec.IgnoreQueryFilters.Should().Be(true);
    }
}