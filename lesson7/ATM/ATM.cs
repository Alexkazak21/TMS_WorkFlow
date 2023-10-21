
namespace ATM;

internal class ATM
{
    private int _total_Sum = 0;
    public int _20_Ammount { get; set; } = 0;
    public int _50_Ammount { get; set; } = 0;
    public int _100_Ammount{ get; set; } = 0;

    public int Total_Sum { get => (_20_Ammount * 20) + (_50_Ammount * 50) + (_100_Ammount * 100); }
    public void AddMoney(int Ammount_20, int Ammount_50, int Ammount_100)
    {
        _20_Ammount += Ammount_20;
        _50_Ammount += Ammount_50;
        _100_Ammount += Ammount_100;
    }
    
    public bool PullMoney(int pull_reqest)
    {
        int work_reqest = pull_reqest;
        if (work_reqest > Total_Sum)
        {
            Console.WriteLine("Недостаточно средств в банкомате");
            Console.WriteLine("Для продолженияя нажмите любую кнопку.....");
            Console.ReadKey();
            return false;
        }
        else 
        {
            Console.Clear();

            Console.WriteLine("Операция одобрена");
            int max_sum = 0;
            do
            {
                if (work_reqest / 00 > 0 && work_reqest % 100 > 0 && work_reqest / 100 < _100_Ammount)
                {
                    max_sum = work_reqest / 100 * 100;
                    work_reqest %= 100;
                }
                else if (work_reqest / 50 > 0 && work_reqest / 50 < _50_Ammount)
                {
                    max_sum += (work_reqest / 50 * 50);
                    work_reqest %= 50;
                }
                else if (work_reqest / 20 > 0 && work_reqest / 20 < _20_Ammount)
                {
                    max_sum += ((work_reqest / 20) * 20);
                    work_reqest %= 20;
                }
                
            } while (work_reqest / 20 > 0);

            if (pull_reqest > max_sum)
            {
                Console.WriteLine($"Максимальная сумма к выдаче: {max_sum}");
                return true;
            }
            else
            {
                Console.WriteLine($"Будет выдано {max_sum}");
            }

            return false;
        }
    }
}
