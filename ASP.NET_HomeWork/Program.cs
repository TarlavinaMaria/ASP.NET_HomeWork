using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_HomeWork.Cocktail;
using ASP.NET_HomeWork.GameCharacters;
using ASP.NET_HomeWork.Geometric;
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

            //Console.WriteLine("--------------------------------------------------");

            //var containerBuilderCharacter = new ContainerBuilder();
            //containerBuilderCharacter.RegisterModule<GameCharacterModule>();
            //var containerCharacter = containerBuilderCharacter.Build();

            //var footman = containerCharacter.ResolveNamed<GameCharacter>("Footman");
            //var spearman = containerCharacter.ResolveNamed<GameCharacter>("Spearman");
            //var archer = containerCharacter.ResolveNamed<GameCharacter>("Archer");

            //footman.Attack(spearman);
            //spearman.Attack(archer);


            //archer.DisplayInfo();
            //footman.DisplayInfo();
            //spearman.DisplayInfo();

            //footman.SaveToFile("characters.txt");
            //spearman.SaveToFile("characters.txt");
            //archer.SaveToFile("characters.txt");

            //Console.WriteLine("--------------------------------------------------");

            // Настройка Autofac
            var builder = new ContainerBuilder();
            builder.RegisterType<Circle>().AsSelf();
            builder.RegisterType<Rectangle>().AsSelf();
            builder.RegisterType<ShapeInfoService>().As<IShapeInfoService>().SingleInstance();
            var container = builder.Build();

            // Получение экземпляров геометрических фигур и сервиса
            var circle = container.Resolve<Circle>(new NamedParameter("radius", 5.0));
            var rectangle = container.Resolve<Rectangle>(new NamedParameter("width", 4.0), new NamedParameter("height", 3.0));
            var shapeInfoService = container.Resolve<IShapeInfoService>();

            // Отображение информации о фигурах на экране
            shapeInfoService.DisplayShapeInfo(circle);
            shapeInfoService.DisplayShapeInfo(rectangle);

            // Запись информации о фигурах в файл
            shapeInfoService.WriteShapeInfoToFile(circle, "circle_info.txt");
            shapeInfoService.WriteShapeInfoToFile(rectangle, "rectangle_info.txt");

        }
    }
}
