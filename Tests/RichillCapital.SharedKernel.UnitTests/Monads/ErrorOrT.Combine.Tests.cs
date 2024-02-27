using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericErrorOrTests : MonadTests
{
    [Fact]
    public void Combine_When_AnyErrorInErrorOrs_Should_CreateErrorOrWithErrors()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>
            .Combine(
                ErrorOr<int>.Ensure(5, x => x > 10, Error.Invalid("Error1")),
                ErrorOr<int>.Ensure(5, x => x < 3, Error.Invalid("Error2")),
                ErrorOr<int>.Ensure(5, x => x > 0, Error.Invalid("Error3")));

        // Assert
        errorOr.IsError.Should().BeTrue();
        errorOr.Errors.Should().HaveCount(2);
        errorOr.Errors.Should().Contain([Error.Invalid("Error1"), Error.Invalid("Error2")]);
        errorOr.Errors.Should().NotContain(Error.Invalid("Error3"));
    }

    [Fact]
    public void Combine_When_NoErrorsInErrorOrs_Should_CreateErrorOrWithFirstValue()
    {
        // Arrange & Act
        var errorOr = ErrorOr<int>
            .Combine(
                ErrorOr<int>.Ensure(15, x => x > 0, Error.Invalid("Error1")),
                ErrorOr<int>.Ensure(1, x => x < 7, Error.Invalid("Error2")),
                ErrorOr<int>.Ensure(5, x => x > 2, Error.Invalid("Error3")),
                ErrorOr<int>.Ensure(8, x => x > 3, Error.Invalid("Error4")));

        // Assert
        errorOr.IsValue.Should().BeTrue();
        errorOr.Value.Should().Be(15);
    }
}