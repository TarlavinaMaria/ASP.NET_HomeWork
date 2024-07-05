using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;

namespace Shape.Save
{
    internal class FileTXT
    {
        public static void SaveShape(GeometricShape shape)
        {
            string shapeName = shape.GetName();
            string shapeOutput = shape.RenderConsole();
            string filePath = $"{shapeName}.txt";
            File.WriteAllText(filePath, shapeOutput);
            Console.WriteLine($"Сохранено в файле: {filePath}");
        }
        public static void SaveShapesList(IEnumerable<GeometricShape> shapes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var shape in shapes)
            {
                sb.Append(shape.Render());
                sb.Append(Environment.NewLine);
            }
            string filePath = "all_shapes.txt";
            File.WriteAllText(filePath, sb.ToString());
            Console.WriteLine($"Список фигур сохранен в файле: {filePath}");
        }
        public static void PrintFileContents(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine(fileContent);
        }
    }
}
