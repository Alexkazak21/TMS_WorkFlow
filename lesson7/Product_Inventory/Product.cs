
namespace Product_Inventory;

internal class Product
{
    private readonly decimal _price;
    private readonly string _id;
    private readonly int _ammount;

    public decimal Price { get => _price; }
    public string Id { get => _id; }
    public int Amount { get => _ammount;}

    public Product(decimal price, string id, int ammount)
    {
        _price = price;
        _id = id;
        _ammount = ammount;
    }
}
