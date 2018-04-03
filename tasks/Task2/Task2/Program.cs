using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle a = new Circle(2.5);
            Circle b = new Circle(10);
            Circle c = new Circle(10);
            b.UpdateRadius(5);
            a.Print();
            b.Print();
            c.Print();
            Console.ReadLine();
        }
    }
    class Circle
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




        private double CalcArea(double r)
        {
            return r * r * Math.PI;
        }
        private double CalcCircumference(double r)
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
}