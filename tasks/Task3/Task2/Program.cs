using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    interface IShape
    {
        double CalcArea(double a);
        double CalcCircumference(double a);
        void Print();
    }

    class Program
    { 
       

        static void Main(string[] args)
        {
            Circle a = new Circle(2.5);
            Circle b = new Circle(10);
            Circle c = new Circle(10);
            Square x = new Square(2.5);
            Square y = new Square(10);
            Square z = new Square(10);

            b.UpdateRadius(5);
            a.Print();
            b.Print();
            c.Print();
            z.UpdateSide(5);
            x.Print();
            y.Print();
            z.Print();
            Console.ReadLine();
        } 
    }
    class Circle : IShape
    {
        public double radius;
        private double area, circumference;

        public Circle(double newRadius)
        {
            if (newRadius < 0) throw new ArgumentOutOfRangeException("Lenght must be a positive Number");
            radius = newRadius;
            area = CalcArea(newRadius);
            circumference = CalcCircumference(newRadius);
        }




        public double CalcArea(double r)
        {
            return r * r * Math.PI;
        }
        public double CalcCircumference(double r)
        {
            return r * 2 * Math.PI;
        }
        public void UpdateRadius(double newRadius)
        { 
            if (newRadius< 0) throw new ArgumentOutOfRangeException("Lenght must be a positive Number");
            radius = newRadius;
            area = CalcArea(newRadius);
            circumference = CalcCircumference(newRadius);
        }
    public void Print()
        {
            Console.WriteLine("Ein Kreis mit dem Radius " + radius + " hat den Umfang: " + circumference + " und die Fläche: " + area);
        }
    }

    class Square : IShape
    {
        public double side;
        private double area, circumference;

        public Square(double newSide)
        {
            if (newSide < 0) throw new ArgumentOutOfRangeException("Lenght must be a positive Number");
            side = newSide;
            area = CalcArea(newSide);
            circumference = CalcCircumference(newSide);
        }




        public double CalcArea(double r)
        {
            return r * r;
        }
        public double CalcCircumference(double r)
        {
            return r * 4;
        }
        public void UpdateSide(double newSide)
        {
            if (newSide < 0) throw new ArgumentOutOfRangeException("Lenght must be a positive Number");
            side = newSide;
            area = CalcArea(newSide);
            circumference = CalcCircumference(newSide);
        }
        public void Print()
        {
            Console.WriteLine("Ein Quadrat mit der Seitenlänge " + side + " hat den Umfang: " + circumference + " und die Fläche: " + area);
        }
    }
}