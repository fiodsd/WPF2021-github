using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            const double g = 9.8;
            string Vstr;
            string alphastr;
            Console.WriteLine("Введите скорость, с которой брошено тело:");
            Vstr = Console.ReadLine();
            Console.WriteLine("Введите угол, под которым брошено тело:");
            alphastr = Console.ReadLine();
            double V = Convert.ToDouble(Vstr);
            double alpha = Convert.ToDouble(alphastr);
            alpha *= Math.PI/ 180;

            double t = 2 * V * Math.Sin(alpha) / g;
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
                value_x = V * t / t_c * i * Math.Cos(alpha);
                value_y = V * t / t_c * i * Math.Sin(alpha) - g * Math.Pow(t / t_c * i, 2) / 2;
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
            value_x = V * t * Math.Cos(alpha);
            value_y = V * t * Math.Sin(alpha) - g * Math.Pow(t, 2) / 2;
            if (value_y < 0) value_y = 0;
            Console.Write("Координата x: ");
            Console.WriteLine(value_x);
            Console.Write("Координата y: ");
            Console.WriteLine(value_y);
            Console.Write("Момент времени: ");
            Console.WriteLine(t);                                      
        }
    }
}

