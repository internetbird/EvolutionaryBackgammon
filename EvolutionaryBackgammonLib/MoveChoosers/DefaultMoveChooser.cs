using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib.MoveChoosers
{
    /// <summary>
    /// The default move chooser - chooses a random move
    /// </summary>
    public class DefaultMoveChooser : IMoveChooser
    {
        public GameMove ChooseMove(Board board, List<GameMove> moveOptions)
        {
            var random = new Random(DateTime.Now.Millisecond);
            
            return moveOptions[random.Next(moveOptions.Count)];
        }
    }
}
