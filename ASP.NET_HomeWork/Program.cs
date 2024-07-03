using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_HomeWork.Cocktail;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace ASP.NET_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Настройка Autofac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<CocktailRepository>().As<ICocktailRepository>().SingleInstance();
            containerBuilder.RegisterType<CocktailManager>().AsSelf().SingleInstance();

            var container = containerBuilder.Build();

            // Получение экземпляра CocktailManager из контейнера Autofac
            var cocktailManager = container.Resolve<CocktailManager>();

            // Отображение информации о коктейлях на консоли
            cocktailManager.DisplayCocktails();

            // Экспорт информации о коктейлях в файл
            cocktailManager.ExportToFile();

            Console.ReadLine();
        }
    }
}
