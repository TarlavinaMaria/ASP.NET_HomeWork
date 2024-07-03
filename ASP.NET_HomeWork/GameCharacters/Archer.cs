using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace ASP.NET_HomeWork.GameCharacters
{
    internal class Archer : GameCharacter
    {
        public Archer(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
