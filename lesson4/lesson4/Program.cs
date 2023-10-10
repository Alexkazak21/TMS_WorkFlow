namespace lesson4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = MatrixDeclare();

            MatrixInit(matrix);
            UserChoise(matrix);
        }

        static int[,] MatrixDeclare() 
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Введите размер матрицы в формате MxN");
                var inputSize = Console.ReadLine().Split('x');

                if (inputSize.Length != 2)
                {
                    ErrMess();
                }
                else if (int.TryParse(inputSize[0],out int m) && int.TryParse(inputSize[1], out int n))
                {
                    return new int[m, n];
                }
                else
                {
                    ErrMess();
                }
            }
            while (true);            
        }

        static void ErrMess()
        {
            Console.WriteLine("Вы ошиблись повторрите ввод");
            Thread.Sleep(1500);
        }

        static void MatrixInit(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            Console.WriteLine("Теперь необходимо присвоить значения каждому элементу");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Clear();
                    Console.WriteLine($"Введите значение для ячейки [{i},{j}]");
                    do
                    {
                        if(int.TryParse(Console.ReadLine(), out int item))
                        {
                            matrix[i,j] = item;
                            break;
                        }
                    }
                    while (true);
                }
            }
        }

        static void MatrixWrite(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            Console.Clear();
            Console.WriteLine("Ваша матрица имеет вид:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }

            Thread.Sleep(2000);
        }

        static int MatrixCount(int[,] matrix, char sign)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int count = 0;
            if (sign == '+')
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (matrix[i,j] > 0)
                        {
                            count++;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        static void MatrixSortASC(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++) 
            {
                for (int j = array.GetLength(1) - 1; j > 0; j--)
                {

                    for (int k = 0; k < j; k++)
                    {
                        if (array[i, k] > array[i, k + 1])
                        {
                            int temp = array[i, k];
                            array[i, k] = array[i, k + 1];
                            array[i, k + 1] = temp;
                        }
                    }
                }
            }
        }

        static void MatrixSortDESC(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++) 
            {
                for (int j = array.GetLength(1) - 1; j > 0; j--)
                {

                    for (int k = 0; k < j; k++)
                    {
                        if (array[i, k] < array[i, k + 1])
                        {
                            int temp = array[i, k];
                            array[i, k] = array[i, k + 1];
                            array[i, k + 1] = temp;
                        }
                    }
                }
            }
        }
        static int[,] MatrixReverce(int[,] array)
        {
            int[,]? tempMatrix = array.Clone() as int[,];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    tempMatrix[i, j] = array[i, (array.GetLength(1) - 1) - j];                   
                }
            }

            return tempMatrix;

        }
        static void UserChoise(int[,] matrix)
        {
            int item;
            bool marker = true;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Сделайте дальнейший выбор\n" +
                        "1. Найти количество положительных чисел в матрице\n" +
                        "2. Найти количество отрицательных чисел в матрице\n" +
                        "3. Cортировка элементов матрицы по возрастаанию\n" +
                        "4. Cортировка элементов матрицы по убыванию\n" +
                        "5. Инверсия элементов матрицы\n\n" +
                        "6. Отобразить матрицу\n" +
                        "7. Завершить работу");

                    if (int.TryParse(Console.ReadLine(), out item))
                    {
                        if (item > 0 && item < 8)
                        {
                            break;
                        }
                        ErrMess();
                    }
                    else
                    {
                        ErrMess();
                    }
                }
                while (true);

                switch (item)
                {
                    case 1:
                        {
                            Console.WriteLine($"Количество положительных чисел в матрице = {MatrixCount(matrix,'+')}");
                            Thread.Sleep(1500);
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine($"Количество отрицательных чисел в матрице = {MatrixCount(matrix, '-')}");
                            Thread.Sleep(1500);
                        }
                        break;
                    case 3:
                        {
                            MatrixSortASC(matrix);  
                        }
                        break;
                    case 4:
                        {
                            MatrixSortDESC(matrix);
                        }
                        break;
                    case 5:
                        {
                            matrix = MatrixReverce(matrix);
                        }
                        break;
                    case 6:
                        {
                            MatrixWrite(matrix);
                        }
                        break;
                    default:
                        {
                            marker = false;
                        }
                        break;
                }
            }
            while (marker);
            
        }
    }
}