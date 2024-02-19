using FluentAssertions;

using RichillCapital.SharedKernel.Specifications.Expressions;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public sealed class SpecificationBuilderExtensionsThenByTests
{
    [Fact]
    public void Should_AppendOrderExpressionToListWithThenByType_When_GivenThenByExpression()
    {
        // Arrange
        var spec = new StoresByCompanyOrderedDescByNameThenByIdSpec(1);

        // Act
        var orderExpressions = spec.OrderExpressions.ToList();

        // Assert
        orderExpressions.Should().HaveCount(2);

        orderExpressions[1].OrderType.Should().Be(OrderByExpressionType.ThenBy);
    }

    [Fact]
    public void Should_AddsNothingToList_When_GivenDiscardedOrderChain()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.OrderExpressions.Should().BeEmpty();
    }

    [Fact]
    public void Should_AddsNothingToList_When_GivenThenByExpressionWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditionsForInnerChains(1);

        // Act & Assert
        spec.OrderExpressions.Should().HaveCount(2);

        spec.OrderExpressions
            .First().OrderType
            .Should().Be(OrderByExpressionType.OrderBy);

        spec.OrderExpressions
            .Skip(1).First().OrderType
            .Should().Be(OrderByExpressionType.OrderByDescending);

        spec.OrderExpressions
            .Where(x => x.OrderType == OrderByExpressionType.ThenBy)
            .Should().BeEmpty();
    }
}