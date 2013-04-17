using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    public class Board
    {
        private int m_boardSize;
        private BoardCell[] m_boardCells;


        public int Size
        {
            get { return m_boardSize; }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Board" /> class.
        /// </summary>
        public Board(int boardSize)
        {
            m_boardSize = boardSize;
            m_boardCells = new BoardCell[boardSize];

            for (int i = 0; i < boardSize; i++)
            {
                m_boardCells[i] = new BoardCell();
            }

        }

        /// <summary>
        /// Gets the <see cref="BoardCell" /> with the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="BoardCell" />.
        /// </value>
        /// <param name="i">The index.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Invalid board cell index</exception>
        public BoardCell this[int i]
        {
            get
            {
                if (i < 0 || i >= m_boardSize)
                {
                    throw new ArgumentException("Invalid board cell index");
                }

                return m_boardCells[i];
            }

            set { m_boardCells[i] = value; }
        }

        /// <summary>
        /// Gets the total number the of a given stone color.
        /// </summary>
        /// <param name="stone">The stone.</param>
        /// <returns></returns>
        public int NumOfStones(Stone stone)
        {
            int numOfStones = 0;

            for (int i = 0; i < m_boardSize; i++)
            {
                if (this[i].Color.ToStone() == stone)
                {
                    numOfStones += this[i].Stones.Count();
                }
            }

            return numOfStones;

        }
    }
}
