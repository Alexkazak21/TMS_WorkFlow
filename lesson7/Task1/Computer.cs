using Task1.Components;
namespace Task1;

internal class Computer
{
    private readonly decimal _price;
    private readonly string _model;
    private readonly RAM _ram;
    private readonly HDD _hdd;

    public Computer(decimal price,string model)
    {
        _price = price;
        _model = model;
        _ram = new RAM();
        _hdd = new HDD();
    }

    public Computer(decimal price, string model, RAM Ram, HDD Hdd) : this(price, model)
    {
        _ram = Ram;
        _hdd = Hdd;
    }

    public void Show_Info()
    {
        Console.WriteLine($"Цена: {_price}\n" +
            $"Модель: {_model}\n" +
            $"{_ram.Show()}" +
            $"{_hdd.Show()}");
    }
}
