using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.ConsoleUI.Domain
{
    public abstract class Item
    {
        public string Nome { get; }
        public int Preco { get; }

        protected Item(string nome,int preco)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do item não pode ser vazio.",nameof(nome));
            }
            if(preco < 0)
            {
                throw new ArgumentException(nameof(preco),"O preço não pode ser negativo");
            }
            Nome = nome;
            Preco = preco;
        }
    }
}