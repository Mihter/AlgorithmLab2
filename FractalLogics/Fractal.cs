using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;


namespace AlgorithmLab2.FractalLogics
{
    internal class Fractal: Canvas
    {
        public void DrawLeviCurve(System.Windows.Point p1, System.Windows.Point p2, int depth)
        {
            if (depth == 0)
            {
                // Отрисовываем отрезок
                var polygon = new Polygon();
                polygon.Points.Add(p1);
                polygon.Points.Add(p2);
                polygon.Stroke = Brushes.DarkGreen;
                polygon.StrokeThickness = 1;
                this.Children.Add(polygon);
            }
            else
            {
                // просчтитываем поворот на 45% текущего отрезка
                var mid1 = new System.Windows.Point((p1.X + p2.X) / 2 + (p2.Y - p1.Y) / 2, (p1.Y + p2.Y) / 2  - (p2.X - p1.X) / 2);
                
                DrawLeviCurve(p1, mid1, depth - 1);
                DrawLeviCurve(mid1, p2, depth - 1);
                
            }
        }
    }
}
