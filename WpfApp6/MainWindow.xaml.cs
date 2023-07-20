using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Shape shape;
        Random random = new Random();
        private void Drawing_function(int N, int x, int y, double a)
        {
            if (N == 0)
            {
                return;
            }
            else
            {
                shape = new System.Windows.Shapes.Rectangle();

                shape.Stroke = System.Windows.Media.Brushes.Black;

                x = 0;
                x += random.Next(10, 100);
                y = x;

                shape.Width = x;
                shape.Height = y;

                MainCanvas.Children.Add(shape);
                Canvas.SetLeft(shape, 390 + 220 * Math.Cos(a) - x / 2);
                Canvas.SetTop(shape, 345 + 220 * Math.Sin(a) - y / 2);

                a += Math.PI / 15;
                N--;

                //   r++;
                /*     if (r == 30)
                     {
                         r = 0;
                         x += 15;
                         y += 15;
                     }*/

                Drawing_function(N, x, y, a);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainCanvas.Children.Clear();
                int n;
                if (int.TryParse(NTextBox.Text, out n) && n >= 0)
                    Drawing_function(n, 10, 10, Math.PI / 6);
                else MessageBox.Show("Значение некорректно! Попробуйте еще раз!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
