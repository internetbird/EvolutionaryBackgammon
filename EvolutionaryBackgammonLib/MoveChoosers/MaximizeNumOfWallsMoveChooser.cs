using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib.MoveChoosers
{
    class MaximizeNumOfWallsMoveChooser : IMoveChooser
    {
        public GameMove ChooseMove(Board board, List<GameMove> moveOptions)
        {
            return moveOptions.Where(move => move.ToCell.InsideBoardBounds())
                             .FirstOrDefault(moveOption =>
                                             board[moveOption.FromCell].Color == board[moveOption.ToCell].Color);
        }
    }
}
