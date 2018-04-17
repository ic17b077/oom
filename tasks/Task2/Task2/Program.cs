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
            Circle a = new Circle(2.5,"Rot","Schwarz");
            Circle b = new Circle(10,"Blau","Weiss");
            Circle c = new Circle(10,"Gelb","Grün");
            b.Radius = 5;
            a.Print();
            b.Print();
            c.Print();
            Console.ReadLine();
        }
    }
    class Circle
    {
        private double PRadius;

        public double Radius {
            get { return PRadius; }

            set {
                if (value < 0) throw new ArgumentOutOfRangeException("Lenght must be a positive Number");
                PRadius = value;
                area = CalcArea(value);
                circumference = CalcCircumference(value);
            }
              
                }

        public double area { get; private set; }
        public double circumference { get; private set; }

        public string int_color;
        public string b_color;


        public Circle(double newRadius, string newint_color, string newb_color)
        {
            int_color = newint_color;
            b_color = newb_color;
            if (newRadius < 0) throw new ArgumentOutOfRangeException("Lenght must be a positive Number");
            PRadius = newRadius;
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
            Radius = newRadius;
            area = CalcArea(newRadius);
            circumference = CalcCircumference(newRadius);
        }
        public void Print()
        {
            Console.WriteLine("Der Kreis ist " + int_color + ", sein Rand ist " +b_color+". Er hat den Radius " + PRadius + ", den Umfang: " + circumference + " und die Fläche: " + area);
        }
    }
}