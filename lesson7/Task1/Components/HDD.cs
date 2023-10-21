

namespace Task1.Components;

internal class HDD : IDisplay
{
    private readonly string _name;
    private readonly string _volume;
    private readonly string _type;

    public string Name { get { return _name; } }
    public string Volume { get { return _volume; } }
    public string Type { get { return _type; } }

    public HDD()
    {
        _name = "Не задано";
        _volume = "Не задано";
        _type = "Не задано";
    }
    public HDD(string name, string volume) : this()
    {
        _name = name;
        _volume = volume;
    }

    public HDD(string name, string volume, string type) : this(name,volume)
    {
        _type = type;
    }

   
    public string Show()
    {
        return ($"Название HDD: {_name}\n" +
            $"Объём HDD: {_volume}\n" +
            $"Тип HDD: {_type}");
    }
}

