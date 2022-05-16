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
using Microsoft.Win32;
using System.IO;
using System.Xml;

namespace WpfApp2
{
    //public partial class Window1 : Window
    //{

    //    private void Button_Click(object sender, RoutedEventArgs e)
    //    {
    //        Birds();
    //    }
    //    public Window1()
    //    {
    //        InitializeComponent();
    //    }


    //    public async void Birds()
    //    {

    //        Canvas.SetLeft(Bird, 200);
    //        Canvas.SetTop(Bird, 220);
    //        int i = 0;
    //        while (i < 400)
    //        {
    //            await Task.Delay(1000);
    //            Canvas.SetLeft(Bird, i);
    //            Canvas.SetTop(Bird, i / 2);
    //            i += 20;

    //        }
    //    }
    //}


    public partial class MainWindow : Window
    {
        bool verification = false;
        bool verification_pass = false;
        double[] arrx = new double[1000];
        double[] arry = new double[1000];
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string StSpeedtext = StSpeed.Text;
            string Angletext = Angle.Text;
            string StPosextext = StPosex.Text;
            string StPoseytext = StPosey.Text;
            string Masstext = Mass.Text;
            if ((StPosextext.Length == 0) || (StPosextext == null))
                StPosextext = "0";
            if ((StPoseytext.Length == 0) || (StPoseytext == null))
                StPoseytext = "0";
            if ((Masstext.Length == 0) || (Masstext == null))
                Masstext = "1";

