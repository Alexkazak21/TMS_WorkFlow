namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATM aTM = new ATM();
            aTM.AddMoney(300, 300, 300);
            Console.WriteLine(aTM.Total_Sum + "\n");
            bool mark = true;
            do
            {
                Console.WriteLine("Введите нужную сумму");

                if (int.TryParse(Console.ReadLine(),out int sum))
                {
                    mark = aTM.PullMoney(sum);
                }
                else
                {
                    Console.WriteLine("Try again");
                    Thread.Sleep(1500);
                }
                
              
                
            } 
            while (mark);
            

        }
    }
}