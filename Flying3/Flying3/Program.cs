using System;
using System.IO;
namespace ConsoleApp1
{
    class Flying
    {
        const double g = 9.8;
        public void Trajectory()
        {
            string path1 = @"C:\Users\Dmitry.Solodilov\Desktop\input.txt";
            string[] readEveryLine = new string[7];
            readEveryLine = File.ReadAllLines(path1);
            string sVx_first = readEveryLine[0];// начальная скорость по x
            string sVy_first = readEveryLine[1];// начальная скорость по y
            string sx_first = readEveryLine[2];// начальная позиция по x
            string sy_first = readEveryLine[3];// начальная позиция по y
            string sk = readEveryLine[4];// коэффициент сопротивления полету, по умолчанию 0
            string sm = readEveryLine[5];// масса тела
            string sdelta_t = readEveryLine[6];// временной интервал

            double Vx_first = Convert.ToDouble(sVx_first);
            double Vy_first = Convert.ToDouble(sVy_first);
            double x_first = Convert.ToDouble(sx_first);
            double y_first = Convert.ToDouble(sy_first);
            double k = Convert.ToDouble(sk);
            double m = Convert.ToDouble(sm);
            double delta_t = Convert.ToDouble(sdelta_t);
            double x;
            double y;
            double Vx;
            double Vy;

            string path2 = @"C:\Users\Dmitry.Solodilov\Desktop\output.txt";
            if (File.Exists(path2))
                File.WriteAllText(path2, string.Empty);
            else Console.WriteLine("Не указан файл");

            
            File.AppendAllText(path2,x_first + "\t\t\t\t" + y_first + "\n");
            for (int i = 1; i < 1000; i++)
            {
               
                x = x_first + delta_t * Vx_first;
                Vx = Vx_first - delta_t * k * Vx_first / m;
                x_first = x;
                Vx_first = Vx;
                y = y_first + delta_t * Vy_first;
                Vy = Vy_first - delta_t * (g + k * Vy_first / m);
                y_first = y;
                Vy_first = Vy;
                if (y < 0)
                {
                    y = 0;
                    File.AppendAllText(path2, delta_t * i + "\t\t\t\t" + Math.Round(x, 3) + "\t\t\t\t" + Math.Round(y, 3) + "\n");
                    break;
                }
                File.AppendAllText(path2, delta_t * i + "\t\t\t\t" + Math.Round(x, 3) + "\t\t\t\t" + Math.Round(y, 3) + "\n");
            }
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