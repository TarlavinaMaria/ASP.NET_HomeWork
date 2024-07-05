using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    internal class Triangle : GeometricShape
    {
        private double _side;
        private double _height;

        public Triangle(double side, double height)
        {
            _side = side;
            _height = height;
        }

        public override string GetName()
        {
            return "Треугольник";
        }

        public override string Render()
        {
            string output = GetName() + Environment.NewLine;
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _side - y; x++)
                {
                    output += " ";
                }
                for (int x = 0; x < 2 * y + 1; x++)
                {
                    output += "*";
                }
                output += Environment.NewLine;
            }
            return output;
        }
        public override string RenderConsole()
        {
            string output = "Рисование " + GetName() + Environment.NewLine;
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _side - y; x++)
                {
                    output += " ";
                }
                for (int x = 0; x < 2 * y + 1; x++)
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
