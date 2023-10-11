namespace ExtraExp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibonachi());
            Bank();
        }

        static string Fibonachi()
        {
            string str = string.Empty;
            int[] mass = new int[11];
            mass[0] = 0;
            mass[1] = 1;
            for (int i =  2; i < 11; i++)
            {
                mass[i] = mass[i - 2] + mass[i - 1];
            }

            foreach(int item in mass)
            {
                str += item + " ";
            }

            return str;
        }

        static void Bank()
        {
            float value;
            int mounth;
            do
            {
                Console.WriteLine("Введите сумму вклада");

                if (!float.TryParse(Console.ReadLine(), out  value))
                {
                    Console.WriteLine("Вы ошиблись, повторите ввод");
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Введите Колличество месяцев действия вклада");

                        if (!int.TryParse(Console.ReadLine(), out  mounth))
                        {
                            Console.WriteLine("Вы ошиблись, повторите ввод");
                        }
                        else
                        {
                            break;
                        }

                    } while (true);

                    break;
                }
            } while (true);
            
            for (int i = 0; i < mounth; i++)
            {
                value += value * 0.07f;
            }

            Console.WriteLine($"\n{value}");
        }

        static int[] BubbleSort(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
    }
}