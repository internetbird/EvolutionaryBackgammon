using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    public class GenerationGameSetCompletedEventArgs : EventArgs
    {
        public int GenerationPrecentCompleted { get; set; }
    }
}
