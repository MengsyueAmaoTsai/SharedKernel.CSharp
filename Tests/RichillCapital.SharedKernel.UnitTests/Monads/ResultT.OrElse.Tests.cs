using FluentAssertions;

using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common;

namespace RichillCapital.SharedKernel.UnitTests;

public sealed partial class GenericResultTests : MonadTests
{
    [Fact]
    public void OrElse_When_ResultIsSuccess_Should_ReturnSuccessResultWithValue()
    {
        // Arrange & Act
        var expected = IntValue;

        Result<int> resultInt = Result<int>
            .Success(IntValue)
            .OrElse(50);

        // Assert
        resultInt.IsSuccess.Should().BeTrue();
        resultInt.Value.Should().Be(expected);
        resultInt.ValueOrDefault.Should().Be(expected);
    }

    [Fact]
    public void OrElse_When_ResultIsFailure_Should_ReturnSuccessResultWithElseValue()
    {
        // Arrange & Act
        var expected = 50;

        Result<int> resultInt = Result<int>
            .Failure(NotFoundError)
            .OrElse(expected);

        // Assert
        resultInt.IsSuccess.Should().BeTrue();
        resultInt.Value.Should().Be(expected);
        resultInt.ValueOrDefault.Should().Be(expected);
    }
}