namespace TmsMvc.Models;

public class ProductModel
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public string? Name { get; set; }
    public int Amount { get; set; }
    public string? Category { get; set; }
}
