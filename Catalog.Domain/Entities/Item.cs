namespace Catalog.Domain.Entities;

/// <summary>
/// aka Product
/// </summary>
public class Item(string name, string category)
    : BaseEntity<int>
{
    public string Name { get; set; } = name;

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string Category { get; set; } = category; // one item can belong to only one category

    public decimal Price { get; set; }

    public int Amount { get; set; }
}