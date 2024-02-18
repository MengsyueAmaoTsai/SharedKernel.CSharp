using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Specifications.Common;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public class SpecificationBuilderExtensionsIncludeStringTests
{
    [Fact]
    public void AddsNothingToList_GivenNoIncludeStringExpression()
    {
        // Arrange
        var spec = new StoreEmptySpec();

        // Act & Assert
        spec.WhereExpressions.Should().BeEmpty();
    }

    [Fact]
    public void AddsNothingToList_GivenIncludeStringWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.IncludeStrings.Should().BeEmpty();
    }

    [Fact]
    public void AddsIncludeStringToList_GivenString()
    {
        // Arrange
        var spec = new StoreIncludeCompanyThenCountryAsStringSpec();
        var expected = $"{nameof(Company)}.{nameof(Company.Country)}";

        // Act & Assert
        spec.IncludeStrings.Should().ContainSingle();
        spec.IncludeStrings.Single().Should().Be(expected);
    }
}
