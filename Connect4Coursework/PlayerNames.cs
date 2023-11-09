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

        public PlayerNames()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            GameScreenPlayerVsPlayer playerVsPlayer = new GameScreenPlayerVsPlayer();
            playerVsPlayer.playerNames = this;
            playerVsPlayer.Show();
            this.Hide();
        }


    }
}
