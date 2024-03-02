using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
    /// <summary>
    /// Combines a collection of <see cref="Maybe{TValue}"/> into a single <see cref="Maybe{TValue}"/>.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Maybe<TValue> Combine(params Maybe<TValue>[] maybes) =>
        maybes.Any(maybe => maybe.IsNull) ?
            Null :
            maybes.Last().Value.ToMaybe();
}