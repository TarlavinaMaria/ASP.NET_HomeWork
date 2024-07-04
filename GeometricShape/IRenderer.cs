using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricShape
{
    internal interface IRenderer
    {
        void RenderToScreen(string text);
        void RenderToFile(string text);
    }
}
