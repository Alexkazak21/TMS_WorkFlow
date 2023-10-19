
namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Phone> phoneList = new List<Phone>()
            {
                new Phone("345-654-23", "s23", "254g"),
                new Phone("435-167-98", "12 pro", "596g"),
                new Phone("333-977-34", "P40", "200g")
            };

            foreach (Phone phone in phoneList) 
            {
                Console.WriteLine($"Номер телефона: {phone.Number}, модель: {phone.Model},вес: {phone.Weight}");
                phone.ReciveCall("Ivanov");
                phone.GetNumber();
                phone.ReciveCall("Petrov", "368-269-56");
            }
            phoneList[1].SendMessage(new string[] { "455-875-99", "665-998-88", "542-987-675" });

        }
    }
}