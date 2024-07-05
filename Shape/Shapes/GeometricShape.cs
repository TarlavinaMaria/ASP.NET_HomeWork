using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    internal abstract class GeometricShape
    {
        public abstract string GetName();
        public abstract string Render();
    }
}
