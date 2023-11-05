namespace InventoryAPI.Models;

public class StashModel
{
    public string Category { get; set; } = "";
    public List<ProductModel>? Inventoties { get; set; } = new List<ProductModel>();
}
