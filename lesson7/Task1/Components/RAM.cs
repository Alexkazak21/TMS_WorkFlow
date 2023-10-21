
namespace Task1.Components;

internal class RAM : IDisplay
{
    private readonly string _name;
    private readonly string _volume;

    public string Name { get { return _name; } }
    public string Volume { get { return _volume; } }

    public RAM()
    {
        _name = "Не найденио";
        _volume = "Не найденио";
    }
    public RAM(string name, string volume) : this()
    {
        _name = name;
        _volume = volume;
    }

    public string Show()
    {
        return $"Название ОЗУ: {_name}\n" +
            $"Объём ОЗУ: {_volume}\n";
    }
}