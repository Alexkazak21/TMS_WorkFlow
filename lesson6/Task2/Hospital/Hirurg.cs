
namespace Task2.Hospital;

internal class Hirurg : Doctor, IHeal
{
    public Hirurg(string name, string specialization) : base(name, specialization)
    {
    }

    public void Heal()
    {
        Console.WriteLine($"{Specialization} {Name} вырезал всё не нужное");
    }
}
