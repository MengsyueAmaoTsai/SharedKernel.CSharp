using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Switch_WhenResultIsSuccess_Should_ExecutesOnSuccessAction()
    {
        // Arrange
        Result<int> intResult = IntValue
            .ToResult();


        // Act & Assert
        intResult
            .Switch(
                value => value.Should().Be(IntValue),
                error => throw new Exception("Should not execute this action"));
    }

    [Fact]
    public void Switch_WhenResultIsFailure_Should_ExecutesOnFailureAction()
    {
        // Arrange
        Result<int> intResult = NotFoundError
            .ToResult<int>();

        // Act & Assert
        intResult
            .Switch(
                value => throw new Exception("Should not execute this action"),
                error => error.Should().Be(NotFoundError));
    }
}