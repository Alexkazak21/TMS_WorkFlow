namespace Product_Inventory;

internal class Program
{
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory
        (
            new List<Product>
            {
                new  Product(121.0M,"Samsung S21",3),
                new  Product(1000.0M,"IPhone 800",5),
                new  Product(161.0M,"Huawei P40",18),
                new  Product(99.0M,"Xiaomi MI 9T Pro",9),
            }
        );

        inventory.Products.Add(new Product(44m, "Nothing 1", 55)); 

        inventory.Show();
        Console.WriteLine($"\nОбщая стоимость в инвентаре = {inventory.Sum_Products()}");
    }
}