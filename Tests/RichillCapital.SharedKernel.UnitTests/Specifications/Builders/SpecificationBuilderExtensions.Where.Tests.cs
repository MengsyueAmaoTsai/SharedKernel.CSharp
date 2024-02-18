using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public sealed class SpecificationBuilderExtensionsWhereTests
{
    [Fact]
    public void Should_AddNothingToList_WhenNoSpecificationIsAdded()
    {
        // Arrange
        var spec = new StoreEmptySpec();

        // Act & Assert
        spec.WhereExpressions.Should().BeEmpty();
    }

    [Fact]
    public void Should_AddNothingToList_WhenExpressionWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.WhereExpressions.Should().BeEmpty();
    }

    [Fact]
    public void Should_AddOneExpressionToList()
    {
        // Arrange
        var spec = new StoreByIdSpec(1);

        // Act & Assert
        spec.WhereExpressions.Should().HaveCount(1);
    }

    [Fact]
    public void Should_AddTwoExpressionsToList()
    {
        // Arrange
        var spec = new StoreByIdAndNameSpec(1, "test");

        // Act & Assert
        spec.WhereExpressions.Should().HaveCount(2);
    }
}