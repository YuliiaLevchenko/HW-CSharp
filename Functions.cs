using System;

namespace Levchenko_HW3
{
    class Functions
    {

        static void SortArray(ref int[] array, string sort_type)
        {
            int swap = 0;
            if (sort_type == "ascending")
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            swap = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = swap;
                        }
                    }
                }

            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j] < array[j + 1])
                        {
                            swap = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = swap;
                        }
                    }
                }

            }
        }



        static int MultProgr(int a1, int t, int n)
        {
            int result = a1;
            if (n == 1)
            {
                return result;
            }
            else
            {
                for (int i = 2; i <= n; i++)
                {
                    result *= (a1 + (i - 1) * t);
                }
                return result;
            }
            
        }

        static int MultProgr1(int a1, int t, int n)
        {
            if (n == 1)
            {
                return a1;
            }
            else
            {
                return (a1 + (n - 1) * t) * MultProgr1(a1, t, n - 1);
            }
        }


        static float GeomMult(float a1, float t, float alim)
        {
            float result = 1;
            float an = a1;
            while(an>alim)
            {
                result *= an;
                an *= t;
            }
            return result;
        }

        static float GeomMult2(float a1, float t, float alim)
        {
            if (a1 * t < alim)
            {
                return a1;
            }
            else
            {
                return a1 * t * GeomMult2(a1, t * t, alim);
            }
        }


            static void Main(string[] args)
            {
                //TASK 1
                int[] A = new int[] { 10, 4, 2, 22, 35, 12, 1, 3, 25, 7, 8, 22, 10 };
                int[] B = new int[A.Length];
                for(int i=0; i < A.Length; i++)
                {
                    B[i] = A[i];
                }
                string choice = "ascending";
                SortArray(ref B, choice);


            int a = 5;
            int t = 2;
            int n = 3;
            int c = MultProgr(a,t,n);
            int d = MultProgr1(a, t, n);
            Console.WriteLine(c);
            Console.WriteLine(d);


            float a1 = 3;
            float t2 = 0.5f;
            float alim = 1;
            float g = GeomMult(a1, t2, alim);
            float gg = GeomMult2(a1, t2, alim);
            Console.WriteLine(g);
            Console.WriteLine(gg);
        }
       
    }
}
