using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public sealed class SpecificationBuilderExtensionsAsTrackingTests
{
    [Fact]
    public void Should_DoesNothing_When_GivenSpecWithoutAsTracking()
    {
        // Arrange
        var spec = new StoreEmptySpec();

        // Act & Assert
        spec.AsTracking.Should().Be(false);
    }

    [Fact]
    public void Should_DoesNothing_When_GivenAsTrackingWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.AsTracking.Should().Be(false);
    }

    [Fact]
    public void Should_FlagsAsTracking_When_GivenSpecWithAsTracking()
    {
        // Arrange
        var spec = new CompanyByIdAsTrackedSpec(1);

        // Act & Assert
        spec.AsTracking.Should().Be(true);
    }

    [Fact]
    public void Should_FlagsAsTracking_When_GivenSpecWithAsNoTrackingAndEndWithAsTracking()
    {
        // Arrange
        var spec = new CompanyByIdWithAsNoTrackingAsTrackedSpec(1);

        // Act & Assert
        spec.AsTracking.Should().Be(true);
    }
}