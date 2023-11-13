using System.Data.Common;
using System.Text;
using System.Text.Json;

namespace Connect4Coursework
{
    public partial class GameScreenPlayerVsPlayer : Form
    {
        private Rectangle[] columns;
        private int[,] board;
        private Stack<int[,]> BoardStack = new Stack<int[,]>();

        private int turn; // it is 1 for  Player 1 , 2 for player 2 or 2 for computer 

        private int hoveredColumn = -1;
        private bool isHovering = false;

        private static int rectangleWidth = 330;  // Width of rectangle
        private static int rectangleHeight = 330; // Height of rectangle

        private int Score1;
        private int Score2;
        private string winhow;

        public PlayerNames playerNames;
        public bool playervsComputer;
        public string difficulty;

        private string encryptionSecretKey = "word";
        private bool isplayerTurn;

        private enum CheckDirection { vertical, horizontal, diagonalLeft, diagonalRight }

        public GameScreenPlayerVsPlayer()
        {
            InitializeComponent();

            columns = new Rectangle[7];
            board = new int[7, 7];
            turn = 1;
            Score1 = 0;
            Score2 = 0;
            winhow = "";
            BoardStack.Clear();
            isplayerTurn = true;
        }

        private void GameScreenPlayerVsPlayer_Load(object sender, EventArgs e)
        {
            if (playerNames != null)
            {
                if (((PlayerNames)playerNames).Player1Name.Text != "")
                {
                    Player1Label.Text = ((PlayerNames)playerNames).Player1Name.Text;
                }
                else
                {
                    Player1Label.Text = "Player 1";
                }

                if (((PlayerNames)playerNames).Player2Name.Text != "")
                {
                    Player2Label.Text = ((PlayerNames)playerNames).Player2Name.Text;
                }
                else
                {
                    Player2Label.Text = "Player 2";
                }


                playervsComputer = playerNames.playervscomputer;
                difficulty = playerNames.difficulty;

            }
        }

        private void BackToMainMenu(object sender, FormClosedEventArgs e)
        {
            save();
        }

        #region Save and Encryption
        public void save()
        {
            string fullpath = Path.Combine(Application.UserAppDataPath, "scores.txt");

            string ScoreStore = string.Format("{0},{2},{1},{3}",
                                Player1Label.Text, Player2Label.Text, Score1.ToString(), Score2.ToString());

            StringBuilder alldata = new StringBuilder();

            if (File.Exists(fullpath))
            {
                using (StreamReader reader = new StreamReader(fullpath))
                {

                    string line = reader.ReadToEnd();
                    line = EncryptDecrypt(line);
                    line = line.TrimStart('"');
                    line = line.TrimEnd('"');

                    alldata.Append(line);
                    alldata.Append(",");
                }
                alldata.Append(ScoreStore);
                ScoreStore = alldata.ToString();
                ScoreStore = JsonSerializer.Serialize<string>(ScoreStore);
                ScoreStore = EncryptDecrypt(ScoreStore);

                using (FileStream fileStream = new FileStream(fullpath, FileMode.OpenOrCreate))
                {
                    fileStream.Seek(0, SeekOrigin.Begin);

                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.Write(ScoreStore);
                    }
                }
            }
            else
            {
                using (FileStream fileStream = new FileStream(fullpath, FileMode.OpenOrCreate))
                {
                    fileStream.Seek(0, SeekOrigin.Begin);

                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        string headerfile = "Name, Score, Name,Score,";
                        ScoreStore = headerfile + ScoreStore;
                        ScoreStore = JsonSerializer.Serialize<string>(ScoreStore);
                        ScoreStore = EncryptDecrypt(ScoreStore);
                        writer.Write(ScoreStore);
                    }
                }
            }

