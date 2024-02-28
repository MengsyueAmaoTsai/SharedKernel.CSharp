
using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

public sealed class ResultTThenTests : MonadTests
{
    [Fact]
    public void Then_When_IsSuccess_Should_InvokeFunction_And_ReturnSuccessResultWithNewValue()
    {
        // Arrange & Act
        Result<int> resultInt = Result<string>
            .Ensure(ValidEmail, EmailRules)
            .Then(email => email.Length);

        // Assert
        resultInt.ShouldBeSuccessWith(ValidEmail.Length);
    }

    [Fact]
    public void Then_When_IsFailure_Should_NotInvokeFunction_And_ReturnFailureResultWithFirstError()
    {
        // Arrange & Act
        Result<int> resultInt = Result<string>
            .Ensure(InvalidEmail, EmailRules)
            .Then(email => email.Length);

        // Assert
        resultInt.ShouldBeFailureWith(Error.Invalid("Email does not contain '@'."));
    }
}