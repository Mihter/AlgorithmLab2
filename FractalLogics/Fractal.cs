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
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlgorithmLab2.FractalLogics
{
    internal class Fractal: Canvas
    {
        public void DrawPifagorTree(System.Windows.Point p1, System.Windows.Point p2, System.Windows.Point p3, System.Windows.Point p4, int depth)
        {
            if (depth == 0)
            {
                // Отрисовываем квадрат
                var polygon = new Polygon();
                polygon.Points.Add(p1);
                polygon.Points.Add(p2);
                polygon.Points.Add(p3);
                polygon.Points.Add(p4);
                polygon.Stroke = Brushes.DarkGreen;
                polygon.StrokeThickness = 1;
                this.Children.Add(polygon);
            }
            else
            {
                //TODO просчтитываем поворот на 45% текущего отрезка
                var cos45 = Math.Sqrt(2)/2;
                var p1Rotate = new System.Windows.Point(p1.X - (p3.X - p1.X) / 2 /*+ (p3.Y - p1.Y) / 2*/, p1.Y - (p3.Y - p1.Y) / 2);
                var p2test = new System.Windows.Point(p1.X - (p3.X - p1.X) / 2 + (p3.Y - p1.Y) / 2, 300);
                var p3Rotate = new System.Windows.Point((p1.X + p2.X) / 2 + (p2.Y - p1.Y) / 2, p1.Y - (p3.Y - p1.Y)/2 );
                var p4test = p1;
                
    internal class PifagorTree
    {
        public static void Draw(int depth)//800x800 400middle
        {
            double multiplier = 1;

            for (double i = 2, multiplierGrowth = 1; i <= depth; i++)
            {
                multiplierGrowth /= 2;
                multiplier += multiplierGrowth;
            }
            int plainSize = Convert.ToInt32(800/(2*multiplier-1));

            Square square = new Square()
            {
                bottomLeft = new Point(400 - plainSize / 2, 0),
                bottomRight = new Point(400 + plainSize / 2, 0),
                topLeft = new Point(400 - plainSize / 2, plainSize),
                topRight = new Point(400 + plainSize / 2, plainSize)
            };
            BuildLayer(square, depth);

        }

        public static void BuildLayer(Square square, int depth)
        {

            if (depth == 0)
                return;//TODO
                topLeft = new Point()
                {
                    X = square.topRight.X + halfDiagonal.X,
                    Y = square.topRight.Y + halfDiagonal.Y
                },
                topRight = new Point()
                {
                    X = square.topRight.X - halfDiagonal.X + halfDiagonal.X,
                    Y = square.topRight.Y + halfDiagonal.Y + halfDiagonal.Y
                },
            };

            //дровка
            Square.DrawSquare(squareLeft);
            Square.DrawSquare(squareRight);

            BuildLayer(squareLeft, depth - 1);
            BuildLayer(squareRight, depth - 1);

        }
        
    }
    class Square
    {
        public required Point topLeft;
        public required Point bottomLeft;
        public required Point topRight;
        public required Point bottomRight;
        public static void DrawSquare(Square square)
        {

                DrawPifagorTree(p1Rotate, p2test,p3Rotate, p4test, depth - 1);
                DrawPifagorTree(p1, p2, p3, p4, depth - 1);
            }
        }

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
                var mid1 = new System.Windows.Point((p1.X + p2.X) / 2 + (p2.Y - p1.Y) / 2, (p1.Y + p2.Y) / 2 - (p2.X - p1.X) / 2);

                DrawLeviCurve(p1, mid1, depth - 1);
                DrawLeviCurve(mid1, p2, depth - 1);
            }
        }

        public void Minkowski(System.Windows.Point p1, System.Windows.Point p2, int depth)
        {
            if (depth == 0)
            {
                // Отрисовываем линию

                var polygon = new Polygon();
                polygon.Points.Add(p1);
                polygon.Points.Add(p2);
                polygon.Stroke = Brushes.Red;
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