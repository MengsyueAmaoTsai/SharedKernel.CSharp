using System.Linq.Expressions;

using FluentAssertions;

using RichillCapital.SharedKernel.Specifications.Expressions;
using RichillCapital.SharedKernel.UnitTests.Specifications.Common;

namespace RichillCapital.SharedKernel.UnitTests.Specifications.Expressions;

public sealed class IncludeExpressionTests
{
    private readonly Expression<Func<Company, Country>> _expression;

    public IncludeExpressionTests() =>
        _expression = company => company.Country!;

    [Fact]
    public void Should_ThrowArgumentNullException_WhenExpressionIsNull()
    {
        // Arrange 
        Action action = () => new IncludeExpression(
            null!,
            typeof(Company),
            typeof(Country));

        // Act && Assert
        action.Should().Throw<ArgumentNullException>();
    }


    [Fact]
    public void Should_ThrowsArgumentNullException_WhenEntityTypeIsNull()
    {
        // Arrange
        Action action = () => new IncludeExpression(
            _expression,
            null!,
            typeof(Country));

        // Act && Assert
        action.Should()
            .Throw<ArgumentNullException>();
    }

    [Fact]
    public void ThrowsArgumentNullException_GivenNullForPropertyType()
    {
        // Arrange
        Action action = () => new IncludeExpression(
            _expression,
            typeof(Company),
            null!);

        // Act && Assert
        action.Should()
            .Throw<ArgumentNullException>();
    }

    [Fact]
    public void ThrowsArgumentNullException_GivenNullForPreviousPropertyType()
    {
        // Arrange
        Action action = () => new IncludeExpression(
            _expression,
            typeof(Company),
            typeof(Country),
            null!);

        // Act && Assert
        action.Should()
            .Throw<ArgumentNullException>();
    }
}