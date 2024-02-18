using FluentAssertions;

using RichillCapital.SharedKernel.Specifications.Exceptions;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public sealed class SpecificationBuilderExtensionsTakeTests
{
    [Fact]
    public void Should_SetTakeProperty()
    {
        // Arrange
        var take = 10;
        var spec = new StoreNamesPaginatedSpec(0, take);

        // Act & Assert
        spec.WhereExpressions.Should().BeEmpty();
    }

    [Fact]
    public void Should_DoesNothing_WhenTakeWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.WhereExpressions.Should().BeEmpty();
    }

    [Fact]
    public void Should_ThrowDuplicateTakeException_WhenAddTakeMoreThanOnce()
    {
        // Arrange
        Action action = () => new StoreDuplicateTakeSpec();

        // Act & Assert
        action.Should().Throw<DuplicateTakeException>();
    }
}