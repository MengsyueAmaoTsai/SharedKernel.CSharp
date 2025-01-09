using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public class SpecificationBuilderExtensionsAsNoTrackingTests
{
    [Fact]
    public void Should_DoesNothing_When_GivenSpecWithoutAsNoTracking()
    {
        // Arrange
        var spec = new StoreEmptySpec();

        // Act & Assert
        spec.AsNoTracking.Should().Be(false);
    }

    [Fact]
    public void Should_DoesNothing_When_GivenAsNoTrackingWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.AsNoTracking.Should().Be(false);
    }

    [Fact]
    public void Should_FlagsAsNoTracking_When_GivenSpecWithAsNoTracking()
    {
        // Arrange
        var spec = new CompanyByIdAsNoTrackingSpec(1);

        // Act & Assert
        spec.AsNoTracking.Should().Be(true);
    }

    [Fact]
    public void Should_FlagsAsNoTracking_When_GivenSpecWithAsTrackingAndEndWithAsNoTracking()
    {
        // Arrange
        var spec = new CompanyByIdWithAsTrackingAsNoTrackedSpec(1);

        // Act & Assert
        spec.AsNoTracking.Should().Be(true);
    }
}
