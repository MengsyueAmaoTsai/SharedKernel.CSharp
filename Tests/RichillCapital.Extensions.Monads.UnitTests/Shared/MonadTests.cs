using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests.Shared;

public abstract class MonadTests
{
    protected readonly static int TestValue = 5;

    protected readonly static Error TestError = Error.Unexpected("Unexpected error");
    protected readonly static List<Error> TestErrors =
    [
        Error.Invalid("Error 1"),
        Error.Invalid("Error 2"),
        Error.Invalid("Error 3"),
        Error.Invalid("Error 4"),
        Error.NotFound("Error 5"),
    ];

    protected static Error ErrorFactoryWithValue(int value) => Error.Invalid(value.ToString());

    protected static int OnHasValue(int value) => value * 2;
    protected static async Task<int> OnHasValueAsync(int value) => await Task.FromResult(value * 2);
    protected static int OnIsNull() => 0;
    protected static async Task<int> OnIsNullAsync() => await Task.FromResult(0);

    protected static int OnSuccess(int value) => value * 2;
    protected static async Task<int> OnSuccessAsync(int value) => await Task.FromResult(value * 2);
    protected static int OnSuccess() => 0;
    protected static int OnFailure(Error _) => 0;
    protected static async Task<int> OnFailureAsync(Error _) => await Task.FromResult(0);

    protected static int OnIsValue(int value) => value * 2;
    protected static async Task<int> OnIsValueAsync(int value) => await Task.FromResult(value * 2);
    protected static int OnHasError(IEnumerable<Error> errors) => errors.Count();
    protected static async Task<int> OnHasErrorAsync(IEnumerable<Error> errors) => await Task.FromResult(errors.Count());

    protected static void DoSomeAction()
    {
        // Do something
    }

    protected static void DoSomeActionWithValue(int _)
    {
        // Do something
    }

    protected static int ValueFactory() => TestValue * 2;
    protected static int ValueFactoryWithValue(int value) => value * 2;
    protected static Task<int> ValueFactoryWithValueTask(int value) => Task.FromResult(value * 2);

    protected static ErrorOr<string> ErrorOrFactoryWithValue(int value) =>
        value.ToString().ToErrorOr();

    protected static async Task<ErrorOr<string>> ErrorOrFactoryWithValueTask(int value) =>
        await Task.FromResult(value.ToString().ToErrorOr());

    protected static async Task<ErrorOr<string>> ErrorOrFactoryWithValueTask_HasError(int value) =>
        await Task.FromResult(TestErrors.ToErrorOr<string>());

    protected static Result<string> ResultFactoryWithValue(int value) =>
        value.ToString().ToResult();

    protected static async Task<Result<string>> ResultFactoryWithValueTask(int value) =>
        await Task.FromResult(value.ToString().ToResult());


    protected static async Task<Result<string>> ResultFactoryWithValueTask_IsFailure(int value) =>
        await Task.FromResult(TestError.ToResult<string>());

    protected static Maybe<string> MaybeFactoryWithValue(int value) =>
        value.ToString().ToMaybe();

    protected static async Task<Maybe<string>> MaybeFactoryWithValueTask(int value) =>
        await Task.FromResult(value.ToString().ToMaybe());

    protected static async Task<Maybe<string>> MaybeFactoryWithValueTask_Null(int value) =>
        await Task.FromResult(Maybe<string>.Null);

    protected static readonly Func<int, bool> EnsureTrue = new(value => value == 5);
    protected static readonly Func<int, bool> EnsureFalse = new(value => value > 10);
    protected static async Task<bool> EnsureTrueAsync(int value) => await Task.FromResult(value == 5);
    protected static async Task<bool> EnsureFalseAsync(int value) => await Task.FromResult(value == 3);


    protected static async Task<int> GetTestValueAsync() => await Task.FromResult(TestValue);
    protected static async ValueTask<int> GetTestValueValueTaskAsync() => await new ValueTask<int>(TestValue);

    protected static async Task<ErrorOr<int>> ErrorOrTaskWithValue() => await Task.FromResult(TestValue.ToErrorOr());
    protected static async Task<ErrorOr<int>> ErrorOrTaskWithErrors() => await Task.FromResult(TestErrors.ToErrorOr<int>());

    protected static async Task<Result<int>> ResultTaskWithValue() => await Task.FromResult(TestValue.ToResult());
    protected static async Task<Result<int>> ResultTaskWithError() => await Task.FromResult(TestError.ToResult<int>());

    protected static async Task<Maybe<int>> MaybeTaskWithValue() => await Task.FromResult(TestValue.ToMaybe());
    protected static async Task<Maybe<int>> MaybeTaskWithNull() => await Task.FromResult(Maybe<int>.Null);

}