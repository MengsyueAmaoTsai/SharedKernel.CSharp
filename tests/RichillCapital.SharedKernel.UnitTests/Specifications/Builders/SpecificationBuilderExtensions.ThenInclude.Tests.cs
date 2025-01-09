using FluentAssertions;

using RichillCapital.SharedKernel.Specifications.Expressions;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public sealed class SpecificationBuilderExtensionsThenIncludeTests
{
    [Fact]
    public void Should_AppendIncludeExpressionToListWithTypeThenInclude()
    {
        // Arrange
        var spec = new StoreIncludeCompanyThenCountrySpec();

        // Act
        var includeExpressions = spec.IncludeExpressions.ToList();

        // Assert
        includeExpressions.Should().HaveCount(2);
        includeExpressions[1].Type
            .Should().Be(IncludeExpressionType.ThenInclude);
    }

    [Fact]
    public void Should_AddNothingToList_When_GivenDiscardedIncludeChain()
    {
        // Arrange 
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.IncludeExpressions.Should().BeEmpty();
    }

    [Fact]
    public void Should_AddsNothingToList_When_GivenThenIncludeExpressionWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditionsForInnerChains(1);

        // Act & Assert
        spec.IncludeExpressions.Should().HaveCount(1);

        spec.IncludeExpressions
            .First().Type
            .Should().Be(IncludeExpressionType.Include);

        spec.IncludeExpressions
            .Where(x => x.Type == IncludeExpressionType.ThenInclude)
            .Should().BeEmpty();
    }

    [Fact]
    public void Should_AppendIncludeExpression_With_EnumerablePreviousPropertyType()
    {
        // Arrange
        var spec = new StoreIncludeCompanyThenStoresSpec();

        // Act
        var includeExpressions = spec.IncludeExpressions.ToList();

        // Assert
        includeExpressions.Should().HaveCount(3);

        includeExpressions[2].PreviousPropertyType
            .Should().Be(typeof(IEnumerable<Store>));
    }
}