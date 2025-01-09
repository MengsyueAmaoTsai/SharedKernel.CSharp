using FluentAssertions;

using RichillCapital.SharedKernel.Specifications.Expressions;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public class SpecificationBuilderExtensions_OrderBy
{
    [Fact]
    public void Should_AddNothingToList_When_GivenNoOrderExpression()
    {
        // Arrange
        var spec = new StoreEmptySpec();

        // Act & Assert
        spec.OrderExpressions.Should().BeEmpty();
    }

    [Fact]
    public void Should_AddNothingToList_When_GivenOrderExpressionWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.OrderExpressions.Should().BeEmpty();
    }

    [Fact]
    public void Should_AddOrderExpressionToListWithOrderByType_When_GivenOrderByExpression()
    {
        // Arrange
        var spec = new StoresOrderedSpecByName();

        // Act & Assert
        spec.OrderExpressions.Should().ContainSingle();
        spec.OrderExpressions.Single().OrderType.Should().Be(OrderByExpressionType.OrderBy);
    }
}
