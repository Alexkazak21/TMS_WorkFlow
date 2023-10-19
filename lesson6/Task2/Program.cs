using Task2.Hospital;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Pacient> pacients = new List<Pacient>() { new Pacient("Коля", 1), new Pacient("Вася", 2), new Pacient("Юля", 3) };

            foreach(Pacient p in pacients)
            {
                p.Write();
            }
        }
    }
}