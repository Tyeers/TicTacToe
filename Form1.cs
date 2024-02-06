using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        private Button[,] buttons;
        private TicTacToeGame ticTacToeGame;
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.Font = new Font(this.Font.FontFamily, this.Font.SizeInPoints * 125 / 96);
            base.OnLoad(e);
        }

        private void InitializeGame()
        {
            buttons = new Button[3, 3];

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    buttons[row, col] = new Button();
                    buttons[row, col].Size = new Size(120, 120);
                    buttons[row, col].Location = new Point(col * 120, row * 120);
                    buttons[row, col].Font = new Font("Arial", 48F, FontStyle.Bold);
                    buttons[row, col].Click += Button_Click;

                    Controls.Add(buttons[row, col]);
                }
            }

            label1 = new Label();
            label1.Text = "00:00:00";
            label1.Location = new Point(151, 400);
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            Controls.Add(label1);

            ticTacToeGame = new TicTacToeGame(buttons, label1);
            timer1.Start();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ticTacToeGame.Button_Click((Button)sender);

            if (ticTacToeGame.IsGameWon())
            {
                MessageBox.Show($"Player {ticTacToeGame.CurrentPlayer} wins!");
                ticTacToeGame.ResetGame();
            }
            else if (ticTacToeGame.IsBoardFull())
            {
                MessageBox.Show("It's a draw!", label1.Text);
                ticTacToeGame.ResetGame();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticTacToeGame.timer1_tick();
            if (ticTacToeGame.IsBoardFull() == true)
            {
                timer1.Stop();
            };
            if (ticTacToeGame.IsGameWon() == true)
            {
                timer1.Stop();
            };
        }
    }
}
