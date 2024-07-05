using Shape.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    internal class ShapeRenderer
    {
        private readonly GeometricShape _shape;

        public ShapeRenderer(GeometricShape shape)
        {
            _shape = shape;
        }

        public void RenderShape()
        {
            //string shapeOutput = _shape.Render();
            ShapeFileStorage.SaveShape(_shape);
        }
    }
}
