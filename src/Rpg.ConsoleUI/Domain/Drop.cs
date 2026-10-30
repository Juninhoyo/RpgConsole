using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.ConsoleUI.Domain
{
    public class Drop
    {
        public Item Item { get; }
        public Double Chance { get; }

        public Drop(Item item, double chance)
        {
            ArgumentNullException.ThrowIfNull(item);

            if (chance is < 0 or > 1)
            {
                throw new ArgumentException(nameof(chance),"A chance deve estar entre 0 e 1.");
            }

            Item = item;
            Chance = chance;
        }
        
        public bool Dropou(double sorteio) => sorteio < Chance;
    }
}