using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.ConsoleUI.Domain
{
    public class Local
    {
        private readonly Dictionary<Direction, Local> _saidas = new();

        public string Nome { get; }
        public string Descricao { get; }
        public Monster? Monstro { get; private set; }
        public IReadOnlyDictionary<Direction, Local> Saidas => _saidas;

        public Local(string nome, string descricao)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do local não pode ser vazio", nameof(Local));
            }
            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("A descrição do local não pode ser vazio", nameof(descricao));
            }

            Nome = nome;
            Descricao = descricao;
        }

        public void Conectar(Direction direction, Local destino)
        {
            ArgumentNullException.ThrowIfNull(destino);
            if (ReferenceEquals(destino, this))
            {
                throw new ArgumentException("Um local não pode ser ligado a ele mesmo.", nameof(destino));
            }
            _saidas[direction] = destino;
            destino._saidas[direction.Oposta()] = this;
        }

        public Local? ObterSaida(Direction direction)
        {
            return _saidas.TryGetValue(direction, out Local? destino) ? destino : null;
        }

        public void DefinirMonstro(Monster monstro)
        {
            ArgumentNullException.ThrowIfNull(monstro);
            Monstro = monstro;
        }

        public void RemoverMonstro()
        {
            Monstro = null;
        }
    }
}