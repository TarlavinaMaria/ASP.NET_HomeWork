using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;

namespace ASP.NET_HomeWork.GameCharacters
{
    internal class GameCharacterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Infantryman>()
             .Named<GameCharacter>("Footman")
             .WithParameter("name", "Footman")
             .WithParameter("health", 100)
             .WithParameter("damage", 20);

            builder.RegisterType<Spearman>()
                .Named<GameCharacter>("Spearman")
                .WithParameter("name", "Spearman")
                .WithParameter("health", 120)
                .WithParameter("damage", 25);

            builder.RegisterType<Archer>()
                .Named<GameCharacter>("Archer")
                .WithParameter("name", "Archer")
                .WithParameter("health", 80)
                .WithParameter("damage", 30);
        }
    }
}
