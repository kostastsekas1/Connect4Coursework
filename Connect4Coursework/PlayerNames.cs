using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Connect4Coursework
{
    public partial class PlayerNames : Form
    {
        public bool playervscomputer;
        public string difficulty;

        public PlayerNames()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void PlayerNames_Load(object sender, EventArgs e)
        {
            if (playervscomputer)
            {
                Player2Name.Text = "AI (" + difficulty + ")";
                Player2Name.ReadOnly = true;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (invalidName(Player1Name.Text) || invalidName(Player2Name.Text))
            {
                MessageBox.Show("The names cannot have ',' in them");
                return;
            }
            GameScreenPlayerVsPlayer playerVsPlayer = new GameScreenPlayerVsPlayer();
            playerVsPlayer.playerNames = this;

            playerVsPlayer.difficulty = difficulty;
            playerVsPlayer.playervsComputer = playervscomputer;

            playerVsPlayer.Show();
            this.Hide();
        }

        private void PlayerNames_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private bool invalidName(string name1)
        {
            foreach (char letter in name1)
            {
                if (letter == ',')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
