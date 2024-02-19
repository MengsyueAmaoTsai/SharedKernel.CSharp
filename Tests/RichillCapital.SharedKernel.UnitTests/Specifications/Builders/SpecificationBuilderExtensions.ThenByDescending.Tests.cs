using FluentAssertions;

using RichillCapital.SharedKernel.Specifications.Expressions;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public sealed class SpecificationBuilderExtensionsThenByDescendingTests
{
    [Fact]
    public void Should_AppendsOrderExpressionToListWithThenByDescendingType_When_GivenThenByDescendingExpression()
    {
        // Arrange
        var spec = new StoresByCompanyOrderedDescByNameThenByDescIdSpec(1);

        // Act
        var orderExpressions = spec.OrderExpressions.ToList();

        // Assert
        orderExpressions.Should().HaveCount(2);

        orderExpressions[1].OrderType
            .Should().Be(OrderByExpressionType.ThenByDescending);
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
    public void Should_AddsNothingToList_When_GivenThenByDescendingExpressionWithFalseCondition()
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
            .Where(x => x.OrderType == OrderByExpressionType.ThenByDescending)
            .Should().BeEmpty();
    }
}