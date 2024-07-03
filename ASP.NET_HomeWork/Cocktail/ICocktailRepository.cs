using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace ASP.NET_HomeWork.Cocktail
{
    internal interface ICocktailRepository
    {
        IEnumerable<CocktailModel> GetCocktails();
    }
}
