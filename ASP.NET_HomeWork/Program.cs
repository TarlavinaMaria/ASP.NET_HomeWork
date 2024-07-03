using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_HomeWork.Cocktail;
using ASP.NET_HomeWork.GameCharacters;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace ASP.NET_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Настройка Autofac
            //var containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<CocktailRepository>().As<ICocktailRepository>().SingleInstance();
            //containerBuilder.RegisterType<CocktailManager>().AsSelf().SingleInstance();

            //var container = containerBuilder.Build();

            //// Получение экземпляра CocktailManager из контейнера Autofac
            //var cocktailManager = container.Resolve<CocktailManager>();

            //// Отображение информации о коктейлях на консоли
            //cocktailManager.DisplayCocktails();

            //// Экспорт информации о коктейлях в файл
            //cocktailManager.ExportToFile();

            //Console.ReadLine();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<GameCharacterModule>();
            var container = containerBuilder.Build();

            var footman = container.ResolveNamed<GameCharacter>("Footman");
            var spearman = container.ResolveNamed<GameCharacter>("Spearman");
            var archer = container.ResolveNamed<GameCharacter>("Archer");

            footman.Attack(spearman);
            spearman.Attack(archer);


            archer.DisplayInfo();
            footman.DisplayInfo();
            spearman.DisplayInfo();

            footman.SaveToFile("characters.txt");
            spearman.SaveToFile("characters.txt");
            archer.SaveToFile("characters.txt");


        }
    }
}
