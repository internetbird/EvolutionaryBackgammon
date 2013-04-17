using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib.MoveChoosers
{
    public class HitOpponentStonesMoveChooser : IMoveChooser
    {
        public GameMove ChooseMove(Board board, List<GameMove> moveOptions)
        {
            GameMove chooserMove = moveOptions.FirstOrDefault(move => move.ToCell.InsideBoardBounds() &&
                                                                      board[move.ToCell].Color != board[move.FromCell].Color &&
                                                                      board[move.ToCell].Stones.Count == 1);

            return chooserMove;
        }
    }
}
