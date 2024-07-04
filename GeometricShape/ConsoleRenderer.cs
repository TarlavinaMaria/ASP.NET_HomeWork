using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShape
{
    internal interface ConsoleRenderer : IRenderer
    {
        public void RenderToScreen(string text)
        {
            Console.WriteLine(text);
        }

        public void RenderToFile(string text)
        {
            using (StreamWriter writer = new StreamWriter("output.txt", true))
            {
                writer.WriteLine(text);
            }
        }
    }
}
