namespace TMS_WorkFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalcWorkFlow();
        }

        static bool CalcWorkFlow()
        {
            while (true) 
            {
                bool main = UserChoise();
                if (main == false)
                {
                    Console.Clear();
                    Console.WriteLine("Работа успешно завершена.\nСпасибо, что были с нами)))");
                    Thread.Sleep(2000);
                    return false;
                }                
            }
        }

        static bool UserChoise()
        {
            Console.Clear();
            Console.WriteLine($"Выберите нужное действие по его номеру.\n" +
                $"1. Сложение\n" +
                $"2. Вычитание\n" +
                $"3. Умножение\n" +
                $"4. Деление\n" +
                $"5. Взятие остатка от числа\n" +
                $"6. Возведение в степень\n" +
                $"7. Извлечение корня\n\n" +
                $"0. Завершение работы");
    

             if(!int.TryParse(Console.ReadLine(),out int choise))
             {
                Console.WriteLine("Вы сделали неверный выбор пожалуста повторите попытку");
                Thread.Sleep(1000);
                UserChoise();
             }

            double firstOperand, secondOperand;
            switch (choise) 
            {
                case 1: 
                    {
                    firstOperMark:
                        Console.Clear();
                        Console.WriteLine("Вы выбрали сложение.\n" +
                            "Введете первое число");

                        if (!double.TryParse(Console.ReadLine(), out firstOperand))
                        {
                            Console.WriteLine("Необходимо ввести число либо вы привысили допустимый диапазон числа, пожалуста повторите попытку");
                            Thread.Sleep(1000);
                            goto firstOperMark;
                        }

                    secondOperMark:
                        Console.Clear();
                        Console.WriteLine("Введете второе число");
                        if (!double.TryParse(Console.ReadLine(), out secondOperand))
                        {
                            Console.WriteLine("Необходимо ввести число либо вы привысили допустимый диапазон числа, пожалуста повторите попытку");
                            Thread.Sleep(1000);
                            goto secondOperMark;
                        }

                        Console.Clear();
                        Console.WriteLine($"Сумма чисел {firstOperand} + {secondOperand} = {firstOperand + secondOperand}") ;
                        Console.WriteLine("Для продолжения нажмите любую кнопку......");
                        Console.ReadKey();

                    }
                    break;
                case 2:
                    {
                    firstOperMark:
                        Console.Clear();
                        Console.WriteLine("Вы выбрали вычитание.\n" +
                            "Введете первое число");

                        if (!double.TryParse(Console.ReadLine(), out firstOperand))
                        {
                            Console.WriteLine("Необходимо ввести число либо вы привысили допустимый диапазон числа, пожалуста");
                            Thread.Sleep(1000);
                            goto firstOperMark;
                        }

                    secondOperMark:
                        Console.Clear();
                        Console.WriteLine("Введете второе число");
                        if (!double.TryParse(Console.ReadLine(), out secondOperand))
                        {
                            Console.WriteLine("Необходимо ввести число либо вы привысили допустимый диапазон числа, пожалуста повторите попытку");
                            Thread.Sleep(1000);
                            goto secondOperMark;
                        }

                        Console.Clear();
                        Console.WriteLine($"Разность чисел {firstOperand} - {secondOperand} = {firstOperand - secondOperand}");
                        Console.WriteLine("Для продолжения нажмите любую кнопку......");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    {
                    firstOperMark:
                        Console.Clear();
                        Console.WriteLine("Вы выбрали умножение.\n" +
                            "Введете первое число");

                        if (!double.TryParse(Console.ReadLine(), out firstOperand))
                        {
                            Console.WriteLine("Необходимо ввести число либо вы привысили допустимый диапазон числа, пожалуста повторите попытку");
                            Thread.Sleep(1000);
                            goto firstOperMark;
                        }

                    secondOperMark:
                        Console.Clear();
                        Console.WriteLine("Введете второе число");
                        if (!double.TryParse(Console.ReadLine(), out secondOperand))
                        {
                            Console.WriteLine("Необходимо ввести число либо вы привысили допустимый диапазон числа, пожалуста повторите попытку");
                            Thread.Sleep(1000);
                            goto secondOperMark;
                        }

                        Console.Clear();
                        Console.WriteLine($"Произведение чисел {firstOperand} * {secondOperand} = {firstOperand * secondOperand}");
                        Console.WriteLine("Для продолжения нажмите любую кнопку......");
                        Console.ReadKey();
                    }
                    break;
                case 4:
                    {
                    firstOperMark:
                        Console.Clear();
                        Console.WriteLine("Вы выбрали деление.\n" +
                            "Введете первое число");

                        if (!double.TryParse(Console.ReadLine(), out firstOperand))
                        {
                            Console.WriteLine("Необходимо ввести число либо вы привысили допустимый диапазон числа, пожалуста повторите попытку");
                            Thread.Sleep(1000);
                            goto firstOperMark;
                        }

                    secondOperMark:
                        Console.Clear();
                        Console.WriteLine("Введете второе число");
                        if (!double.TryParse(Console.ReadLine(), out secondOperand))
                        {
                            Console.WriteLine("Необходимо ввести число либо вы привысили допустимый диапазон числа, пожалуста повторите попытку");
                            Thread.Sleep(1000);
                            goto secondOperMark;
                        }
                        else if(secondOperand == 0)
                        {
                            Console.WriteLine("На НОЛЬ делить нельзя");
                            Thread.Sleep(1000);
                            goto secondOperMark;
                        }

                        Console.Clear();
                        Console.WriteLine($"Частное чисел {firstOperand} / {secondOperand} = {firstOperand / secondOperand}");
                        Console.WriteLine("Для продолжения нажмите любую кнопку......");
                        Console.ReadKey();
                    }
                    break;
                case 5:
                    {
                    firstOperMark:
                        Console.Clear();
                        Console.WriteLine("Вы выбрали отсаток от деления.\n" +
                            "Введете первое число");

                        if (!double.TryParse(Console.ReadLine(), out firstOperand))
                        {
                            Console.WriteLine("Необходимо ввести число либо вы привысили допустимый диапазон числа, пожалуста повторите попытку");
                            Thread.Sleep(1000);
                            goto firstOperMark;
                        }

                    secondOperMark:
                        Console.Clear();
                        Console.WriteLine("Введете второе число");
                        if (!double.TryParse(Console.ReadLine(), out secondOperand))
                        {
                            Console.WriteLine("Необходимо ввести число либо вы привысили допустимый диапазон числа, пожалуста повторите попытку");
                            Thread.Sleep(1000);
                            goto secondOperMark;
                        }
                        else if (secondOperand == 0)
                        {
                            Console.WriteLine("На НОЛЬ делить нельзя");
                            Thread.Sleep(1000);
                            goto secondOperMark;
                        }

                        Console.Clear();
                        Console.WriteLine($"Остаток от деления чисел {firstOperand} и {secondOperand} = {firstOperand % secondOperand}");
                        Console.WriteLine("Для продолжения нажмите любую кнопку......");
                        Console.ReadKey();
                    }
                    break;
                case 6:
                    {
                    firstOperMark:
                        Console.Clear();
                        Console.WriteLine("Вы выбрали возведение в степень.\n" +
                            "Введете первое число");

                        if (!double.TryParse(Console.ReadLine(), out firstOperand))
                        {
                            Console.WriteLine("Необходимо ввести число либо вы привысили допустимый диапазон числа, пожалуста повторите попытку");
                            Thread.Sleep(1000);
                            goto firstOperMark;
                        }

                    secondOperMark:
                        Console.Clear();
                        Console.WriteLine("Введете степень в корорую хотите возвести число");
                        if (!double.TryParse(Console.ReadLine(), out secondOperand))
                        {
                            Console.WriteLine("Необходимо ввести число либо вы привысили допустимый диапазон числа, пожалуста повторите попытку");
                            Thread.Sleep(1000);
                            goto secondOperMark;
                        }                        

                        Console.Clear();
                        Console.WriteLine($"Возведение числа {firstOperand} в степень {secondOperand} = {Math.Pow(firstOperand,secondOperand)}");
                        Console.WriteLine("Для продолжения нажмите любую кнопку......");
                        Console.ReadKey();
                    }
                    break;
                case 7:
                    {
                    firstOperMark:
                        Console.Clear();
                        Console.WriteLine("Вы выбрали получение квадратного корня числа.\n" +
                            "Введете число");

                        if (!double.TryParse(Console.ReadLine(), out firstOperand))
                        {
                            Console.WriteLine("Необходимо ввести число либо вы привысили допустимый диапазон числа, пожалуста повторите попытку");
                            Thread.Sleep(1000);
                            goto firstOperMark;
                        }

                        Console.Clear();
                        Console.WriteLine($"Квадратный корень числа {firstOperand} = {Math.Sqrt(firstOperand)}");
                        Console.WriteLine("Для продолжения нажмите любую кнопку......");
                        Console.ReadKey();
                    }
                    break;
                default:
                    return false;
            }

            return true;
        }        
    }
}