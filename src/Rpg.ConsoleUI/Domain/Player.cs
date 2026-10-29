using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.ConsoleUI.Domain
{
    public class Player : Character
    {
        public int Ouro { get; private set; }
        public Inventory Iventario  { get; } = new();

        public Player(string nome, int vidaMaxima, int ataque, int defesa, int ouro = 0) : base(nome, vidaMaxima, ataque, defesa) 
        {
            if(ouro < 0)
            {
                throw new ArgumentException(nameof(ouro),"Ouro não podemser negativo.");
            }

            Ouro = ouro;
        }

        public void GanharOuro(int quantidade)
        {
            if(quantidade > 0)
            {
                Ouro += quantidade;
            }
        }

        public bool GastarOuro(int quantidade)
        {
            if(quantidade <= 0 || quantidade > Ouro)
            {
                return false;
            }
            Ouro -= quantidade;
            return true;
        }
    }
}