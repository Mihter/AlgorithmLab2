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

namespace AlgorithmLab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        private void FractalButton_Click(object sender, RoutedEventArgs e)
        {
            int depth;
            if (int.TryParse(depthTextBox.Text, out depth))
            {
                frame.Navigate(new FractalMenu(depth));
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное значение глубины.\nВведенно неверное значение глубины или вовсе отсутствует.");
            }
        }

        private void HoannoiButton_Click(object sender, RoutedEventArgs e)
        {
            int depth;
            if (int.TryParse(depthTextBox.Text, out depth))
            {
                frame.Navigate(new HannoiMenu(depth));
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное значение глубины.\nВведенно неверное значение глубины или вовсе отсутствует.");
            }
        }
    }
}
