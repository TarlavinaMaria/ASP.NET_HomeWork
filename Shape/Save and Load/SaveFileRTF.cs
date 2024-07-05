using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape.Save_and_Load
{
    public class SaveFileRTF
    {
        public static void SaveShape(GeometricShape shape)
        {
            string shapeName = shape.GetName();
            string shapeOutput = shape.Render();
            string filePath = $"{shapeName}.rtf";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(@"{\rtf1\ansi\deff0{\fonttbl{\f0\fnil\fcharset204 Arial;}}");
                writer.WriteLine(@"{\colortbl;\red255\green255\blue255;\red0\green0\blue0;}");
                writer.WriteLine(@"\viewkind4\uc1\pard\cf1\f0\fs24 " + shapeOutput + @"\par}");
            }
            Console.WriteLine($"Сохранено в файле: {filePath}");
        }

        public static void LoadShape(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine(fileContent);
        }
    }
}
