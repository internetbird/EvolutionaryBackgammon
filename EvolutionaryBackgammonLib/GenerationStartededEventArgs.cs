using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    public class GenerationStartededEventArgs : EventArgs
    {
        public int GenerationNumber { get; set; }
    }
}
