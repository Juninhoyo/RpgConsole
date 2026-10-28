using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.ConsoleUI.Domain
{
    public class Monster : Character 
    {
        public int RecompensaOuro { get; }
        public int RecompensaXp { get; }

        public Monster(string nome, int vidaMaxima, int ataque, int defesa, int recompensaOuro, int recompensaXp) : base(nome, vidaMaxima, ataque, defesa)
        {
            if(RecompensaOuro < 0 || RecompensaXp < 0)
            {
                throw new ArgumentException(nameof(RecompensaOuro),"As recompensas não podem ser negativas");
            }
            RecompensaOuro = recompensaOuro;
            RecompensaXp = recompensaXp;
        }
    }
}