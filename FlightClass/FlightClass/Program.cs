using System;
namespace ConsoleApp1
{
    class Flying
    {
        public const double g = 9.8;
        public double Velosity;
        public double alpha;
        public void Trajectory()
        {

            Console.WriteLine("Введите скорость, с которой брошено тело:");
            Velosity = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите угол, под которым брошено тело:");
            alpha = Convert.ToDouble(Console.ReadLine());

            double t = 2 * Velosity * Math.Sin(alpha) / g;
            double t_c_double = Math.Round(t) * 10;
            int t_c = Convert.ToInt32(t_c_double);
            if (t < 0.5)
                t_c = 10;
            double[] Coord_y = new double[t_c];
            double[] Coord_x = new double[t_c];
            double value_x;
            double value_y;


            for (int i = 0; i < t_c; i++)
            {
                value_x = Velosity * t / t_c * i * Math.Cos(alpha);
                value_y = Velosity * t / t_c * i * Math.Sin(alpha) - g * Math.Pow(t / t_c * i, 2) / 2;
                Coord_x[i] = value_x;
                Coord_y[i] = value_y;
                Console.Write("Координата x: ");
                Console.WriteLine(Coord_x[i]);
                Console.Write("Координата y: ");
                Console.WriteLine(Coord_y[i]);
                Console.Write("Момент времени: ");
                Console.WriteLine(t / t_c * i);
                Console.WriteLine();
            }
            value_x = Velosity * t * Math.Cos(alpha);
            value_y = Velosity * t * Math.Sin(alpha) - g * Math.Pow(t, 2) / 2;
            if (value_y < 0)
                value_y = 0;
            Console.Write("Координата x: ");
            Console.WriteLine(value_x);
            Console.Write("Координата y: ");
            Console.WriteLine(value_y);
            Console.Write("Момент времени: ");
            Console.WriteLine(t);
            Console.WriteLine(Coord_x[4]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ProjectOne = new Flying();
            ProjectOne.Trajectory();
        }
    }

}
