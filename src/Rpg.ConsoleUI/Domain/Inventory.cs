using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.ConsoleUI.Domain
{
    public class Inventory
    {
        private readonly List<Item> _itens = new();

        public IReadOnlyList<Item> Itens => _itens;
        public int Quantidade => _itens.Count;

        public void Adicionar(Item item)
        {
            ArgumentNullException.ThrowIfNull(item);
            _itens.Add(item);
        }

        public bool Remover(Item item)
        {
            return _itens.Remove(item);
        }

        public Potion? BuscarPocao()
        {
            foreach (Item item in _itens)
            {
                if(item is Potion p)
                {
                    return p;
                }
            }
            return null;
        }
    }
}