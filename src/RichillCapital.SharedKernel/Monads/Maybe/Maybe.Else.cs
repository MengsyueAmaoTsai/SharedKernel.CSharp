namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Maybe<TValue>
{
}

public static partial class MaybeExtensions
{
    /// <summary>
    /// Returns the value of the <see cref="Maybe{TValue}"/> if it is not null, otherwise returns the specified value.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public static Maybe<TValue> Else<TValue>(
        this Maybe<TValue> maybe,
        TValue elseValue)
    {
        if (maybe.IsNull)
        {
            return elseValue.ToMaybe();
        }

        return maybe.Value.ToMaybe();
    }
}