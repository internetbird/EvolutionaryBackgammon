using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    public static class EvolutionHelper
    {
        private static readonly Random m_random = new Random(DateTime.Now.Millisecond);
        private static readonly int NumOfNucleotidesTypes = Enum.GetValues(typeof(NucleotideType)).GetLength(0);

        /// <summary>
        /// Gets a random neucleotide index.
        /// </summary>
        /// <returns></returns>
        public static int GetRandomNeucleotideIndex()
        {
            return m_random.Next(Chromosome.Length);
        }

        /// <summary>
        /// Generates a random chromosome.
        /// </summary>
        /// <returns></returns>
        public static Chromosome CreateRandomChromosome()
        {
            var nucleotides = new Nucleotide[Chromosome.Length];
        
            for (int i = 0; i < Chromosome.Length; i++)
            {
                nucleotides[i] = GetRandomNeucleotide();
            }

            return new Chromosome(nucleotides);
        }

        /// <summary>
        /// Creates random player population.
        /// </summary>
        /// <param name="size">The population size.</param>
        /// <param name="color">The players color.</param>
        /// <returns></returns>
        public static List<Player> CreateRandomPopulation(int size, PlayerColor color)
        {
            var population = new List<Player>();

            for (int i = 0; i < size; i++)
            {
                population.Add(CreateRandomPlayer(color));
            }

            return population;

        }

        /// <summary>
        /// Creates a random player.
        /// </summary>
        /// <param name="color">The player's color.</param>
        /// <returns></returns>
        public static Player CreateRandomPlayer(PlayerColor color)
        {
            return new Player(color, CreateRandomChromosome());
        }

        /// <summary>
        /// Gets the random neucleotide.
        /// </summary>
        /// <returns></returns>
        public static Nucleotide GetRandomNeucleotide()
        {
            return new Nucleotide(GetRandomNucleotideType());
        }

        /// <summary>
        /// Gets the random nucleotide type.
        /// </summary>
        /// <returns></returns>
        private static NucleotideType GetRandomNucleotideType()
        {
            return (NucleotideType) m_random.Next(NumOfNucleotidesTypes);
        }
    }
}
