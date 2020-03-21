using System;

namespace HW2_Additional
{
    class Program
    {
        static void Main(string[] args)
        {
            //Additional tasks
            //2-dimensional arrays
            int[,] array3 = new int[,] { { 10, -2, -3, 1 }, { -4, 4, 1, 3 }, { -11, 6, 8, 7 }, { 22, -11, 4, 6 } };
            int rows1 = array3.GetUpperBound(0) + 1;
            int cols1 = array3.GetUpperBound(1) + 1;

            //знаходження максимального числа за модулем
            int[] MaxInRows = new int[rows1];
            for (int i = 0; i < rows1; i++)
            {
                MaxInRows[i] = Math.Abs(array3[i, 0]);
                for (int j = 0; j < cols1 - 1; j++)
                {

                    if (Math.Abs(MaxInRows[i]) < Math.Abs(array3[i, j + 1]))
                    {
                        MaxInRows[i] = Math.Abs(array3[i, j + 1]);
                    }
                }
            }

            int Max = MaxInRows[0];
            for (int i = 1; i < rows1; i++)
            {
                if (Max < MaxInRows[i])
                {
                    Max = MaxInRows[i];
                }
            }

            //індекси розміщення мінімального елемента
            int[] MinIndexes = new int[rows1];
            for (int i = 0; i < rows1; i++)
            {
                MinIndexes[i] = array3[i, 0];
                for (int j = 0; j < cols1 - 1; j++)
                {

                    if (MinIndexes[i] > array3[i, j + 1])
                    {
                        MinIndexes[i] = array3[i, j + 1];
                    }
                }
            }

            int Min = MinIndexes[0];
            for (int i = 1; i < rows1; i++)
            {
                if (Min > MinIndexes[i])
                {
                    Min = MinIndexes[i];
                }
            }

            int count = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (array3[i, j] == Min)
                    {
                        count++;
                    }
                }
            }

            int cnt = 2;
            int[,] AllIndexes = new int[count, cnt];

