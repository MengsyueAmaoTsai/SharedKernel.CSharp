using FluentAssertions;

using RichillCapital.SharedKernel.Specifications.Expressions;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public sealed class SpecificationBuilderExtensionsIncludeTests
{
    public void Should_AddNothingToList_WhenNoIncludeExpression()
    {
        // Arrange
        var spec = new StoreEmptySpec();

        // Act & Assert
        spec.IncludeExpressions.Should().BeEmpty();
    }

    public void Should_AddNothingToList_WhenIncludeExpressionWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.IncludeExpressions.Should().BeEmpty();
    }

    public void Should_Should_AddIncludeExpressionToList_When_GivenIncludeExpression_WithTypeInclude()
    {
        // Arrange
        var spec = new StoreIncludeAddressSpec();

        // Act & Assert
        spec.IncludeExpressions.Should().ContainSingle();
        spec.IncludeExpressions.Single().Type.Should().Be(IncludeExpressionType.Include);
    }
}