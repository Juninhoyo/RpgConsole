using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.ConsoleUI.Domain
{
    public abstract class Character
    {
        public string Nome { get; }
        public int Vida { get; private set; }
        public int VidaMaxima { get; }
        public int Ataque { get; }
        public int Defesa { get; }

        public bool EstaVivo => Vida > 0;

        public Character(string nome, int vidaMaxima, int ataque, int defesa)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome não pode ser vazio.", nameof(nome));
            }
            if(vidaMaxima <= 0)
            {
                throw new ArgumentException(nameof(vidaMaxima),"Vida máxima deve ser maior que zero.");
            }
            if(ataque < 0 || defesa < 0)
            {
                throw new ArgumentException(nameof(ataque),"Ataque e defesa não podem ser negativos.");
            }

            Nome = nome;
            VidaMaxima = vidaMaxima;
            Vida = vidaMaxima;
            Ataque = ataque;
            Defesa = defesa;
        }
        public int ReceberDano(int forcaDoAtaque)
        {
            int dano = Math.Max(0, forcaDoAtaque - Defesa);
            int VidaAntes = Vida;
            Vida = Math.Max(0, Vida - dano);
            return VidaAntes - Vida;
        }

        public int Curar(int quantidade)
        {
            if(quantidade <= 0)
            {
                return 0;
            }
            int VidaAntes = Vida;
            Vida = Math.Min(VidaMaxima, Vida + quantidade);
            return Vida - VidaAntes;
        }

        public int Atacar(Character alvo)
        {
            ArgumentNullException.ThrowIfNull(alvo);
            return alvo.ReceberDano(Ataque);
        }
    }
}