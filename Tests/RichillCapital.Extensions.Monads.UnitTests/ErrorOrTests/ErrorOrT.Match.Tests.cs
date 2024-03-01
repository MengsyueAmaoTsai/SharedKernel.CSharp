using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ErrorOrTMatchTests : MonadTests
{
    [Fact]
    public void Match_When_IsValue_Should_InvokeOnIsValueWithValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = TestValue
            .ToErrorOr()
            .Match(OnError, OnIsValue);

        // Assert
        result.Should().Be(TestValue * 2);
    }

    [Fact]
    public void Match_When_HasError_Should_InvokeOnHasErrorWithErrors_And_ReturnResultValue()
    {
        // Arrange & Act
        var result = TestError
            .ToErrorOr<int>()
            .Match(OnError, OnIsValue);

        // Assert
        result.Should().Be(1);
    }
}