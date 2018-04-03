using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

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
            Circle a = new Circle(1);
            Circle b = new Circle(2);
            Circle c = new Circle(3);
            Square x = new Square(4);
            Square y = new Square(5);
            Square z = new Square(6);

            b.UpdateRadius(20);
            z.UpdateSide(60);


            string s = JsonConvert.SerializeObject(a);
            Console.WriteLine(s);
            File.WriteAllText(@"C:\Users\Oliver\Documents\a.json", JsonConvert.SerializeObject(a));
           

            Circle a1 = JsonConvert.DeserializeObject<Circle>(File.ReadAllText(@"C:\Users\Oliver\Documents\a.json"));

            a.Print();
            a1.Print();
            b.Print();
            c.Print();
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

        [JsonConstructor]
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