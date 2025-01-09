using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class MaybeTFactoryTests : MonadTests
{
    [Fact]
    public void With_When_GivenValue_Should_CreateMaybeWithGivenValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>.With(TestValue);

        // Assert   
        maybe.ShouldBeHas(TestValue);
    }

    [Fact]
    public void With_When_GivenDefault_Should_CreateMaybeWithDefaultValue()
    {
        // Arrange & Act
        var maybeInt = Maybe<int>.With(default);
        var maybeString = Maybe<string>.With(default!);
        var maybeObject = Maybe<object>.With(default!);

        var defaultInt = 0;

        // Assert   
        maybeInt.ShouldBeHas(defaultInt);
        maybeString.ShouldBeNull();
        maybeObject.ShouldBeNull();
    }
}