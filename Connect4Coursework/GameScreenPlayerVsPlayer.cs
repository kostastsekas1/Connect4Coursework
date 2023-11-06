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
    public partial class GameScreenPlayerVsPlayer : Form
    {
        public GameScreenPlayerVsPlayer()
        {
            InitializeComponent();
        }

        private void GameScreenPlayerVsPlayer_Load(object sender, EventArgs e)
        {

        }

        private void BackToMainMenu(object sender, FormClosedEventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
        }
    }
}
