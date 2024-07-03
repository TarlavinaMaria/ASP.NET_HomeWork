using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_HomeWork.Geometric
{
    internal class ShapeInfoService: IShapeInfoService
    {
        public void DisplayShapeInfo(IGeometricShape shape)
        {
            Console.WriteLine($"Название: {shape.Name}");
            Console.WriteLine($"Площадь: {shape.CalculateArea():F2}");
            Console.WriteLine($"Периметр: {shape.CalculatePerimeter():F2}");
            Console.WriteLine();
        }

        public void WriteShapeInfoToFile(IGeometricShape shape, string filePath)
        {
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Название: {shape.Name}");
                writer.WriteLine($"Площадь: {shape.CalculateArea():F2}");
                writer.WriteLine($"Периметр: {shape.CalculatePerimeter():F2}");
                writer.WriteLine();
            }
        }
    }
}
