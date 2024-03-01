using FluentAssertions;

using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTMatchTests : MonadTests
{
    [Fact]
    public void Match_When_HasValue_Should_InvokeOnHasValueWithValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var resultValue = TestValue
            .ToMaybe()
            .Match(OnValue, OnNull);

        // Assert
        resultValue.Should().Be(TestValue * 2);
    }

    [Fact]
    public void Match_When_HasNoValue_Should_InvokeOnHasNoValue_And_ReturnResultValue()
    {
        // Arrange & Act
        var resultValue = Maybe<int>
            .Null
            .Match(OnValue, OnNull);

        // Assert
        resultValue.Should().Be(0);
    }
}