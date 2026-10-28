using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.ConsoleUI.Domain
{
    public class Potion : Item
    {
        public int Cura { get; }

        public Potion(string nome, int preco, int cura) : base(nome, preco)
        {
            if(cura <= 0)
            {
                throw new ArgumentException(nameof(cura),"A cura deve ser maior que zero");
            }
            Cura = cura;
        }

        public void UsarCura(Character alvo)
        {
            alvo.Curar(Cura);
        }
    }
}