            int z = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (array3[i, j] == Min)
                    {
                        AllIndexes[z, 0] = i;
                        AllIndexes[z, 1] = j;
                        z++;
                    }
                }
            }

            //Нахождение максимального отрицательного элемента
            int counter1 = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (array3[i, j] < 0)
                    {
                        counter1++;
                    }
                }
            }

            int[] newarr = new int[counter1];
            int d = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {

                    if (array3[i, j] < 0)
                    {
                        while (d < counter1)
                        {
                            newarr[d] = array3[i, j];
                            d++;
                            break;
                        }
                    }
                }
            }

            int Minn = newarr[0];
            for (int i = 1; i < counter1; i++)
            {
                if (Minn > newarr[i])
                {
                    Min = newarr[i];
                }
            }

            
            //мінімальне додатне значення
            int plus = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (array3[i, j] > 0)
                    {
                        plus++;
                    }
                }
            }

            int[] plusarray = new int[plus];
            int dd = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (array3[i, j] > 0)
                    {
                        while (dd < plus)
                        {
                            plusarray[dd] = array3[i, j];
                            dd++;
                            break;
                        }
                    }
                }
            }

            int Minplus = plusarray[0];
            for (int i = 0; i < plus; i++)
            {
                if (Minplus > plusarray[i])
                {
                    Minplus = plusarray[i];
                }
            }

            //індекс розміщення мінімального елемента з головної діагоналі
            int Mindiag = array3[0, 0];
            for (int i = 1; i < rows1; i++)
            {
                for (int j = 1; j < cols1; j++)
                {
                    if (i == j)
                    {
                        if (Mindiag > array3[i, j])
                        {
                            Mindiag = array3[i, j];
                        }
                    }
                }
            }

            int countdiag = 0;
            for (int i = 1; i < rows1; i++)
            {
                for (int j = 1; j < cols1; j++)
                {
                    if (i == j)
                    {
                        if (array3[i, j] == Mindiag)
                        {
                            countdiag++;
                        }
                    }
                }
            }

            int rowsdiag = 2;
            int[,] arrdiag = new int[countdiag, rowsdiag];
            int r = 0;
            for (int i = 1; i < rows1; i++)
            {
                for (int j = 1; j < cols1; j++)
                {
                    if (i == j)
                    {
                        if (array3[i, j] == Mindiag)
                        {
                            while (r < countdiag)
                            {
                                arrdiag[r, 0] = i;
                                arrdiag[r, 1] = j;
                                r++;
                                break;
                            }
                        }
                    }
                }
            }

            //індекси розміщення мінімального елемента побічної діагоналі
            int MinPob = array3[0, cols1 - 1];
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (i == cols1 - 1 - j)
                    {
                        if (MinPob > array3[i, j])
                        {
                            MinPob = array3[i, j];
                        }
                    }
                }
            }

            int CntMinPob = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (i == cols1 - 1 - j)
                    {
                        if (array3[i, j] == MinPob)
                        {
                            CntMinPob++;
                        }
                    }
                }
            }

            
            int MinPobCols = 2;
            int[,] MinPobIndexArray = new int[CntMinPob, MinPobCols];
            int h = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (i == cols1 - 1 - j)
                    {
                        if (array3[i, j] == MinPob)
                        {
                            MinPobIndexArray[h, 0] = i;
                            MinPobIndexArray[h, 1] = j;
                            h++;
                        }
                    }
                }
            }

            //індекс останнього входження елемента Р
            int P = 4;
            int PCnt = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (array3[i, j] == P)
                    {
                        PCnt++;
                    }
                }
            }

            int PCols = 2;
            int[,] PIndexes = new int[PCnt, PCols];
            int iter = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (array3[i, j] == P)
                    {
                        PIndexes[iter, 0] = i;
                        PIndexes[iter, 1] = j;
                        iter++;
                    }

                }
            }

            int[,] PIndexLast = new int[1, 2];
            PIndexLast[0, 0] = PIndexes[PCnt - 1, 0];
            PIndexLast[0, 1] = PIndexes[PCnt - 1, 1];

            //Добуток елементів матриці
            long prod = 1;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    prod *= array3[i, j];
                }
            }

            //Добуток від'ємних елементів матриці
            long prod1 = 1;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (array3[i, j] < 0)
                    {
                        prod1 *= array3[i, j];
                    }
                }
            }

            //Добуток елементів головної діагоналі
            long prod2 = 1;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (i == j)
                    {
                        prod2 *= array3[i, j];
                    }
                }
            }

            //Середнє арифметичне чисел, які менше або дорівнюють P
            int iter1 = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (array3[i, j] <= P)
                    {
                        iter1++;
                    }
                }
            }

            int[] PArr = new int[iter1];
            int ind = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (array3[i, j] <= P)
                    {
                        PArr[ind] = array3[i, j];
                        ind++;
                    }
                }
            }

            float sum = 0;
            for (int i = 0; i < ind; i++)
            {
                sum += PArr[i];
            }
            float aveg = sum / ind;

            
            //різниця суми чисел більше P та суми чисел менше P
            int SumPlus = 0;
            int SumMinus = 0;
            int SumRes = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (array3[i, j] > P)
                    {
                        SumPlus += array3[i, j];
                    }
                    else if (array3[i, j] < P)
                    {
                        SumMinus += array3[i, j];
                    }
                    SumRes = SumPlus - SumMinus;
                }
            }

            //сума елементів побічної діагоналі
            int SumPob = 0;
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (i == cols1 - 1 - j)
                    {
                        SumPob += array3[i, j];
                    }
                }
            }

            //сума мінімальних елементів у кожному стовпці
            int[] MinCol = new int[cols1];
            for (int i = 0; i < cols1; i++)
            {
                MinCol[i] = array3[0, i];
                for (int j = 0; j < rows1; j++)
                {
                    if (MinCol[i] > array3[j, i])
                    {
                        MinCol[i] = array3[j, i];
                    }
                }
            }

            int SumMin = 0;
            for (int i = 0; i < cols1; i++)
            {
                SumMin += MinCol[i];
            }
        }
    }
}