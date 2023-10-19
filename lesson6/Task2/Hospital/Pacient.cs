

namespace Task2.Hospital;

internal class Pacient
{
    readonly string _name;
    public Heal_Plan _plan;

    public Pacient(string name, int id)
    {
        _name = name;
        _plan = new Heal_Plan(id);
    }

    public void Write()
    {
        Console.WriteLine($"Пациент {_name} Лечится!!!");
        _plan.Thretment();
    }
}
