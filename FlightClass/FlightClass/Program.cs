using System;
using System.IO;
namespace ConsoleApp1
{
    class Flying
    {
        const double g = 9.8;
        public void Trajectory()
        { 
        string path1 = @"C:\Users\RED\Desktop\input.txt";
            string[] readEveryLine = new string[2];
            readEveryLine = File.ReadAllLines(path1);
            string Vstr = readEveryLine[0];
            string alphastr = readEveryLine[1];

            string path2 = @"C:\Users\RED\Desktop\output.txt";
            if (File.Exists(path2))
                File.WriteAllText(path2, string.Empty);
            else Console.WriteLine("Не указан файл");

            double Velosity = Convert.ToDouble(Vstr);
            double alpha = Convert.ToDouble(alphastr);
            alpha *= Math.PI / 180;

            double t = 2 * Velosity * Math.Sin(alpha) / g;
            double t_c = Math.Round(t) / 10;

            double value_x = Velosity * t * Math.Cos(alpha);
            double value_y = Velosity * t * Math.Sin(alpha) - g * Math.Pow(t, 2) / 2;

            File.AppendAllText(path2, "Момент времени:" + "\t" + "Координата x:" + "\t" + "Координата y:" + "\n");
            for (int i = 0; i < 10; i++)
            {
                double x = Velosity * t_c * i * Math.Cos(alpha);
                double y = Velosity * t_c * i * Math.Sin(alpha) - g * Math.Pow(t_c * i, 2) / 2;
                x = Math.Round(x, 3);
                y = Math.Round(y, 3);
                File.AppendAllText(path2, Math.Round(t_c * i, 3) + "\t\t\t\t" + x + "\t\t\t\t" + y + "\n");
            }
            value_x = Math.Round((Velosity * t * Math.Cos(alpha)), 3);
            value_y = Math.Round((Velosity * t * Math.Sin(alpha) - g * Math.Pow(t, 2) / 2), 3);
            File.AppendAllText(path2, Math.Round(t, 3) + "\t\t\t\t" + value_x + "\t\t\t\t" + value_y + "\n");
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
