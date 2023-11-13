namespace Connect4Coursework
{
    public partial class MainMenu : Form
    {
        public bool playervsComputer;
        public MainMenu()
        {
            InitializeComponent();
            playervsComputer = false;
        }
        private void PlayerVSPlayer(object sender, EventArgs e)
        {
            playervsComputer = false;
            PlayerNames playerNames = new PlayerNames();
            playerNames.playervscomputer = false; ;
            this.Hide();
            playerNames.ShowDialog();

        }

        private void PlayerVsComputer(object sender, EventArgs e)
        {
            playervsComputer = true;
            ChooseDifficulty chooseDifficulty = new ChooseDifficulty();
            chooseDifficulty.menu = this;
            this.Hide();
            chooseDifficulty.ShowDialog();
        }

        private void ScoresShow(object sender, EventArgs e)
        {
            Scores scores = new Scores();
            this.Hide();
            scores.Show();
        }

        private void QuitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void QuitGameOnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}