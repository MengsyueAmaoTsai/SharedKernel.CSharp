
using FluentAssertions;

using RichillCapital.SharedKernel.Specifications.Exceptions;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

public sealed class SpecificationBuilderExtensionsSkipTests
{
    [Fact]
    public void Should_SetSkipProperty()
    {
        // Arrange
        var skip = 1;

        // Act
        var spec = new StoreNamesPaginatedSpec(skip, 10);

        // Assert
        spec.Skip.Should().Be(skip);
    }

    [Fact]
    public void Should_DoesNothing_WhenSkipWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.WhereExpressions.Should().BeEmpty();
    }


    [Fact]
    public void Should_ThrowDuplicateSkipException_WhenAddSkipMoreThanOnce()
    {
        // Arrange
        Action action = () => new StoreDuplicateSkipSpec();

        // Act & Assert
        action.Should().Throw<DuplicateSkipException>();
    }
}