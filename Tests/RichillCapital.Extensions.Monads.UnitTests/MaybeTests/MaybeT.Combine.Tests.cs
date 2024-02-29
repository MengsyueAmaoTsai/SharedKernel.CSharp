using RichillCapital.Extensions.Monads.UnitTests.Shared;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests;

public sealed partial class MaybeTCombineTests : MonadTests
{
    [Fact]
    public void CombineFactory_When_AllMaybesAreHaveValue_Should_ReturnLastMaybeWithAValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Combine(
            Maybe<int>.Have(1),
            Maybe<int>.Have(2),
            Maybe<int>.Have(3));

        // Assert
        maybe.ShouldBeHasValueWith(3);
    }

    [Fact]
    public void CombineFactory_When_MaybesContainNull_Should_ReturnMaybeNull()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Combine(
            Maybe<int>.Have(1),
            Maybe<int>.Null,
            Maybe<int>.Have(3));

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void CombineFactory_When_AllResultsAreSuccess_Should_ConvertLastResultToMaybeWithValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Combine(
            Result<int>.Success(1),
            Result<int>.Success(2),
            Result<int>.Success(3));

        // Assert
        maybe.ShouldBeHasValueWith(3);
    }

    [Fact]
    public void CombineFactory_When_ResultsContainFailure_Should_ReturnMaybeNull()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Combine(
            Result<int>.Failure(UnexpectedError),
            Result<int>.Failure(NotFoundError),
            Result<int>.Success(3));

        // Assert
        maybe.ShouldBeNull();
    }

    [Fact]
    public void CombineFactory_When_AllErrorOrsAreValue_Should_ConvertLastErrorOrToMaybeWithValue()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Combine(
            1.ToErrorOr(),
            2.ToErrorOr(),
            3.ToErrorOr());

        // Assert
        maybe.ShouldBeHasValueWith(3);
    }

    [Fact]
    public void CombineFactory_When_ErrorOrsContainError_Should_ReturnFirstErrorOr()
    {
        // Arrange & Act
        var maybe = Maybe<int>.Combine(
            1.ToErrorOr(),
            UnexpectedError.ToErrorOr<int>(),
            3.ToErrorOr());

        // Assert
        maybe.ShouldBeNull();
    }
}