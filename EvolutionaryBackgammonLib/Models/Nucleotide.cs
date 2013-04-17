using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    public class Nucleotide
    {
        private NucleotideType m_type;

        public NucleotideType Type
        {
            get { return m_type; }
        }

        public Nucleotide(NucleotideType mType)
        {
           m_type = mType;
        }
    }
}