            if (verification)
            {
                if ((StSpeedtext != "") && (Angletext != ""))
                {
                    double stSpeed = Convert.ToDouble(StSpeedtext);
                    double angle = Convert.ToDouble(Angletext);
                    double Posex = Convert.ToDouble(StPosextext);
                    double Posey = Convert.ToDouble(StPoseytext);
                    double mass = Convert.ToDouble(Masstext);
                    const double g = 9.8;
                    angle *= Math.PI / 180;
                    double stSpeedx = stSpeed * Math.Cos(angle);
                    double stSpeedy = stSpeed * Math.Sin(angle);
                    double x;
                    double y;
                    double Speedx;
                    double Speedy;
                    double delta_t = 0.1;
                    double k = 0.1;
                    //double[] arrx = new double[1000];
                    //double[] arry = new double[1000];
                    arrx[0] = Posex;
                    arry[0] = Posey;
                    for (int i = 1; i < 1000; i++)
                    {

                        x = Posex + delta_t * stSpeedx;
                        Speedx = stSpeedx - delta_t * k * stSpeedx / mass;
                        Posex = x;
                        stSpeedx = Speedx;
                        arrx[i] = Math.Round(x, 3);
                        y = Posey + delta_t * stSpeedy;
                        Speedy = stSpeedy - delta_t * (g + k * stSpeedy / mass);
                        Posey = y;
                        stSpeedy = Speedy;
                        arry[i] = Math.Round(y, 3);
                        if (y < 0)
                        {
                            y = 0;
                            MessageBox.Show("Начальная скорость: " + StSpeedtext + "   " + "Угол: " + Angletext + "   " + "Начальная позиция по x: " + StPosextext + "   " + "Начальная позиция по y: " + StPoseytext + "   " + "Масса: " + Masstext);
                            MessageBox.Show("Конечная позиция по x: " + Math.Round(x * 0.8, 3) + "   " + "Конечная позиция по y: " + Math.Round(380 - y * 0.8, 3) + "   " + "Момент времени: " + Math.Round(delta_t * i, 3));
                            //for (int j = 0; j < i; j++)
                            //{
                            //    MessageBox.Show("Позиция по x: " + arrx[j] + "   " + "Позиция по y: " + arry[j]);
                            //}
                            //Window1 Window1 = new Window1();
                            //Window1.Show();
                            Birds();
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter your text!");
                }
            }
            else
            {
                MessageBox.Show("Pass the verification");
            }
            
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (verification_pass == false)
            {
                Window1 authorizationWindow = new Window1();
                if (authorizationWindow.ShowDialog() == true)
                {
                    if (authorizationWindow.Password == "123")
                    {
                        MessageBox.Show("Authorization was successful");
                        verification = true;
                        verification_pass = true;
                    }
                    else
                        MessageBox.Show("Wrong password");
                }
                else
                {
                    MessageBox.Show("Authorization failed");
                }
            }
            else
            {
                MessageBox.Show("Restart the game");
            }


        }

        private void Password_Click(object sender, RoutedEventArgs e)
        {
          
                Window2 passwordWindow = new Window2();
                passwordWindow.ShowDialog();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {

            Window3 menuWindow = new Window3();
            menuWindow.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public MainWindow()
        {
            InitializeComponent();
        }
      
        public async void Birds()
        {
            string StPosextext = StPosex.Text;
            string StPoseytext = StPosey.Text;
            if ((StPosextext.Length == 0) || (StPosextext == null))
                StPosextext = "0";
            if ((StPoseytext.Length == 0) || (StPoseytext == null))
                StPoseytext = "0";
            double Posex = Convert.ToDouble(StPosextext);
            double Posey = Convert.ToDouble(StPoseytext);
            double[] stonex = new double[1000];
            double[] stoney = new double[1000];
            int sx = 715;
            int sy = 365;
            for (int k = 0; k < 50; k++)
            {
                sx += 1;
                sy += 1;
                stonex[k] = sx;
                stoney[k] = sy;
            }

            //// Configure save file dialog box
            //var dialog = new SaveFileDialog();
            //dialog.FileName = "Document"; // Default file name
            //dialog.DefaultExt = ".txt"; // Default file extension
            //dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            //// Show save file dialog box
            //bool? result = dialog.ShowDialog();

            //// Process save file dialog box results
            //if (result == true)
            //{
            //    // Save document
            //    string filename = dialog.FileName;
            //}

            Canvas.SetLeft(Bird, Posex);
            Canvas.SetTop(Bird, 380 - Posey);
            int i = 0;
            int j = 780;
            await Task.Delay(1000);
            while (i < 1000 || j > 0)
            {
                double canvasx = arrx[i] * 0.8;
                double canvasy = 380 - arry[i] * 0.8;
                await Task.Delay(10);
                Canvas.SetLeft(Bird, canvasx);
                Canvas.SetTop(Bird, canvasy);
                i += 1;
                j -= 1;
                bool target_hit = false;
                //MessageBox.Show(Math.Round(canvasx, 0) + "   " + Math.Round(canvasy, 0));

                for (int k = 0; k < 50; k++)
                {
                    for (int l = 0; l < 50; l++)
                    {

                        if ((Math.Round(canvasx, 0) == stonex[k]) && (Math.Round(canvasy, 0) == stoney[l]))
                        {
                            MessageBox.Show("Цель поражена");
                            target_hit = true;
                            break;
                        }
                    }
                }
                if (target_hit)
                {
                    Canvas.SetLeft(Bird, Posex);
                    Canvas.SetTop(Bird, 380 - Posey);
                    break;
                }
            }
            //MessageBox.Show("Конечная позиция по x: " + Math.Round(canvasx, 3) + "   " + "Конечная позиция по y: " + Math.Round(y, 3) + "   " + "Момент времени: " + Math.Round(delta_t * i, 3));
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
//for (int i = 0; i < t_c; i++)
//{
//    value_x = stSpeed * t / t_c * i * Math.Cos(angle);
//    value_y = stSpeed * t / t_c * i * Math.Sin(angle) - g * Math.Pow(t / t_c * i, 2) / 2;
//    Coord_x[i] = value_x;
//    Coord_y[i] = value_y;
//}
//value_x = stSpeed * t * Math.Cos(angle);
//value_y = stSpeed * t * Math.Sin(angle) - g * Math.Pow(t, 2) / 2;
//if (value_y < 0) value_y = 0;


//MessageBox.Show("Начальная скорость: " + StSpeedtext + "   " + "Угол: " + Angletext);
//MessageBox.Show("Конечная позиция по x: " + Math.Round(value_x, 3) + "   " + "Конечная позиция по y: " + Math.Round(value_y, 3) + "   " + "Момент времени: " + Math.Round(t, 3));
//double multipliation = stPosex * stSpeed;
//string multipliation_text = Convert.ToString(multipliation);
//MessageBox.Show(multipliation_text);
//double.TryParse(multipliation_text, out double b);

//double t = 2 * stSpeed * Math.Sin(angle) / g;
//double t_c_double = Math.Round(t) * 10;
//int t_c = Convert.ToInt32(t_c_double);
//if (t < 0.5)
//t_c = 10;
//double[] Coord_y = new double[t_c];
//double[] Coord_x = new double[t_c];