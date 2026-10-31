using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.ConsoleUI
{
    public enum AcaoCombate
    {
        Atacar,
        BeberPocao,
        Fugir,
        VerInventario
    }
        
    public static class MenuCombate
    {
        public static AcaoCombate LerAcao()
        {
            while (true)
            {
                Console.WriteLine("1 - Atacar | 2 - Beber poção | 3 - Ver inventário | 4 - fugir");

                AcaoCombate? acao = Console.ReadLine() switch
                {
                    "1" => AcaoCombate.Atacar,
                    "2" => AcaoCombate.BeberPocao,
                    "3" => AcaoCombate.VerInventario,
                    "4" => AcaoCombate.Fugir,
                    _ => null
                };

                if (acao is not null)
                {
                    return acao.Value;
                }

                Console.WriteLine("Opção inválida.");
            }
        }
    }
}