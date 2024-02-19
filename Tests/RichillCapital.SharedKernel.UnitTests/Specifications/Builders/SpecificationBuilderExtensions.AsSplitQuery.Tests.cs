using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public sealed class SpecificationBuilderExtensionsAsSplitQueryTests
{
    [Fact]
    public void Should_DoesNothing_When_GivenSpecWithoutAsSplitQuery()
    {
        // Arrange
        var spec = new StoreEmptySpec();

        // Act & Assert
        spec.AsSplitQuery.Should().Be(false);
    }

    [Fact]
    public void Should_DoesNothing_When_GivenAsSplitQueryWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.AsSplitQuery.Should().Be(false);
    }

    [Fact]
    public void Should_FlagsAsNoTracking_When_GivenSpecWithAsSplitQuery()
    {
        // Arrange
        var spec = new CompanyByIdAsSplitQuery(1);

        // Act & Assert
        spec.AsSplitQuery.Should().Be(true);
    }
}