namespace Catalog.Domain.Entities;

public class Category(string name)
    : BaseEntity<int>
{
    public string Name { get; set; } = name;

    public string? Url { get; set; }

    public string? ParentCategory { get; set; }
}