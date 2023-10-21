
namespace Product_Inventory;

internal class Inventory
{
    private List<Product> _products;

    public List<Product> Products
    {
        get { return _products; }

        set { _products = value; }

    }

    public Inventory(List<Product> products)
    {
        _products = new List<Product>(products);
    }

    public decimal Sum_Products()
    {
        decimal sum = 0;
        foreach (var product in _products)
        {
            sum += product.Price * product.Amount;
        }

        return sum;
    }

    public void Show()
    {
        Console.Clear();
        Console.WriteLine("Содержимое инвентаря:\n");
        foreach (var product in _products)
        {
            Console.WriteLine($"Назване продукта: {product.Id}\n" +               
                $"Сумма единицы товара: {product.Price}\n" +
                $"Колличество единиц товара: {product.Amount}\n" +
                $"Общая стоимость товара: {product.Price * product.Amount}\n");
        }
        Console.WriteLine("Для проделжения нажмите любую кнопку .....");
        Console.ReadKey();
    }
}
