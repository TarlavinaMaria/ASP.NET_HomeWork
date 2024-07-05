using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public abstract class GeometricShape
    {
        public abstract string GetName();
        public abstract string Render();
        public abstract string RenderConsole();
    }
}
