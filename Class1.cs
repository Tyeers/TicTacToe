using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public class TicTacToeGame
    {
        private Button[,] buttons;
        private char currentPlayer = 'X';
        private int seconds = 0;
        private System.Windows.Forms.Label label1;

        public TicTacToeGame(Button[,] buttons, System.Windows.Forms.Label label1)
        {
            this.buttons = buttons;
            this.label1 = label1;
        }

        public char CurrentPlayer
        {
            get { return currentPlayer; }
        }

        public System.Windows.Forms.Label Label1
        {
            get { return label1; }
        }
        public void InitializeGame(Button[,] buttons, System.Windows.Forms.Label label1)
        {
            this.buttons = buttons;
            this.label1 = label1;
        }

        public void Button_Click(Button button)
        {
            if (button.Text == "" && !IsGameWon())
            {
                button.Text = currentPlayer.ToString();

                if (IsGameWon())
                {
                    MessageBox.Show($"Player {currentPlayer} wins!");
                    ResetGame();
                }
                else if (IsBoardFull())
                {
                    MessageBox.Show("It's a draw!", label1.Text);
                    ResetGame();
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
        }

        public bool IsGameWon()
        {
            for (int i = 0; i < 3; i++)
            {
                if ((buttons[i, 0].Text == currentPlayer.ToString() && buttons[i, 1].Text == currentPlayer.ToString() && buttons[i, 2].Text == currentPlayer.ToString()) ||
                    (buttons[0, i].Text == currentPlayer.ToString() && buttons[1, i].Text == currentPlayer.ToString() && buttons[2, i].Text == currentPlayer.ToString()) ||
                    (buttons[0, 0].Text == currentPlayer.ToString() && buttons[1, 1].Text == currentPlayer.ToString() && buttons[2, 2].Text == currentPlayer.ToString()) ||
                    (buttons[0, 2].Text == currentPlayer.ToString() && buttons[1, 1].Text == currentPlayer.ToString() && buttons[2, 0].Text == currentPlayer.ToString()))
                {                  
                    return true;
                }
            }

            return false;
        }

        public bool IsBoardFull()
        {
            foreach (Button button in buttons)
            {
                if (button.Text == "")
                {
                    return false;
                }
            }
            return true;
        }

        public void ResetGame()
        {
            foreach (Button button in buttons)
            {
                button.Text = "";
            }
            currentPlayer = 'X';
            label1.Text = "00:00:00";
            seconds = 0;
        }

        public void timer1_tick()
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            seconds++;
            label1.Text = time.ToString(@"hh\:mm\:ss");
        }
    }
}