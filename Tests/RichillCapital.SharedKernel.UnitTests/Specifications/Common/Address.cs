namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common;

public class Address
{
    public int Id { get; set; }

    public string? Street { get; set; }

    public int StoreId { get; set; }

    public Store? Store { get; set; }

    public object GetSomethingFromAddress() => new();
}