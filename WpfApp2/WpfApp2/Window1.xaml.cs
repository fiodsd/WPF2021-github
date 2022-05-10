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


//namespace WpfApp2
//{
//    /// <summary>
//    /// Логика взаимодействия для MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {

//        public void Button_Click(object sender, RoutedEventArgs e)
//        {
//            Cord_x.Children.Clear();
//            Cord_y.Children.Clear();
//            string str_Velosity;
//            string str_Angle;
//            while (true)
//            {
//                str_Velosity = Convert.ToString(str_velosity.Text);
//                str_Angle = Convert.ToString(str_angle.Text);
//                if ((int.TryParse(str_velosity.Text, out int _Velosity)) && (int.TryParse(str_angle.Text, out int _Angle)
//                    ))
//                {
//                    MessageBox.Show("успешный ввод цифр");
//                    break;
//                }
//                else
//                {
//                    MessageBox.Show("Ошибка");
//                    return;
//                }
//            }



//            double num_Angle = Convert.ToDouble(str_Angle);
//            double num_Velosity = Convert.ToDouble(str_Velosity);
//            //    double time_tarvel = 2 * num_Velosity * Math.Sin(num_Angle)/9.8;
//            var mc = new Class1(num_Angle, num_Velosity);

//            mc.Time(str_Angle, str_Velosity);
//            mc.Fly(str_Angle, str_Velosity);
//            mc.Epsilon_Round(str_Angle, str_Velosity);


//            Cord_x.Children.Add(new TextBlock { Text = "Coord_x" });
//            Cord_y.Children.Add(new TextBlock { Text = "Coord_y" });
//            /*   for (int i = 0; i < mc.Timer.Count; ++i)
//               {
//                   Cord_x.Children.Add(new TextBlock { Text = Convert.ToString(mc.cord_x[i])});
//                   Cord_y.Children.Add(new TextBlock { Text = Convert.ToString(mc.cord_y[i]) });
//                   Cord_y.CanHorizontallyScroll = true;
//                   Cord_x.CanHorizontallyScroll = true;
//               }
//            */
//            Birds();



//        }

//        public MainWindow()
//        {

//            InitializeComponent();
//        }
//        public async void Birds()
//        {

//            Canvas.SetLeft(Bird, 200);
//            Canvas.SetTop(Bird, 220);
//            int i = 0;
//            while (i < 400)
//            {
//                await Task.Delay(1000);
//                Canvas.SetLeft(Bird, i);
//                Canvas.SetTop(Bird, i / 2);
//                i += 20;

//            }


//        }
//    }

//}





namespace WpfApp2
{
    public partial class Window1 : Window
    {


        public Window1()
        {
            InitializeComponent();
        }
        
    }
}


