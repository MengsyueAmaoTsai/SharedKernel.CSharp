using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void ToErrorOr_Should_ConvertValueToErrorOr()
    {
        // Arrange & Act
        ErrorOr<int> errorOrFromValue = IntValue.ToErrorOr();
        ErrorOr<string> errorOrFromError = NotFoundError.ToErrorOr<string>();
        ErrorOr<string> errorOrFromListOfErrors = ValidationErrors.ToErrorOr<string>();
        ErrorOr<string> errorOrFromArrayOfErrors = ValidationErrors.ToArray().ToErrorOr<string>();

        // Assert
        errorOrFromValue.IsValue.Should().BeTrue();
        errorOrFromValue.Value.Should().Be(IntValue);

        errorOrFromError.IsError.Should().BeTrue();
        errorOrFromError.Errors.Should().Contain(NotFoundError);

        errorOrFromListOfErrors.IsError.Should().BeTrue();
        errorOrFromListOfErrors.Errors.Should().BeEquivalentTo(ValidationErrors);

        errorOrFromArrayOfErrors.IsError.Should().BeTrue();
        errorOrFromArrayOfErrors.Errors.Should().BeEquivalentTo(ValidationErrors);
    }
}