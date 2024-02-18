using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Specifications.Common;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public class SpecificationBuilderExtensionsIncludeStringTests
{
    [Fact]
    public void Should_AddNothingToList_When_GivenNoIncludeStringExpression()
    {
        // Arrange
        var spec = new StoreEmptySpec();

        // Act & Assert
        spec.WhereExpressions.Should().BeEmpty();
    }

    [Fact]
    public void Should_AddNothingToList_When_GivenIncludeStringWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.IncludeStrings.Should().BeEmpty();
    }

    [Fact]
    public void Should_AddIncludeStringToList_When_GivenString()
    {
        // Arrange
        var spec = new StoreIncludeCompanyThenCountryAsStringSpec();
        var expected = $"{nameof(Company)}.{nameof(Company.Country)}";

        // Act & Assert
        spec.IncludeStrings.Should().ContainSingle();
        spec.IncludeStrings.Single().Should().Be(expected);
    }
}
