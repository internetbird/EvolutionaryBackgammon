using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionaryBackgammonLib
{
    public delegate void PlayerTurnCompletedEventHandler(object sender, EventArgs args);
    public delegate void PlayerTurnStartedEventHandler(object sender, EventArgs args);

    public class Game
    {
        private readonly Player m_whitePlayer;
        private readonly Player m_blackPlayer;
        private Player m_winner;
        private Board m_board;
        private Player m_currentPlayer;
        private const int NumOfStonesPerPlayer = 15;
        public const int BoardSize = 24;
        private readonly Random m_random = new Random(DateTime.Now.Millisecond);
        private int m_diceValue;

        public event PlayerTurnCompletedEventHandler PlayerTurnCompleted;
        public event PlayerTurnCompletedEventHandler PlayerTurnStarted;

        public Board Board
        {
            get { return m_board; }
        }

        public int DiceValue
        {
            get { return m_diceValue; }
        }

        public Player CurrentPlayer
        {
            get { return m_currentPlayer; }
        }

        /// <summary>
        /// Initializes a new instance of the backgammon <see cref="Game" /> class.
        /// </summary>
        /// <param name="whitePlayer">whitePlayer</param>
        /// <param name="blackPlayer">blackPlayer</param>
        public Game(Player whitePlayer, Player blackPlayer)
        {
            m_whitePlayer = whitePlayer;
            m_blackPlayer = blackPlayer;
         //   m_currentPlayer = whitePlayer;
            m_currentPlayer = blackPlayer;
            m_winner = null;

            InitializeGameBoard();
        }

        /// <summary>
        /// Initializes the game board.
        /// </summary>
        private void InitializeGameBoard()
        {
            m_board = new Board(BoardSize);

            m_board[0] = new BoardCell(GetStartStones(Stone.White));
            m_board[BoardSize - 1] = new BoardCell(GetStartStones(Stone.Black));

        }

        /// <summary>
        /// Gets the start stones for the given stone color.
        /// </summary>
        /// <param name="stone">The stone.</param>
        /// <returns></returns>
        private List<Stone> GetStartStones(Stone stone)
        {
            return new List<Stone>(Enumerable.Repeat(stone, NumOfStonesPerPlayer));
        }


        /// <summary>
        /// Plays the game.
        /// </summary>
        /// <returns>The winner of the game</returns>
        public Player Play()
        {
            while (m_winner == null)
            {
                ThrowDice();

                OnPlayerTurnStarted();

                List<GameMove> moveOptions = GameHelper.GetAllMoveOptions(m_board, m_currentPlayer.Color, m_diceValue);

                if (moveOptions.Any())
                {
                    GameMove playerMove = m_currentPlayer.ChooseNextMove(m_board, moveOptions);
                    GameHelper.ApplyMove(playerMove, m_board);

                    SetGameWinner();
                }
                
                SwitchPlayers();
                
                OnPlayerTurnCompleted();
            }

            return m_winner;

        }

        /// <summary>
        /// Called when [player turn completed].
        /// </summary>
        private void OnPlayerTurnCompleted()
        {
            if (PlayerTurnCompleted != null)
            {
                PlayerTurnCompleted(this, new EventArgs());
            }
        }

        private void OnPlayerTurnStarted()
        {
            if (PlayerTurnStarted != null)
            {
                PlayerTurnStarted(this, new EventArgs());
            }
        }

        /// <summary>
        /// Sets the game winner, if it has one.
        /// </summary>
        private void SetGameWinner()
        {
            if (m_board.NumOfStones(Stone.White) == 0)
            {
                m_winner = m_whitePlayer;

            } else if (m_board.NumOfStones(Stone.Black) == 0)
            {
                m_winner = m_blackPlayer;
            }
        }

        /// <summary>
        /// Switches the current player.
        /// </summary>
        private void SwitchPlayers()
        {
            if (m_currentPlayer == m_whitePlayer)
            {
                m_currentPlayer = m_blackPlayer;
            }
            else
            {
                m_currentPlayer = m_whitePlayer;
            }
        }

        /// <summary>
        /// Throws the dice. Sets the dice to a random value between 1 and 6. 
        /// </summary>
        private void ThrowDice()
        {
            m_diceValue = m_random.Next(1, 7);
        }
    }
}
