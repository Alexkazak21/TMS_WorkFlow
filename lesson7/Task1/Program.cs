using Task1.Components;
namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Computer computer1 = new Computer(12334.0M, "Asus UltraBook");
            Computer computer2 = new Computer(34245.0M, "MSI Katana",new RAM("DDR 5","16Gb"),new HDD("Samsung Evo870","512Gb","Внутренний"));

            computer1.Show_Info();
            Console.WriteLine();
            computer2.Show_Info();
            Console.ReadLine();
        }
    }
}