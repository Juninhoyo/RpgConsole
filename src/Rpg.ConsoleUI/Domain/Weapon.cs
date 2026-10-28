using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.ConsoleUI.Domain
{
    public class Weapon : Item
    {
        public int BonusAtaque { get; }

        public Weapon(string nome,int preco,int bonusAtaque) : base(nome, preco)
        {
            if(preco < 0)
            {
                throw new ArgumentException((nameof(bonusAtaque)),"O bônus de ataque não pode ser negativo.");
            }
            BonusAtaque = bonusAtaque;
        }
    }
}