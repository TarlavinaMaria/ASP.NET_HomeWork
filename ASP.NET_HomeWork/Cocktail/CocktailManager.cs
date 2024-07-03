using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_HomeWork.Cocktail
{
    internal class CocktailManager
    {
        private readonly ICocktailRepository _cocktailRepository;

        public CocktailManager(ICocktailRepository cocktailRepository)
        {
            _cocktailRepository = cocktailRepository;
        }

        public void DisplayCocktails()
        {
            var cocktails = _cocktailRepository.GetCocktails();

            // Отображение информации о коктейлях на консоли
            Console.WriteLine("Коктейли:");
            foreach (var cocktail in cocktails)
            {
                Console.WriteLine($"{cocktail.Name}: {cocktail.Ingredients}");
            }
        }

        public void ExportToFile()
        {
            var cocktails = _cocktailRepository.GetCocktails();

            // Запись информации о коктейлях в файл
            var filePath = Path.Combine(Environment.CurrentDirectory, "коктейли.txt");
            File.WriteAllText(filePath, string.Join(Environment.NewLine, cocktails.Select(c => $"{c.Name}: {c.Ingredients}")));

            Console.WriteLine("Информация о коктейлях экспортирована в файл.");
            
        }
    }
}
