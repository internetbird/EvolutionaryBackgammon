using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    public class BoardCell
    {
        private List<Stone> m_stones = new List<Stone>();
        
        public List<Stone> Stones
        {
            get { return m_stones; }
        }

        public bool IsEmpty
        {
            get { return !m_stones.Any(); }
        }


        /// <summary>
        /// Gets the cell's color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public BoardCellColor Color
        {
            get
            {
                if (IsEmpty)
                {
                    return BoardCellColor.Empty;
                }

                if (m_stones[0] == Stone.White)
                {
                    return BoardCellColor.White; 
                }

                return BoardCellColor.Black;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="BoardCell" /> class.
        /// </summary>
        /// <param name="stones">The stones.</param>
        public BoardCell(List<Stone> stones)
        {
            m_stones = stones;
        }

        public BoardCell()
        {
            
        }

        /// <summary>
        /// Removes one stone from the board cell.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Cell is already empty</exception>
        public void RemoveStone()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Cell is already empty");
            }

            m_stones.RemoveAt(0);
            
        }

        /// <summary>
        /// Adds the stone to the board cell.
        /// </summary>
        /// <param name="stone">The stone.</param>
        /// <exception cref="System.InvalidOperationException">Cell is already occupied with a different stone color</exception>
        public void AddStone(Stone stone)
        {
            if (Color != BoardCellColor.Empty && Color.ToStone() != stone)
            {
                throw new InvalidOperationException("Cell is already occupied with a different stone color");
            }

            Stones.Add(stone);
            
        }

    }

    public enum BoardCellColor
    {
        Empty,
        White,
        Black
        
    }
}
