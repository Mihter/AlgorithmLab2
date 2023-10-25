using AlgorithmLab2.FractalLogics;
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
using System.Xml.Linq;

namespace AlgorithmLab2
{
    /// <summary>
    /// Логика взаимодействия для FractalMenu.xaml
    /// </summary>
    public partial class FractalMenu : Page
    {
        static int _depth;
        static string _name;

        public FractalMenu(int depth)
        {
            _depth = depth;
            InitializeComponent();
        }

        public void InitializeFractal(string name)
        {
            Fractal fractal = new Fractal();
            switch (name)
            {
                case "pifagor_tree":
                    fractal.DrawPifagorTree(new Point(400, 500), new Point(600, 500), new Point(600, 700), new Point(400, 700), _depth);
                    Content = fractal;
                    break;
                case "levi_curve":
                    fractal.DrawLeviCurve(new Point(300, 450), new Point(700, 450), _depth);
                    Content = fractal;
                    break;
                case "minkovscogo_curve":
                    fractal.Minkowski(new Point(250,250), new Point(750,250), _depth);
                    Content = fractal;
                    break;
            }
        }
        private void PifagorTree_Click(object sender, RoutedEventArgs e)
        {
            _name = "pifagor_tree";
            InitializeFractal(_name);
        }

        private void LeviCurve_Click(object sender, RoutedEventArgs e)
        {
            _name = "levi_curve";
            InitializeFractal(_name);
        }

        private void MinkovscogoCurve_Click(object sender, RoutedEventArgs e)
        {
            _name = "minkovscogo_curve";
            InitializeFractal(_name);
        }
    }
}
