using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    public interface IMoveChooser
    {
        GameMove ChooseMove(Board board, List<GameMove> moveOptions);
    }
}
