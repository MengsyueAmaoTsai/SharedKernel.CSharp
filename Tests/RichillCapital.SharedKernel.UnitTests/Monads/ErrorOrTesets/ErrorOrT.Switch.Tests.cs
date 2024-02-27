using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Switch_WhenErrorOrIsSuccess_Should_ExecutesOnSuccessAction()
    {
        // Arrange
        ErrorOr<int> errorOr = IntValue
            .ToErrorOr();

        // Act & Assert
        errorOr
            .Switch(
                error => throw new Exception("Should not execute this action"),
                value => value.Should().Be(IntValue));
    }

    [Fact]
    public void Switch_WhenErrorOrIsFailure_Should_ExecutesOnFailureAction()
    {
        // Arrange
        ErrorOr<int> errorOr = NotFoundError
            .ToErrorOr<int>();

        // Act & Assert
        errorOr
            .Switch(
                error => error.Should().BeEquivalentTo([NotFoundError]),
                value => throw new Exception("Should not execute this action"));
    }
}