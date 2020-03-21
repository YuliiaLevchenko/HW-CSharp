using System;
using PolinomLib;
using MyArrayLib;

namespace HW5
{
    class Program
    {
        static void Main()
        {
            Polinom pol = new Polinom(5);
            pol[0] = 1;
            pol[1] = 2;
            pol[2] = 3;
            pol[4] = 1;
            pol[5] = 2;

            Polinom pol1 = new Polinom(3);
            pol1[0] = -1;
            pol1[2] = 1;
            pol1[3] = 0;


            Polinom pol2 = pol1 * pol;
            Console.WriteLine(pol2.ToString());

            MyArray arr = new MyArray(13, 3);
            for(int i=arr.start; i <= arr.end; i++)
            {
                arr[i] = i;
            }

            Console.WriteLine(string.Format("array = {0},{1},{2}", arr[13], arr[14], arr[15]));
            Console.WriteLine(string.Format("array start = {0}, end={1},length={2}", arr.start, arr.end, arr.N));

        }
           
    }
}

