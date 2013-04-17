using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    public static class Extesions
    {
        /// <summary>
        /// To the stone color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static Stone ToStone(this BoardCellColor color)
        {
            if (color == BoardCellColor.Empty) return Stone.NotSet;
            
            if (color == BoardCellColor.White) return Stone.White;

            return Stone.Black;

        }

        /// <summary>
        /// To the color of the player.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static PlayerColor ToPlayerColor(this BoardCellColor color)
        {
            if (color == BoardCellColor.Empty) return PlayerColor.NotSet;

            if (color == BoardCellColor.White) return PlayerColor.White;

            return PlayerColor.Black;

        }

        public static bool InsideBoardBounds(this int index)
        {
            return index >= 0 && index < Game.BoardSize;
        }
    }
}
