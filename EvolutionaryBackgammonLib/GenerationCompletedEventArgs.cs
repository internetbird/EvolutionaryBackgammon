using System;
using System.Collections.Generic;

namespace EvolutionaryBackgammonLib
{
    public class GenerationCompletedEventArgs : EventArgs 
    {
        public int GenerationNumber { get; set; }
        public int BestFitness { get; set; }
        public int WorstFitness { get; set; }
        public int AverageFitness { get; set; }
        public Dictionary<NucleotideType, int> BestPlayerChromosomeStructure { get; set; }
    }
}