            this.Hide();
            MainMenu menu = new MainMenu();
            menu.Show();
        }

        private string EncryptDecrypt(string data)
        {
            string EncryptedDecryptedData = "";
            for (int i = 0; i < data.Length; i++)
            {
                EncryptedDecryptedData += (char)(data[i] ^ encryptionSecretKey[i % encryptionSecretKey.Length]);
            }
            return EncryptedDecryptedData;
        }
        #endregion

        #region Painting the board and the grid
        private void GameScreenPlayerVsPlayer_Paint(object sender, PaintEventArgs e)
        {
            DoubleBuffered = true;

            int centerX = ClientSize.Width / 2;
            int centerY = ClientSize.Height / 3;

            int startX = centerX - (rectangleWidth / 2);
            int startY = centerY - (rectangleHeight / 2);

            e.Graphics.FillRectangle(Brushes.DarkGray, startX, startY, rectangleWidth, rectangleHeight);

            for (int i = 0; i < columns.Length; i++)
            {
                for (int j = 0; j < columns.Length; j++)
                {
                    if (i == 0)
                    {
                        columns[j] = new Rectangle(centerX - 168 + 48 * j, centerY - 148, 32, 300);
                    }

                    using (Pen gridPen = new Pen(Color.Black, 2))
                    {
                        gridPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                        e.Graphics.DrawRectangle(gridPen, centerX - 165 + 47 * j, centerY - 165 + 47 * i, 47, 47);
                    }
                }
            }
        }
        #endregion

        #region Handle MouseClick
        private async void GameScreenPlayerVsPlayer_MouseClick(object sender, MouseEventArgs e)
        {
            int centerX = ClientSize.Width / 2;
            int centerY = ClientSize.Height / 3;

            int collumnnumber = CollumnNumber(e.Location);

            if (collumnnumber != -1 && isplayerTurn)
            {
                SaveBoardState();
                int rownumber = CheckForEmptyRow(collumnnumber);

                if (rownumber != -1)
                {
                    if (rownumber == 0)
                    {
                        return;
                    }
                    board[rownumber, collumnnumber] = turn;
                }

                winnerTurn(turn);

                if (playervsComputer)
                {

                    if (difficulty == "Easy")
                    {
                        isplayerTurn = false;
                        Random timetowait = new Random();
                        int time = timetowait.Next(200, 800);
                        await Task.Delay(time);
                        RandomMove(GetAllPossibleMoves(board));
                        winnerTurn(2);
                        isplayerTurn = true;
                    }
                }

                if (turn == 1)
                {
                    if (!playervsComputer)
                    {
                        turn = 2;
                    }
                }
                else if (turn == 2)
                {
                    turn = 1;
                }
            }
        }
        private void winnerTurn(int turn)
        {
            string winnername;
            int winner = WinnerChecker(turn);

            if (winner != -1)
            {
                BoardStack.Clear();
                if (winner == 1)
                {
                    Player1Score.Text = (Score1 + 1).ToString();
                    Score1++;
                    winnername = Player1Label.Text;
                }
                else
                {
                    Player2Score.Text = (Score2 + 1).ToString();
                    winnername = Player2Label.Text;
                    Score2++;
                }

                DialogResult GameoverBox = MessageBox.Show(winnername + " won by connecting 4 " + winhow + "\nWant To start a new game?", "Game Over", MessageBoxButtons.YesNo);
                if (GameoverBox == DialogResult.Yes)
                {
                    clearBoard(true);
                }
                else if (GameoverBox == DialogResult.No)
                {
                    this.Close();
                }
            }
        }
        #endregion

        #region Easy  AI implemenation
        private List<int> GetAllPossibleMoves(int[,] board)
        {
            List<int> legalMoves = new List<int>();

            for (int column = 0; column < board.GetLength(1); column++)
            {
                int rowNumber = CheckForEmptyRow(column);
                if (rowNumber != 0)
                {
                    legalMoves.Add(column);
                }
            }
            return legalMoves;
        }
        private void RandomMove(List<int> PossibleMoves)
        {
            bool MoveFound = false;

            while (!MoveFound)
            {
                Random randomCol = new Random();
                int column = randomCol.Next(PossibleMoves.Count - 1);
                int rownumber = CheckForEmptyRow(column);

                if (rownumber != 0)
                {
                    if (board[rownumber, column] == 0)
                    {
                        board[rownumber, column] = 2;
                        MoveFound = true;

                    }
                }
            }
        }
        #endregion


        #region Checking if collumn and row can receive token and ReDrawing the state of the board for refreshing with timer and clear board feature
        private int CollumnNumber(Point Mouse)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                if ((Mouse.X >= columns[i].X) && (Mouse.Y >= columns[i].Y))
                {
                    if ((Mouse.X <= columns[i].X + columns[i].Width) && (Mouse.Y <= columns[i].Y + columns[i].Height))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private int CheckForEmptyRow(int collumnnumber)
        {
            for (int i = 6; i >= 0; i--)
            {
                if (board[i, collumnnumber] == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private void DrawState()
        {
            int centerX = ClientSize.Width / 2;
            int centerY = ClientSize.Height / 3;
            Update();
            DoubleBuffered = true;

            if (board == null)
            {
                return;
            }

            for (int i = 0; i < board.GetLength(0); i++) // Loop  rows
            {
                for (int j = 0; j < board.GetLength(1); j++) // Loop columns
                {
                    int turns = board[i, j];
                    if (turns == 1)
                    {
                        using (Graphics tokens = this.CreateGraphics())
                        {
                            tokens.FillEllipse(Brushes.Red, centerX - 165 + 47 * j, centerY - 165 + 47 * i, 45, 45);
                        }
                    }
                    else if (turns == 2)
                    {
                        using (Graphics tokens = this.CreateGraphics())
                        {
                            tokens.FillEllipse(Brushes.Green, centerX - 165 + 47 * j, centerY - 165 + 47 * i, 45, 45);
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            DrawState();
        }

        private void clearBoard(bool cleanboard)
        {
            int centerX = ClientSize.Width / 2;
            int centerY = ClientSize.Height / 3;
            if (cleanboard)
            {
                Array.Clear(board, 0, board.Length);
            }
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    using (Graphics tokens = this.CreateGraphics())
                    {
                        tokens.FillEllipse(Brushes.DarkGray, centerX - 165 + 47 * j, centerY - 165 + 47 * i, 45, 45);
                    }
                }
            }
        }



        #endregion

        #region Handle hovering of token in  the top row
        private void clearTopRow(int centerX, int centerY)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {

                using (Graphics tokens = this.CreateGraphics())
                {
                    tokens.FillEllipse(Brushes.DarkGray, centerX - 165 + 47 * j, centerY - 165, 45, 45);

                }
            }
        }

        private void GameScreenPlayerVsPlayer_MouseMove(object sender, MouseEventArgs e)
        {
            int columnnumber = CollumnNumber(e.Location);

            int centerX = ClientSize.Width / 2;
            int centerY = ClientSize.Height / 3;

            if (columnnumber != -1)
            {
                isHovering = true;
                hoveredColumn = columnnumber;

            }
            else
            {
                isHovering = false;
                hoveredColumn = -1;
            }

            if (isHovering)
            {
                using (Graphics tokens = this.CreateGraphics())
                {

                    if (turn == 1)
                    {
                        Color red = Color.FromArgb(5, Color.Red);

                        SolidBrush semiTransparentBrush = new SolidBrush(red);

                        tokens.FillEllipse(semiTransparentBrush, centerX - 165 + 47 * hoveredColumn, centerY - 165, 45, 45);

                    }
                    else if (turn == 2)
                    {
                        Color green = Color.FromArgb(5, Color.Green);
                        SolidBrush semiTransparentBrush = new SolidBrush(green);
                        tokens.FillEllipse(semiTransparentBrush, centerX - 165 + 47 * hoveredColumn, centerY - 165, 45, 45);
                    }
                }
            }
            else
            {
                clearTopRow(centerX, centerY);
            }

        }
        #endregion

        #region Winning Condition Handler Reset and  Undo button  and save board state
        private bool CheckInHowManyInArow(int CheckplayerNumber, int row, int column, CheckDirection checker, int[,] state)
        {
            int tokens = 0;
            if (checker.ToString() == "vertical")
            {
                for (int counter = 0; counter <= 3; counter++)
                {
                    if (board[row + counter, column] == CheckplayerNumber)
                    {
                        tokens++;
                    }
                }
            }
            else if (checker.ToString() == "horizontal")
            {
                for (int counter = 0; counter <= 3; counter++)
                {
                    if (board[row, column + counter] == CheckplayerNumber)
                    {
                        tokens++;
                    }
                }
            }
            else if (checker.ToString() == "diagonalLeft")
            {
                for (int counter = 0; counter <= 3; counter++)
                {
                    if (board[row + counter, column + counter] == CheckplayerNumber)
                    {
                        tokens++;
                    }
                }
            }
            else if (checker.ToString() == "diagonalRight")
            {
                for (int counter = 0; counter <= 3; counter++)
                {
                    if (board[row + counter, column - counter] == CheckplayerNumber)
                    {
                        tokens++;
                    }
                }
            }
            return tokens >= 4;
        }

        private int WinnerChecker(int CheckingPlayerNumber)
        {

            //Vertical
            for (int row = 0; row < board.GetLength(0) - 3; row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    if (CheckInHowManyInArow(CheckingPlayerNumber, row, column, CheckDirection.vertical, board))
                    {
                        winhow = "vertically";
                        return CheckingPlayerNumber;
                    }
                }
            }
            //Horizontal
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1) - 3; column++)
                {
                    if (CheckInHowManyInArow(CheckingPlayerNumber, row, column, CheckDirection.horizontal, board))
                    {
                        winhow = "horizontally";
                        return CheckingPlayerNumber;
                    }
                }
            }
            //Left diagonal
            for (int row = 0; row < board.GetLength(0) - 3; row++)
            {
                for (int column = 0; column < board.GetLength(1) - 3; column++)
                {
                    if (CheckInHowManyInArow(CheckingPlayerNumber, row, column, CheckDirection.diagonalLeft, board))
                    {
                        winhow = "diagonally to the left";
                        return CheckingPlayerNumber;
                    }
                }
            }
            //right diagonal

            for (int row = 0; row < board.GetLength(0) - 3; row++)
            {
                for (int column = 3; column < board.GetLength(1); column++)
                {
                    if (CheckInHowManyInArow(CheckingPlayerNumber, row, column, CheckDirection.diagonalRight, board))
                    {
                        winhow = "diagonally to the right";
                        return CheckingPlayerNumber;
                    }
                }
            }
            return -1;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            clearBoard(true);
        }

        private void UndoButton(object sender, EventArgs e)
        {
            if (BoardStack.Count > 0)
            {
                clearBoard(true);
                board = BoardStack.Pop();
                if (turn == 1)
                {
                    if (!playervsComputer)
                    {
                        turn = 2;
                    }
                }
                else if (turn == 2)
                {
                    turn = 1;
                }
            }
        }
        private void SaveBoardState()
        {
            int[,] copy = new int[7, 7];
            Array.Copy(board, copy, board.Length);
            BoardStack.Push(copy);
        }
        #endregion
    }
}
