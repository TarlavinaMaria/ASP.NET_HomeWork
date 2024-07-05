using Shape.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание объектов геометрических фигур
            var circle = new Circle(5.0);
            var rectangle = new Rectangle(10.0, 5.0);
            var triangle = new Triangle(8.0, 6.0);

            // Создание рендерера и отображение фигур
            var shapeRenderer = new ShapeRenderer(circle);
            shapeRenderer.RenderShape();

            shapeRenderer = new ShapeRenderer(rectangle);
            shapeRenderer.RenderShape();

            shapeRenderer = new ShapeRenderer(triangle);
            shapeRenderer.RenderShape();
        }
    }
}
