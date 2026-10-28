using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.ConsoleUI.Domain
{
    public class Player
    {
        public string Nome { get; } = string.Empty;
        public int Vida { get; private set; }
        public int VidaMaxima { get; }
        public int Ataque { get; }
        public int Defesa { get; }
        public int Ouro { get; private set; }

        public bool EstaVivo => Vida > 0;

        public Player(string nome, int vidamaxima, int ataque, int defesa, int ouro = 0)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome não pode ser vazio", nameof(nome));
            }
            if(VidaMaxima < 0)
            {
                throw new ArgumentException(nameof(VidaMaxima),"Vida máxima deve ser maior que zero");
            }
            if(ataque < 0 || defesa < 0 || ouro < 0)
            {
                throw new ArgumentException(nameof(ataque),"Ataque, defesa e ouro não podem ser negativos");
            }
            Vida = 100;

            Nome = nome;
            VidaMaxima = vidamaxima;
            Ataque = ataque;
            Defesa = defesa;
            Ouro = ouro;
        }

        public void ReceberDano(int forcaDoAtaque)
        {
            int dano = Math.Max(0, forcaDoAtaque - Defesa);
            Vida = Math.Max(0, Vida - dano);
        }

        public void Curar(int quantidade)
        {
            if(quantidade <= 0)
            {
                return;
            }
            Vida = Math.Min(VidaMaxima, Vida + quantidade);
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