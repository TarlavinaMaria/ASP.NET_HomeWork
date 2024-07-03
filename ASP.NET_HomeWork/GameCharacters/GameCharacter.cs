using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace ASP.NET_HomeWork.GameCharacters
{
    public abstract class GameCharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public virtual void Attack(GameCharacter target)
        {
            target.Health -= Damage;
            Console.WriteLine($"{Name} атакует {target.Name} и наносит {Damage} урона.");
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Health: {Health}, Damage: {Damage}");
        }

        public virtual void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine($"Name: {Name}, Health: {Health}, Damage: {Damage}");
            }
        }
    }
}
