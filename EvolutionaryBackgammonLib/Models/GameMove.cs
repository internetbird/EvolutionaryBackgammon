using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    public class GameMove
    {
        private readonly int m_fromCellIndex;
        private readonly int m_toCellIndex;

        public int FromCell
        {
            get { return m_fromCellIndex; }
        }

        public int ToCell
        {
            get { return m_toCellIndex; }
        }

        public GameMove(int fromCellIndex, int toCellIndex)
        {
            m_fromCellIndex = fromCellIndex;
            m_toCellIndex = toCellIndex;
        }
    }
}
