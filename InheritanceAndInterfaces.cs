using System;

namespace HW7
{
    class InheritanceAndInterfaces
    {
        public static void Main()
        {
            Hare hare = new Hare();
            Wolf wolf = new Wolf();
            Deer deer = new Deer();
            Fox fox = new Fox();
            Animal[] MyAnimals = new Animal[] {hare,hare,hare,wolf,wolf,wolf,deer,deer,fox,fox };
            int hareNumber = 0;
            int wolfNumber = 0;
            int deerNumber = 0;
            int foxNumber = 0;
            for (int i = 0; i < MyAnimals.GetUpperBound(0); i++)
            {
                if(MyAnimals[i] is Hare)
                {
                    hareNumber++;
                }
                else if(MyAnimals[i] is Wolf)
                {
                    wolfNumber++;
                }
                else if(MyAnimals[i] is Deer)
                {
                    deerNumber++;
                }
                else
                {
                    foxNumber++;
                }
            }

            Console.WriteLine(hareNumber);
            Console.WriteLine(wolfNumber);
            Console.WriteLine(deerNumber);
            Console.WriteLine(foxNumber);

            Rectangle s = new Square(5);
            Console.WriteLine(s.GetName());
            Console.WriteLine(s.GetArea());

            Triangle t = new IsoscelesTriangle(5);
            Console.WriteLine(t.GetName());
            Console.WriteLine(t.GetArea());
        }       
    }

    class Animal
    {

        public Animal()
        {

        }

        private Animal[] data;
        public Animal this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        public virtual void Eat()
        {
            Console.WriteLine("I can eat or I can eat grass");
        }
    }

    class Herbivorous : Animal
    {
        public Herbivorous() : base()
        {

        }

        public override void Eat()
        {
            Console.WriteLine("I eat grass");
        }
    }

    class Predator : Animal
    {
        public Predator() : base()
        {

        }

        public override void Eat()
        {
            Console.WriteLine("I eat meat");
        }


    }

    class Wolf : Predator
    {
        public Wolf() : base()
        {

        }
    }

    class Fox : Predator
    {
        public Fox() : base()
        {

        }
    }

    class Hare : Predator
    {
        public Hare() : base()
        {

        }
    }

    class Deer : Predator
    {
        public Deer() : base()
        {

        }
    }



    interface IShape
    {
        double GetArea();
        string GetName();
    }

    class Triangle : IShape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(double A, double B, double C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public double GetArea()
        {
            double p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public virtual string GetName()
        {
            string s = "Triangle";
            return s;
        }
    }

    class Circle: IShape
    {
        public double Radius { get; set; }

        public Circle(double Radius)
        {
            this.Radius = Radius;
        }
        public string GetName()
        {
            string s = "Circle";
            return s;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class Rectangle: IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double Width, double Height)
        {
            this.Width = Width;
            this.Height = Height;
        }
        public virtual string GetName()
        {
            string s = "Rectangle";
            return s;
        }

        public double GetArea()
        {
            return Width*Height;
        }

    }

    class Square : Rectangle
    {
        public double Side { get; set; }
        public Square(double Side) : base(Side, Side) { }
        public override string GetName()
        {
            string s = "Square";
            return s;
        }
    }

    class IsoscelesTriangle : Triangle
    {
        public float Side { get; set; }

        public IsoscelesTriangle(double Side) : base(Side, Side, Side) { }

        
        public override string GetName()
        {
            string s = "Isosceles Triangle";
            return s;
        }
    }
}



