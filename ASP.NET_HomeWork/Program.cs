using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_HomeWork.Cocktail;
using ASP.NET_HomeWork.Device;
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

            Console.WriteLine("--------------------------------------------------");

            // Настройка Autofac
            var containerBuilderCharacter = new ContainerBuilder();
            containerBuilderCharacter.RegisterModule<GameCharacterModule>();
            var containerCharacter = containerBuilderCharacter.Build();

            // Получение экземпляров армии
            var footman = containerCharacter.ResolveNamed<GameCharacter>("Footman");
            var spearman = containerCharacter.ResolveNamed<GameCharacter>("Spearman");
            var archer = containerCharacter.ResolveNamed<GameCharacter>("Archer");

            // атака армии
            footman.Attack(spearman);
            spearman.Attack(archer);

            // Отображение информации
            archer.DisplayInfo();
            footman.DisplayInfo();
            spearman.DisplayInfo();

            //// Запись информации о армии в файл
            footman.SaveToFile("characters.txt");
            spearman.SaveToFile("characters.txt");
            archer.SaveToFile("characters.txt");

            Console.WriteLine("--------------------------------------------------");

            // Настройка Autofac
            var builderShape = new ContainerBuilder();
            builderShape.RegisterType<Circle>().AsSelf();
            builderShape.RegisterType<Rectangle>().AsSelf();
            builderShape.RegisterType<ShapeInfoService>().As<IShapeInfoService>().SingleInstance();
            var containerShape = builderShape.Build();

            // Получение экземпляров геометрических фигур и сервиса
            var circle = containerShape.Resolve<Circle>(new NamedParameter("radius", 5.0));
            var rectangle = containerShape.Resolve<Rectangle>(new NamedParameter("width", 4.0), new NamedParameter("height", 3.0));
            var shapeInfoService = containerShape.Resolve<IShapeInfoService>();

            // Отображение информации о фигурах на экране
            shapeInfoService.DisplayShapeInfo(circle);
            shapeInfoService.DisplayShapeInfo(rectangle);

            // Запись информации о фигурах в файл
            shapeInfoService.WriteShapeInfoToFile(circle, "circle_info.txt");
            shapeInfoService.WriteShapeInfoToFile(rectangle, "rectangle_info.txt");

            Console.WriteLine("--------------------------------------------------");

            // Настройка Autofac
            var builderDevice = new ContainerBuilder();
            builderDevice.RegisterType<CoffeeMill>().As<IDeviceInfo>().SingleInstance();
            builderDevice.RegisterType<Mixer>().As<IDeviceInfo>().SingleInstance();
            builderDevice.RegisterType<Blender>().As<IDeviceInfo>().SingleInstance();
            builderDevice.RegisterType<DeviceInfoManager>().AsSelf().SingleInstance();

            // Получение экземпляров
            var containerDevice = builderDevice.Build();
            var deviceInfoManager = containerDevice.Resolve<DeviceInfoManager>();
            // Отображение информации
            deviceInfoManager.PrintDeviceInfo();
            // Запись информации 
            deviceInfoManager.WriteDeviceInfoToFile();
        }
    }
}

