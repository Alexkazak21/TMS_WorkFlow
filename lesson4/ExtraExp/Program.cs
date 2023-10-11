namespace ExtraExp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibonachi());
            //Bank();
            int[] mass = BubbleSort(new int[] { 1, 5, 8, 6, 7, 1, 5, 9, 5, 6, 3, 4 });
            foreach (int item in mass) 
            {
                Console.WriteLine(item + " ");
            }            
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

        static int[] BubbleSort(int[] array)
        {
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            return array;
        }
    }
}