using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string StPosextext = StPosex.Text;
            //string StPoseytext = StPosey.Text;
            //double stPosex = Convert.ToDouble(StPosextext);
            //double stPosey = Convert.ToDouble(StPoseytext);//позиция
            //string Masstext = Mass.Text;
            //double mass = Convert.ToDouble(Masstext);//масса
            string StSpeedtext = StSpeed.Text;
            string Angletext = Angle.Text;

            if ((StSpeedtext != "") && (Angletext != ""))
            {
                double stSpeed = Convert.ToDouble(StSpeedtext);
                double angle = Convert.ToDouble(Angletext);
                const double g = 9.8;
                angle *= Math.PI / 180;
                double t = 2 * stSpeed * Math.Sin(angle) / g;
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
                    value_x = stSpeed * t / t_c * i * Math.Cos(angle);
                    value_y = stSpeed * t / t_c * i * Math.Sin(angle) - g * Math.Pow(t / t_c * i, 2) / 2;
                    Coord_x[i] = value_x;
                    Coord_y[i] = value_y;
                }
                value_x = stSpeed * t * Math.Cos(angle);
                value_y = stSpeed * t * Math.Sin(angle) - g * Math.Pow(t, 2) / 2;
                if (value_y < 0) value_y = 0;


                MessageBox.Show("Начальная скорость: " + StSpeedtext + "   " + "Угол: " + Angletext);
                MessageBox.Show("Конечная позиция по x: " + Math.Round(value_x, 3) + "   " + "Конечная позиция по y: " + Math.Round(value_y, 3) + "   " + "Момент времени: " + Math.Round(t, 3));
                //double multipliation = stPosex * stSpeed;
                //string multipliation_text = Convert.ToString(multipliation);
                //MessageBox.Show(multipliation_text);
                //double.TryParse(multipliation_text, out double b);

            }
            else
            {
                MessageBox.Show("Enter your text!");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

    }
}







//string path1 = @"C:\Users\Dmitry.Solodilov\Desktop\input.txt";
//string[] readEveryLine = new string[7];
//readEveryLine = File.ReadAllLines(path1);
//string sVx_first = readEveryLine[0];// начальная скорость по x
//string sVy_first = readEveryLine[1];// начальная скорость по y
//string sx_first = readEveryLine[2];// начальная позиция по x
//string sy_first = readEveryLine[3];// начальная позиция по y
//string sk = readEveryLine[4];// коэффициент сопротивления полету, по умолчанию 0
//string sm = readEveryLine[5];// масса тела
//string sdelta_t = readEveryLine[6];// временной интервал

//double Vx_first = Convert.ToDouble(sVx_first);
//double Vy_first = Convert.ToDouble(sVy_first);
//double x_first = Convert.ToDouble(sx_first);
//double y_first = Convert.ToDouble(sy_first);
//double k = Convert.ToDouble(sk);
//double m = Convert.ToDouble(sm);
//double delta_t = Convert.ToDouble(sdelta_t);
//double x;
//double y;
//double Vx;
//double Vy;

//string path2 = @"C:\Users\Dmitry.Solodilov\Desktop\output.txt";
//if (File.Exists(path2))
//    File.WriteAllText(path2, string.Empty);
//else Console.WriteLine("Не указан файл");


//File.AppendAllText(path2, x_first + "\t\t\t\t" + y_first + "\n");
//for (int i = 1; i < 1000; i++)
//{

//    x = x_first + delta_t * Vx_first;
//    Vx = Vx_first - delta_t * k * Vx_first / m;
//    x_first = x;
//    Vx_first = Vx;
//    y = y_first + delta_t * Vy_first;
//    Vy = Vy_first - delta_t * (g + k * Vy_first / m);
//    y_first = y;
//    Vy_first = Vy;
//    if (y < 0)
//    {
//        y = 0;
//        File.AppendAllText(path2, delta_t * i + "\t\t\t\t" + Math.Round(x, 3) + "\t\t\t\t" + Math.Round(y, 3) + "\n");
//        break;
//    }
//    File.AppendAllText(path2, delta_t * i + "\t\t\t\t" + Math.Round(x, 3) + "\t\t\t\t" + Math.Round(y, 3) + "\n");
//}
