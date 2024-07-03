using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_HomeWork.Cocktail
{
    internal class CocktailRepository : ICocktailRepository
    {
        public IEnumerable<CocktailModel> GetCocktails()
        {
            // Получение данных о коктейлях из источника данных (например, базы данных, API и т.д.)
            return new List<CocktailModel>
        {
            new CocktailModel { Name = "Маргарита", Ingredients = "Текила, Трипл Сек, Лимонный сок" },
            new CocktailModel { Name = "Мохито", Ingredients = "Ром, Лимонный сок, Мята, Содовая" },
            new CocktailModel { Name = "Олд Фэшн", Ingredients = "Бурбон, Биттеры, Сахар, Долька апельсина" }
        };
        }
    }
}
