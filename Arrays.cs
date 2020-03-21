using System;

namespace HW2_MainTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Завдання 1
            int n = 31;
            int m = 8;
            uint n1 = 12;
            float Ave = AverageOfSequence(n, m);
            float Ave1 = AverageOfSequence1(m, n);
            uint Even = SumOfEven(n1);
            int SumEven = SumOfEvenAdvanced(m, n);
            int SumEven1 = SumOfEvenAdvanced1(n, m);


            //Завдання 2
            int[] MyArray = new int[] { 1, 4, 6, 2, -10, 8, 3, 6, 8, 8 };
            int[] ArrayForExchange = new int[MyArray.Length];
            for (int i = 0; i < MyArray.Length; i++)
            {
                ArrayForExchange[i] = MyArray[i];
            }
            exchange(ref ArrayForExchange);

            int Distance = MaxesDistance(MyArray);

            //Завдання 3
            int[,] MyArray2 = new int[,] { { 1, 4, 6 }, { 2, -10, 8 }, { 3, 6, 8 } };
            int r = MyArray2.GetUpperBound(0) + 1;
            int c = MyArray2.GetUpperBound(1) + 1;
            int[,] ArrayForExchange2 = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    ArrayForExchange2[i, j] = MyArray2[i, j];
                }
            }
            Changes(ref ArrayForExchange2);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write(ArrayForExchange2[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        //обчислення середнього арифметичного цілих чисел в діапазоні
        //варіант 1
        static float AverageOfSequence(int n, int m)
        {
            float avg = 0;
            if (n <= m)
            {
                for (int i = n; i <= m; i++)
                {
                    avg += i;
                }
            }
            else
            {
                for (int i = n; i >= m; i--)
                {
                    avg += i;
                }
            }
            avg /= (Math.Abs(m - n) + 1);
            return avg;
        }

        //варіант 2
        static float AverageOfSequence1(int n, int m)
        {
            float avg = 0;
            for (int i = Math.Min(n, m); i <= Math.Max(n, m); i++)
            {
                avg += i;
            }
            avg /= (Math.Abs(m - n) + 1);
            return avg;
        }


        //функція пошуку суми парних чисел від 0 до n включно
        static uint SumOfEven(uint n)
        {
            uint sum = 0;
            uint iterator = 0;
            while (iterator <= n)
            {
                sum += iterator;
                iterator += 2;
            }
            return sum;
        }

        //сума парних чисел від n1 До n2
        //варіант 1
        static int SumOfEvenAdvanced(int n1, int n2)
        {
            int sum = 0;
            if (n1 < n2)
            {
                int iterator = n1;
                while (iterator <= n2)
                {
                    sum += iterator;
                    iterator += 2;
                }
                return sum;
            }
            else
            {
                int iterator = n2;
                while (iterator <= n1)
                {
                    sum += iterator;
                    iterator += 2;
                }
                return sum;
            }
        }

            //варіант 2
            static int SumOfEvenAdvanced1(int n1, int n2)
        {
            int sum = 0;
            int iterator = Math.Min(n1, n2);
            while (iterator <= Math.Max(n1, n2))
            {
                sum += iterator;
                iterator += 2;
            }
            return sum;
        }

        //поменять местами значения в одномерном массиве
        static void exchange(ref int[] Array)
        {
            int temp = 0;
            int length = Array.Length;
            for (int i = 0; i < length / 2; i++)
            {
                temp = Array[i];
                Array[i] = Array[length - 1 - i];
                Array[length - 1 - i] = temp;
            }
        }

        //Найти расстояние между первым и последним вхождениям максимального элемента
        static int MaxesDistance(int[] Array)
        {
            //max Value in the Array
            int MaxValue = Array[0];
            int length = Array.Length;
            for (int i = 0; i < length - 1; i++)
            {
                if (MaxValue < Array[i + 1])
                {
                    MaxValue = Array[i + 1];
                }
            }

            //how many times max is in Array
            int counter = 0;
            foreach (int i in Array)
            {
                if (i == MaxValue)
                {
                    counter++;
                }
            }

            //Array of max Value Indexes
            int[] MaxValueIndex = new int[counter];
            int k = 0;
            int MaxValueDistance = 0;
            while (k < counter)
            {
                for (int i = 0; i < length; i++)
                {
                    if (MaxValue == Array[i])
                    {
                        MaxValueIndex[k] = i;
                        k++;
                    }
                }
            }
            MaxValueDistance = MaxValueIndex[counter - 1] - MaxValueIndex[0];
            return MaxValueDistance;
        }



        //Матрица, в которой на главной диагонале єлементы остаются, ниже гавной диагонали - нули, выше - единицы
        static void Changes(ref int[,] A)
        {
            int rows = A.GetUpperBound(0) + 1;
            int cols = A.GetUpperBound(1) + 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i > j)
                    {
                        A[i, j] = 0;
                    }
                    else if (i < j)
                    {
                        A[i, j] = 1;
                    }
                    else
                    {
                        A[i, j] = A[i, j];
                    }
                }
            }

        }
    }
}