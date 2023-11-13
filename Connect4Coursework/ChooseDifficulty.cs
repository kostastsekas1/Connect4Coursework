using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4Coursework
{
    public partial class ChooseDifficulty : Form
    {
        public MainMenu menu;
        public ChooseDifficulty()
        {
            InitializeComponent();
        }

        private void ChooseDifficulty_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void EasyButtonClick(object sender, EventArgs e)
        {
            PlayerNames playerNames = new PlayerNames();
            playerNames.playervscomputer = menu.playervsComputer;
            playerNames.difficulty = "Easy";

            this.Hide();
            playerNames.ShowDialog();
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.Show();
        }

    }
}
