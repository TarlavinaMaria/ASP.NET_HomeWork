using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_HomeWork.Geometric
{
    internal interface IShapeInfoService
    {
        void DisplayShapeInfo(IGeometricShape shape);
        void WriteShapeInfoToFile(IGeometricShape shape, string filePath);
    }
}
