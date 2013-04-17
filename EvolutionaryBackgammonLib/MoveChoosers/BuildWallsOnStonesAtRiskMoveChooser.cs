using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    class BuildWallsOnStonesAtRiskMoveChooser : IMoveChooser
    {
        public GameMove ChooseMove(Board board, List<GameMove> moveOptions)
        {

            return moveOptions.Where(move => move.ToCell.InsideBoardBounds())
                              .FirstOrDefault(moveOption => 
                                              board[moveOption.FromCell].Color == board[moveOption.ToCell].Color &&
                                              board[moveOption.ToCell].Stones.Count == 1);
        }
    }
}
