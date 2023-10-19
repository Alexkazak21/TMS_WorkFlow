
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
        Doctor doctor;
        if (_id == 1) 
        {
            doctor = new Hirurg("Иванов", "Хирург");
        }
        else if (_id == 2) 
        {
            doctor = new Dentist("Петров", "Стоматолог");
        }
        else
        {
            doctor = new Terapevt("Сидоров", "Терапевт");
        }

        doctor.Heal();
    }
}
