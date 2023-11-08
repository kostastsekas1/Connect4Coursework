using System.Security.AccessControl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Connect4Coursework
{
    public partial class GameScreenPlayerVsPlayer : Form
    {
        private Rectangle[] columns;
        private int[,] board;
        private int turn; // it is 1 for  Player 1 , 2 for player 2 or 2 for computer 

        private int hoveredColumn = -1;
        private bool isHovering = false;


        private static int rectangleWidth = 330;  // Width of rectangle
        private static int rectangleHeight = 330; // Height of rectangle

        private enum check { vertical, horizontal ,diagonalLeft,diagonalRight}

        public GameScreenPlayerVsPlayer()
        {
            InitializeComponent();

            columns = new Rectangle[7];
            board = new int[7, 7];
            turn = 1;

        }
        private void GameScreenPlayerVsPlayer_Load(object sender, EventArgs e)
        {

        }

        private void BackToMainMenu(object sender, FormClosedEventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
        }

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

        private void GameScreenPlayerVsPlayer_ClientSizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Size of window changed");

            int centerX = ClientSize.Width / 2;
            int centerY = ClientSize.Height / 3;

            DrawState(centerX, centerY);
        }

        private void GameScreenPlayerVsPlayer_MouseClick(object sender, MouseEventArgs e)
        {
            int centerX = ClientSize.Width / 2;
            int centerY = ClientSize.Height / 3;

            int collumnnumber = CollumnNumber(e.Location);
            if (collumnnumber != -1)
            {
                int rownumber = CheckForEmptyRow(collumnnumber);
                //MessageBox.Show(rownumber.ToString());

                if (rownumber != -1 )
                {
                    if(rownumber == 0)
                    {
                        return;
                    }
                    board[rownumber, collumnnumber] = turn;


                    if (turn == 1)
                    {
                        using (Graphics tokens = this.CreateGraphics())
                        {
                            tokens.FillEllipse(Brushes.Red, centerX - 165 + 47 * collumnnumber, centerY - 165 + 47 * rownumber, 45, 45);
                        }
                    }
                    else if (turn == 2)
                    {
                        using (Graphics tokens = this.CreateGraphics())
                        {
                            tokens.FillEllipse(Brushes.Green, centerX - 165 + 47 * collumnnumber, centerY - 165 + 47 * rownumber, 45, 45);
                        }
                    }
                }

                int winner = WinnerChecker(turn);
                if(winner !=-1)
                {
                    string player = (winner == 1) ? "Player 1" : "Player2";
                    MessageBox.Show(player);

                }

                if (turn == 1)
                {
                    turn = 2;
                }
                else if(turn == 2) 
                {
                    turn = 1;
                }
            }


        }

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

        private void DrawState(int centerX, int centerY)
        {
            Update();
            DoubleBuffered = true;

            if (board == null)
            {
                return;
            }

            for (int i = 0; i < board.GetLength(0); i++) // Loop through rows
            {
                for (int j = 0; j < board.GetLength(1); j++) // Loop through columns
                {
                    int turns = board[i, j];
                    //MessageBox.Show(redrawturns.ToString());

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

            int centerX = ClientSize.Width / 2;
            int centerY = ClientSize.Height / 3;

            DrawState(centerX, centerY);

        }

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


        private bool  NumbersEqual(int CheckplayerNumber,int row, int column ,Enum checker)
        {
    
            if (checker.ToString() == "vertical")
            {

                for (int counter = 0; counter <= 3; counter++)
                {
                    if (board[row + counter, column] != CheckplayerNumber)
                    {

                        return false;
                    }
                }

            }else if(checker.ToString() == "horizontal")
            {
                for (int counter = 0; counter <= 3; counter++)
                {
                    if (board[row , column + counter] != CheckplayerNumber)
                    {

                        return false;
                    }
                }
            }else if(checker.ToString() == "diagonalLeft")
            {
                for (int counter = 0; counter <= 3; counter++)
                {
                    if (board[row + counter , column + counter] != CheckplayerNumber)
                    {

                        return false;
                    }
                }
            }else if(checker.ToString() == "diagonalRight")
            {
                for (int counter = 0; counter <= 3; counter++)
                {
                    if (board[row + counter , column - counter] != CheckplayerNumber)
                    {

                        return false;
                    }
                }
            }




            return true;

        }

        private int WinnerChecker(int CheckingPlayerNumber)
        {
            //Vertical
            for (int row =  0; row < board.GetLength(0) - 3;row++)
            {
                for(int column = 0; column < board.GetLength(1); column++)
                {
                    
                    if (NumbersEqual(CheckingPlayerNumber,row,column, check.vertical))
                    { 
                        return CheckingPlayerNumber;
                    }
                }
            }
            //Horizontal
            for (int row = 0; row < board.GetLength(0) ; row++)
            {
                for (int column = 0; column < board.GetLength(1)-3; column++)
                {

                    if (NumbersEqual(CheckingPlayerNumber, row, column, check.horizontal))
                    {
                        return CheckingPlayerNumber;
                    }
                }
            }
            //Left diagonal
            for (int row = 0; row < board.GetLength(0)-3; row++)
            {
                for (int column = 0; column < board.GetLength(1) - 3; column++)
                {

                    if (NumbersEqual(CheckingPlayerNumber, row, column, check.diagonalLeft))
                    {
                        return CheckingPlayerNumber;
                    }
                }
            }
            //right diagonal

            for (int row =0 ; row < board.GetLength(0) - 3; row++)
            {
                for (int column = 3; column < board.GetLength(1) ; column++)
                {

                    if (NumbersEqual(CheckingPlayerNumber, row, column, check.diagonalRight))
                    {
                        return CheckingPlayerNumber;
                    }
                }
            }


            return -1;

        }

    }
    


}
