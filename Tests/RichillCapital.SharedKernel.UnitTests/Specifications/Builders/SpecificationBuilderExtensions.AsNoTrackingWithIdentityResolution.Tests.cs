using FluentAssertions;

using RichillCapital.SharedKernel.UnitTests.Specifications.Common.Specs;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Builders;

public sealed class SpecificationBuilderExtensionsAsNoTrackingWithIdentityResolutionTests
{
    [Fact]
    public void Should_DoesNothing_When_GivenSpecWithoutAsNoTrackingWithIdentityResolution()
    {
        // Arrange
        var spec = new StoreEmptySpec();

        // Act & Assert
        spec.AsNoTrackingWithIdentityResolution.Should().Be(false);
    }

    [Fact]
    public void Should_DoesNothing_When_GivenAsNoTrackingWithIdentityResolutionWithFalseCondition()
    {
        // Arrange
        var spec = new CompanyByIdWithFalseConditions(1);

        // Act & Assert
        spec.AsNoTrackingWithIdentityResolution.Should().Be(false);
    }

    [Fact]
    public void Should_FlagsAsNoTracking_When_GivenSpecWithAsNoTrackingWithIdentityResolution()
    {
        // Arrange
        var spec = new CompanyByIdAsUntrackedWithIdentityResolutionSpec(1);

        // Act & Assert
        spec.AsNoTrackingWithIdentityResolution.Should().Be(true);
    }

    [Fact]
    public void Should_FlagsAsNoTracking_When_GivenSpecWithAsTrackingAndEndWithAsNoTrackingWithIdentityResolution()
    {
        // Arrange
        var spec = new CompanyByIdWithAsTrackingAsUntrackedWithIdentityResolutionSpec(1);

        // Act & Assert
        spec.AsNoTrackingWithIdentityResolution.Should().Be(true);
    }
}