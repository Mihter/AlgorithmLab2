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
    internal class Fractal
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

            //TODO
        }
    }
}
