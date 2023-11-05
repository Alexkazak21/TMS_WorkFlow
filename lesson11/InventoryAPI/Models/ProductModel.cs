namespace InventoryAPI.Models;

public class ProductModel
{
    public decimal Price { get; set; }
    public string? Id { get; set; }
    public int Amount { get; set; }
    public string? Category { get; set; }
}
