using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed class ResultTEnsureTests : MonadTests
{
    [Fact]
    public void EnsureFactory_When_GivenPredicateIsTrue_Should_CreateSuccessResultWithValue()
    {
        // Arrange & Act
        Result<int> valueResult = Result<int>
            .Ensure(Value, value => value == 5, UnexpectedError);

        // Assert
        valueResult.ShouldBeSuccessWith(Value);
    }

    [Fact]
    public void EnsureFactory_When_GivenPredicateIsFalse_Should_CreateFailureResultWithError()
    {
        // Arrange & Act
        Result<int> valueResult = Result<int>
            .Ensure(Value, value => value == 10, UnexpectedError);

        // Assert
        valueResult.ShouldBeFailureWith(UnexpectedError);
    }

    [Fact]
    public void EnsureFactory_When_GivenMultiplePredicatesAndAllAreTrue_Should_CreateSuccessResultWithValue()
    {
        // Arrange & Act  
        var result = Result<string>
            .Ensure(ValidEmail, EmailRules);

        // Assert
        result.ShouldBeSuccessWith(ValidEmail);
    }

    [Fact]
    public void EnsureFactory_When_GivenMultiplePredicatesAndOneIsFalse_Should_CreateFailureResultWithError()
    {
        // Arrange & Act
        var result = Result<string>
            .Ensure(InvalidEmail, EmailRules);

        // Assert
        result.ShouldBeFailureWith(Error.Invalid("Email does not contain '@'."));
    }
}