namespace Connect4Coursework
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void PlayerVSPlayer(object sender, EventArgs e)
        {
            var formPopup = new PlayerNames();
            this.Hide();
            formPopup.ShowDialog();

            //GameScreenPlayerVsPlayer playerVsPlayer = new GameScreenPlayerVsPlayer();
            //playerVsPlayer.Show();


        }

        private void PlayerVsComputer(object sender, EventArgs e)
        {

        }

        private void ScoresShow(object sender, EventArgs e)
        {

        }

        private void QuitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void QuitGameOnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}