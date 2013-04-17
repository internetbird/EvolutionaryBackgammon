using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib.MoveChoosers
{
    public class MinimizeNumberOfStepsMoveChooser : IMoveChooser
    {
        public GameMove ChooseMove(Board board, List<GameMove> moveOptions)
        {
            GameMove choosenMove;

            PlayerColor playerColor = board[moveOptions.First().FromCell].Color.ToPlayerColor();

            if (playerColor == PlayerColor.White)
            {
                choosenMove = moveOptions.OrderByDescending(move => move.ToCell).FirstOrDefault();
            }
            else
            {
                choosenMove = moveOptions.OrderBy(move => move.ToCell).FirstOrDefault();
            }
           
            return choosenMove;
        }
    }
}
