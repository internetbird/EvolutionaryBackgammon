using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    /// <summary>
    /// The game helper class
    /// </summary>
    public static class GameHelper
    {
        /// <summary>
        /// Gets all move options for a given board state, player color and dice value.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="playerColor">Color of the player.</param>
        /// <param name="diceValue">The dice value.</param>
        /// <returns></returns>
        public static List<GameMove> GetAllMoveOptions(Board board, PlayerColor playerColor, int diceValue)
        {
            var moves = new List<GameMove>();

            for (int i = 0; i < board.Size; i++)
            {
 
                if (board[i].Color.ToPlayerColor() == playerColor)
                {
                    int destinationIndex = (playerColor == PlayerColor.White ? i + diceValue : i - diceValue);

                    if (destinationIndex < 0 || destinationIndex >= board.Size) //Stone removed from board
                    {
                         moves.Add(new GameMove(i,destinationIndex));

                    } else if(board[destinationIndex].Color == BoardCellColor.Empty /*Move to an empty cell*/ ||
                              board[destinationIndex].Color.ToPlayerColor() == playerColor /*Build a wall */ ||
                             (board[destinationIndex].Color.ToPlayerColor() != playerColor && board[destinationIndex].Stones.Count == 1) /*Hit opponent cell*/ )
                    {
                          moves.Add(new GameMove(i,destinationIndex));
                    }

                }

            }

            return moves;
        }

        /// <summary>
        /// Applies the given move on the given board.
        /// The function assumes that the move is legal.
        /// </summary>
        /// <param name="playerMove">The player move.</param>
        /// <param name="board"></param>
        public static void ApplyMove(GameMove playerMove, Board board)
        {

            BoardCell sourceCell = board[playerMove.FromCell];
            Stone stoneToMove = sourceCell.Stones[0];

           sourceCell.RemoveStone();

            if (playerMove.ToCell.InsideBoardBounds()) //Stone will stay in the board
            {
                BoardCell destinationCell = board[playerMove.ToCell];

                if (destinationCell.Color == sourceCell.Color ||
                    destinationCell.Color == BoardCellColor.Empty) //If the source and destination color are the same or the destination cell is empty, add the stone
                {
                    destinationCell.AddStone(stoneToMove);
                }
                else //Hit opponent stone
                {
                    Stone opponentStone = destinationCell.Stones[0];
                    destinationCell.RemoveStone();
                    destinationCell.AddStone(stoneToMove);

                    ReturnStoneToBase(opponentStone, board, GetStoneBaseIndex(opponentStone, board.Size));

                }
                
            }
           
        }

        /// <summary>
        /// Returns a stone that was hit its base.
        /// </summary>
        /// <param name="stone">The stone</param>
        /// <param name="board">The board.</param>
        /// <param name="baseIndex">The base index.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void ReturnStoneToBase(Stone stone, Board board, int baseIndex)
        {

            if (board[baseIndex].Color == BoardCellColor.Empty ||
                board[baseIndex].Color.ToStone() == stone) //If base cell is empty or contains stones of the same color, move the stone
            {
                board[baseIndex].AddStone(stone);
            }
            else //Base cell contains opponent stones
            {
                if (board[baseIndex].Stones.Count == 1) //Hit opponent cell
                {
                    Stone opponentStone = board[baseIndex].Stones[0];
                    board[baseIndex].RemoveStone();
                    board[baseIndex].AddStone(stone);

                    ReturnStoneToBase(opponentStone,board, GetStoneBaseIndex(opponentStone, board.Size));

                }
                else //Base cell contains an opponent wall
                {
                    ReturnStoneToBase(stone, board, GetNextBaseIndex(baseIndex, stone));
                }
            }
        }

        /// <summary>
        /// Gets the index of the next optional base.
        /// </summary>
        /// <param name="baseIndex">Index of the base.</param>
        /// <param name="stone">The stone.</param>
        /// <returns></returns>
        private static int GetNextBaseIndex(int baseIndex, Stone stone)
        {
            if(stone == Stone.White) return baseIndex + 1;

            return baseIndex - 1;
        }

        /// <summary>
        /// Gets the index of the stone base.
        /// </summary>
        /// <param name="stone">The stone.</param>
        /// <param name="boardSize">Size of the board.</param>
        /// <returns></returns>
        private static int GetStoneBaseIndex(Stone stone, int boardSize)
        {
            if (stone == Stone.White) return 0;

            return boardSize - 1;
        }
    }
}
