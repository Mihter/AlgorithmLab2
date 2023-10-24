using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlgorithmLab2.FractalLogics
{
    internal class Fractal : Canvas
    {
        private static int currentDepth = 0;
        Square square = new Square()
        {
            topLeft = Point.Empty,
            bottomLeft = Point.Empty,
            bottomRight = Point.Empty,
            topRight = Point.Empty
        };
        public static void CalculateLayer(Square square, int depth)
        {
            if (depth == currentDepth)
                return;//TODO
            currentDepth++;


            Point halfDiagonal = new Point()//right up
            {
                X = (square.topLeft.X - square.bottomLeft.X) / 2 + (square.topRight.X - square.topLeft.X) / 2,
                Y = (square.topLeft.Y - square.bottomLeft.Y) / 2 + (square.topRight.Y - square.topLeft.Y) / 2
            };
            //левый 
            Square squareLeft = new Square() 
            {
                bottomLeft = square.topLeft,

                bottomRight = new Point()
                {
                    X = square.topLeft.X + halfDiagonal.X,
                    Y = square.topLeft.Y + halfDiagonal.Y
                },

                topLeft = new Point()
                {
                    X = square.topLeft.X - halfDiagonal.X,
                    Y = square.topLeft.Y + halfDiagonal.Y
                },

                topRight = new Point()
                {
                    X = square.topLeft.X - halfDiagonal.X + halfDiagonal.X,
                    Y = square.topLeft.Y + halfDiagonal.Y + halfDiagonal.Y
                },
            };

            //правый
            Square squareRight = new Square()
            {
                bottomRight = square.topRight,

                bottomLeft = new Point()
                {
                    X = square.topLeft.X + halfDiagonal.X,
                    Y = square.topLeft.Y + halfDiagonal.Y
                },

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

        }
        
    }
    class Square
    {
        public Point topLeft;
        public Point bottomLeft;
        public Point topRight;
        public Point bottomRight;
        public static void DrawSquare(Square square)
        {

            //TODO
        }
    }
}
