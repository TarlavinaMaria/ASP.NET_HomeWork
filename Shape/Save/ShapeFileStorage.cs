using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;

namespace Shape.Save
{
    internal class ShapeFileStorage
    {
        public static void SaveShape(GeometricShape shape)
        {
            string shapeName = shape.GetName();
            string shapeOutput = shape.Render();
            string filePath = $"{shapeName}.txt";
            File.WriteAllText(filePath, shapeOutput);
            Console.WriteLine($"Сохранено в файле: {filePath}");
        }
    }
}
