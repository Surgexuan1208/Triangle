using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Triangle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void showinfo()
        {
            int i = 0;
            textarea.Clear();
            textarea.Text += "邊一\t邊二\t邊三\t結果\n";
            foreach (triangle t in triangles)
            {
                textarea.Text += $"{t.len1}\t{t.len2}\t{t.len3,-10}   {t.boolen}\n";
                i++;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            showinfo();
            
        }
        List<triangle> triangles = new List<triangle>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double[] lens = { 0d, 0d, 0d };
            if (double.TryParse(input1.Text, out lens[0]) && double.TryParse(input2.Text, out lens[1]) && double.TryParse(input3.Text, out lens[2]))
            {
                if (lens[0] < 1 || lens[1] < 1 || lens[2] < 1)
                {
                    MessageBox.Show("您輸入的三個邊長不能有0!\n請重新輸入!!", "輸入錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
                    grid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                }
                else
                {
                    judge(lens);
                }
            }
            else
            {
                MessageBox.Show("您輸入的三個邊長有誤!\n請重新輸入!!", "輸入錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
                grid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            showinfo();

        }
        void judge(double[] lens)
        {
            bool booler = false;
            if (lens[0] + lens[1] > lens[2] && lens[1] + lens[0] > lens[2] && lens[1] + lens[2] > lens[0])
            {
                presult.Content = "是三角形";
                grid.Background = new SolidColorBrush(Color.FromRgb(112, 219, 112));
                booler = true;
            }
            else
            {
                presult.Content = "不是三角形";
                grid.Background = new SolidColorBrush(Color.FromRgb(204, 0, 0));
            }
            triangles.Add(new triangle() { len1 = lens[0], len2 = lens[1], len3 = lens[2], boolen = booler });
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            triangles.Clear();
            textarea.Clear();
            showinfo();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            input1.Text = "";
            input2.Text = "";
            input3.Text = "";
            grid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            presult.Content = "";
        }
    }
}
