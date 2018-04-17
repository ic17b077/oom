using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Subjects;

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
            Circle a = new Circle(2);
            var producer = new Subject<double>();
            producer.Subscribe(x => a.UpdateRadius(x));

            for (var i = 0; i < 100; i += 10)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                producer.OnNext(i);
                a.Print();
            }



            Task<double> result = Task.Run(() => getAreaofCircle(10));
            result.ContinueWith(t => Console.WriteLine("Ein Kreis mit dem Radius 10 hat die Fläche:" + t.Result));

            Task<double> cylinder = Task.Run(() => getCylinderVolFromCircleAsync(10, 10));
           cylinder.ContinueWith(t => Console.WriteLine("Ein Zylinder mit dem Radius 10 und der Höhe 10 hat das Volumen:" + t.Result));


            //string s = JsonConvert.SerializeObject(a);
            // Console.WriteLine(s);
            // File.WriteAllText(@"C:\Users\Oliver\Documents\a.json", JsonConvert.SerializeObject(a));


            //Circle a1 = JsonConvert.DeserializeObject<Circle>(File.ReadAllText(@"C:\Users\Oliver\Documents\a.json"));

            //a.Print();
            //a1.Print();
            //b.Print();
            //c.Print();
            //x.Print();
            //y.Print();
            //z.Print();
            Console.ReadLine();
        }

        static double getAreaofCircle(double radius)
        {
            double area;
            Circle x = new Circle(radius);
            area = x.area;
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            return area;
        }
        static async Task<double> getCylinderVolFromCircleAsync(double radius, double height)
        {
            double area;
            area = await Task.Run(() => getAreaofCircle(10));
            double volume = area * height;
            return volume;
        }
    }
    class Circle : IShape
    {
        public double radius;
        public double area { get; private set;}
        public double circumference { get; private set;}


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