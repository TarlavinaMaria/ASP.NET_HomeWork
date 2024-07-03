using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core.Registration;

namespace ASP.NET_HomeWork.Geometric
{
    internal interface IGeometricShape
    {
        string Name { get; }
        double CalculateArea();
        double CalculatePerimeter();
    }
}
