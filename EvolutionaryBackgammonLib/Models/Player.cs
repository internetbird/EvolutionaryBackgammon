using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    public class Player
    {
        private Chromosome m_chromosome;
        private PlayerColor m_color;

        public PlayerColor Color
        {
            get { return m_color; }
        }

        public Chromosome Chromosome
        {
            get { return m_chromosome; }
        }

        public int NumOfWins { get; set; }

        public int Evaluation
        {
            get { return NumOfWins; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="chromosome">The chromosome.</param>
        public Player(PlayerColor color, Chromosome chromosome)
        {
            m_chromosome = chromosome;
            m_color = color;
        }


        /// <summary>
        /// Chooses the next move according to a randomly selected nucleotide type.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="moveOptions">The move options.</param>
        /// <returns></returns>
        public GameMove ChooseNextMove(Board board, List<GameMove> moveOptions)
        {
            GameMove move = null;

            while (move == null)
            {

                Nucleotide nucleotide = ChooseRandomNucleotide();

                IMoveChooser chooser = MoveChooserFactory.Create(nucleotide.Type);

                move = chooser.ChooseMove(board, moveOptions);
            }

            return move;
        }

        /// <summary>
        /// Chooses the random nucleotide.
        /// </summary>
        /// <returns></returns>
        private Nucleotide ChooseRandomNucleotide()
        {
            return m_chromosome[EvolutionHelper.GetRandomNeucleotideIndex()];
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public Player Clone()
        {
            return new Player(Color, Chromosome);
        }
    }
}
