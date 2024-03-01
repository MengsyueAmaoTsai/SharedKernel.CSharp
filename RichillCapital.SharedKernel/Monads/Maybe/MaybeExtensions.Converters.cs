using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public static partial class MaybeExtensions
{
    [Pure]
    [MethodImpl]
    public static Maybe<TValue> ToMaybe<TValue>(this TValue value) =>
        Maybe<TValue>.With(value);
}