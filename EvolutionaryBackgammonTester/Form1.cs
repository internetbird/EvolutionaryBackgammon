using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using EvolutionaryBackgammonLib;

namespace EvolutionaryBackgammonTester
{
    public partial class Form1 : Form
    {
        private Game m_game;
        private Board m_currentBoardState;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        /// <summary>
        /// Initializes the game.
        /// </summary>
        private void InitializeGame()
        {
            var whitePlayer = EvolutionHelper.CreateRandomPlayer(PlayerColor.White);
            var blackPlayer = EvolutionHelper.CreateRandomPlayer(PlayerColor.Black);

            m_game = new Game(whitePlayer, blackPlayer);
            m_currentBoardState = m_game.Board;
            m_game.PlayerTurnCompleted += OnPlayerTurnCompleted;
            m_game.PlayerTurnStarted += OnPlayerTurnStarted;
        }




        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(e.Graphics);
        }

        private void DrawBoard(Graphics graphics)
        {

            for (int i = 0; i < m_game.Board.Size; i++)
            {
                for (int j = 0; j < m_currentBoardState[i].Stones.Count; j++)
                {
                    var brush = new SolidBrush(m_currentBoardState[i].Color == BoardCellColor.White ? Color.White : Color.Black);

                    graphics.FillEllipse(brush ,75 + i*40, Height - 145 - j*30, 25 , 25);
                }
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            m_game.Play();
        }

        private void OnPlayerTurnCompleted(object sender, EventArgs args)
        {
            m_currentBoardState = m_game.Board;
            Refresh();

            Thread.Sleep(2000);
        }

        private void OnPlayerTurnStarted(object sender, EventArgs args)
        {
            lblGameStatus.Text = string.Format("{0} player plays dice value:{1}", m_game.CurrentPlayer.Color,
                                               m_game.DiceValue);

            lblGameStatus.Refresh();
        }
    }
}
