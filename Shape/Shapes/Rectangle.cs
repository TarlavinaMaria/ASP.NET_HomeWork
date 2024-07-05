using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    internal class Rectangle: GeometricShape
    {
        private double _width;
        private double _height;

        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public override string GetName()
        {
            return "Прямоугольник";
        }

        public override string Render()
        {
            string output = "Рисование " + GetName() + Environment.NewLine;
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    output += "*";
                }
                output += Environment.NewLine;
            }
            Console.Write(output);
            return output;
        }

    }
}
