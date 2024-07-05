using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    internal class Circle : GeometricShape
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public override string GetName()
        {
            return "Круг";
        }

        public override string Render()
        {
            string output = "Рисование " + GetName() + Environment.NewLine;
            for (int y = 0; y <= 2 * _radius; y++)
            {
                for (int x = 0; x <= 2 * _radius; x++)
                {
                    if (Math.Sqrt(Math.Pow(x - _radius, 2) + Math.Pow(y - _radius, 2)) <= _radius)
                    {
                        output += "*";
                    }
                    else
                    {
                        output += " ";
                    }
                }
                output += Environment.NewLine;
            }
            Console.Write(output);
            return output;
        }
    }
}
