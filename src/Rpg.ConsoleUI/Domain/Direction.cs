using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg.ConsoleUI.Domain
{
    public enum Direction
    {
        Norte,
        Sul,
        Leste,
        Oeste
    }
    public static class DirectionExtensions
    {
        public static Direction Oposta(this Direction direction) => direction switch
        {
          Direction.Norte => Direction.Sul,
          Direction.Sul => Direction.Norte,
          Direction.Leste => Direction.Oeste,
          Direction.Oeste => Direction.Leste,
          _ => throw new ArgumentException(nameof(direction))  
        };
    }
}