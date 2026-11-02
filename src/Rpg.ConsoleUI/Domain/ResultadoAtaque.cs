using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.ConsoleUI.Domain
{
    public record class ResultadoAtaque(bool Acertou, bool Critico, int Dano)
    {
        
    }
}