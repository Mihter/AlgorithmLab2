
/*using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace AlgorithmLab2.FractalLogics
{
    internal class MinkowskiCurve : Canvas
    {
        public void Minkowski(System.Windows.Point p1, System.Windows.Point p2, int depth)
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
                
                var b = new System.Windows.Point(p1.X + (p2.X - p1.X) * 1 / 4, p1.Y + (p2.Y - p1.Y) * 1 / 4);
                var e = new System.Windows.Point(p1.X + (p2.X - p1.X) * 2 / 4, p1.Y + (p2.Y - p1.Y) * 2 / 4);
                var h = new System.Windows.Point(p1.X + (p2.X - p1.X) * 3 / 4, p1.Y + (p2.Y - p1.Y) * 3 / 4);

                var cos90 = 0;
                var sin90 = -1;

                var c = new System.Windows.Point(b.X + (e.X - b.X) * cos90 - sin90 * (e.Y - b.Y), b.Y + (e.X - b.X) * sin90 + cos90 * (e.Y - b.Y));
                var d = new System.Windows.Point(c.X + (e.X - b.X), c.Y + (e.Y - b.Y));

                sin90 = 1;

                var f = new System.Windows.Point(e.X + (h.X - e.X) * cos90 - sin90 * (h.Y - e.Y), e.Y + (h.X - e.X) * sin90 + cos90 * (h.Y - e.Y));
                var g = new System.Windows.Point(f.X + (h.X - e.X), f.Y + (h.Y - e.Y));

                Minkowski(p1, b, depth - 1);
                Minkowski(b, c, depth - 1);
                Minkowski(c, d, depth - 1);
                Minkowski(d, e, depth - 1);
                Minkowski(e, f, depth - 1);
                Minkowski(f, g, depth - 1);
                Minkowski(g, h, depth - 1);
                Minkowski(h, p2, depth - 1);
            }   
        }
    }
}
*/