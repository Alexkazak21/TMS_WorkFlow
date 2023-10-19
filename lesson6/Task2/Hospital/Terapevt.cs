
namespace Task2.Hospital;

internal class Terapevt : Doctor, IHeal
{
    public Terapevt(string name, string specialization) : base(name, specialization)
    {
    }

    public override void Heal()
    {
        Console.WriteLine($"{Specialization} {Name} вылечил все болезни");
    }
}
