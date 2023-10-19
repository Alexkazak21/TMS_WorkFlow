
namespace Task2.Hospital;

internal class Dentist : Doctor, IHeal
{
    public Dentist(string name, string specialization) : base(name, specialization)
    {
    }

    public override void Heal()
    {
        Console.WriteLine($"{Specialization} {Name} вылечил все зубки");
    }
}
