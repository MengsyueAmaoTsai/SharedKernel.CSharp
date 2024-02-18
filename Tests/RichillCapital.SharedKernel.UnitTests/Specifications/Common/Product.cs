namespace RichillCapital.SharedKernel.UnitTests.Specifications.Common;

public class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int StoreId { get; set; }

    public Store? Store { get; set; }
}