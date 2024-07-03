using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace ASP.NET_HomeWork.GameCharacters
{
    internal class Spearman : GameCharacter
    {
        public Spearman(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
