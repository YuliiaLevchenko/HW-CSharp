using System;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            float side = 6;
            Square s = new Square(side);
            float per = s.CalculPerimeter();
            float sq = s.CalculSquare();

            float a1 = 3;
            float d = 2;
            int n = 4;
            ArProgression ar = new ArProgression(a1, d);
            float an = ar.GetNNumber(n);
            float SumN = ar.GetSum(n);
            float AveN = ar.GetAveNNumber(n);
        }
    }

    class Square
    {
        float side;


        public Square(float side)
        {
            this.side = side;
        }

        public float Side { get; set; }


        public float CalculPerimeter()
        {
            return side * 4;
        }
        public float CalculSquare()
        {
            return side * side;
        }
    }

    class ArProgression
    {
        float firstMember;
        float difference;

        public ArProgression(float a1, float d)
        {
            firstMember = a1;
            difference = d;
        }


        public float GetFirstMember()
        {
            return firstMember;
        }
        public float GetDifference()
        {
            return difference;
        }

        public float GetNNumber(int n)
        {
            return firstMember + (n - 1) * difference;
        }


        public float GetSum(int n)
        {
            float Sum = firstMember;
            for(int i = 2; i <= n; i++)
            {
                Sum += GetNNumber(i);
            }
            return Sum;
        }

        public float GetAveNNumber(int n)
        {
            return GetSum(n) / n;
        }

    }



}
