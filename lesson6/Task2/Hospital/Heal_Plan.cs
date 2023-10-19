
namespace Task2.Hospital;

internal class Heal_Plan
{
    private readonly int _id;

    public Heal_Plan(int id)
    {
        _id = id;
    }

    public void Thretment()
    {
        if (_id == 1) 
        {
            Hirurg hirurg = new Hirurg("Иванов", "Хирург");
            hirurg.Heal();
        }
        else if (_id == 2) 
        {
            Dentist dentist = new Dentist("Петров", "Стоматолог");
            dentist.Heal();
        }
        else
        {
            Terapevt terapevt = new Terapevt("Сидоров", "Терапевт");
            terapevt.Heal();
        }
    }
}
