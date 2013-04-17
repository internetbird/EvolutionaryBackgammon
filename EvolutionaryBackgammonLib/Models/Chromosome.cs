using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    public class Chromosome
    {
        public const int Length = 100;
        private Nucleotide[] m_nucleotides = new Nucleotide[Length]; 

        public Chromosome(Nucleotide[] mNucleotides)
        {
            if (mNucleotides.Length != Length)
            {
                throw  new ArgumentException(string.Format("Number of nucleotides must be {0}", Length));
            }

            m_nucleotides = mNucleotides;
        }


        public Nucleotide this[int i]
        {
            get { return m_nucleotides[i]; }
        }

        public Nucleotide[] GetNucleotides(int startPosition, int endPosition)
        {
            if (startPosition < 0 || endPosition >= Length)
            {
                throw new ArgumentException("Position arguments are not valid");
            }

            return m_nucleotides.Skip(startPosition).Take(endPosition - startPosition + 1).ToArray().Clone() as Nucleotide[];

        }


    }
}
