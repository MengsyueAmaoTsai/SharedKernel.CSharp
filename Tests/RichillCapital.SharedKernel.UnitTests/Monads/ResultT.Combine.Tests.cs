using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests.Monads;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void Combine_When_AnyFailureInResults_Should_ReturnResultWithFirstError()
    {
        // Arrange & Act
        var result = Result<int>
            .Combine(
                Result<int>.Ensure(5, x => x > 10, Error.Invalid("Error1")),
                Result<int>.Ensure(5, x => x < 3, Error.Invalid("Error2")),
                Result<int>.Ensure(5, x => x > 0, Error.Invalid("Error3")));

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Error.Invalid("Error1"));
    }

    [Fact]
    public void Combine_When_NoFailuresInResults_Should_ReturnResultWithFirstValue()
    {
        // Arrange & Act
        var result = Result<int>
            .Combine(
                Result<int>.Ensure(15, x => x > 0, Error.Invalid("Error1")),
                Result<int>.Ensure(1, x => x < 7, Error.Invalid("Error2")),
                Result<int>.Ensure(5, x => x > 2, Error.Invalid("Error3")),
                Result<int>.Ensure(8, x => x > 3, Error.Invalid("Error4")));

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(15);
    }
}