using System.Security.AccessControl;

namespace Connect4Coursework
{
    public partial class GameScreenPlayerVsPlayer : Form
    {
        private Rectangle[] collumns;
        private int[,] board;
        private int turn; // it is 1 for  Player 1 , 2 for player 2 or 2 for computer 

        private int hoveredColumn = -1; 
        private bool isHovering = false;


        private static int rectangleWidth = 330;  // Width of rectangle
        private static int rectangleHeight = 330; // Height of rectangle

        public GameScreenPlayerVsPlayer()
        {
            InitializeComponent();

            collumns = new Rectangle[7];
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

            for (int i = 0; i < collumns.Length; i++)
            {
                for (int j = 0; j < collumns.Length; j++)
                {
                    if (i == 0)
                    {
                        collumns[j] = new Rectangle(centerX - 168 + 48 * j, centerY - 148, 32, 300);
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

                if (rownumber != -1 && rownumber != 0)
                {
                    board[rownumber, collumnnumber] = turn;
                    if (turn == 1)
                    {
                        using (Graphics tokens = this.CreateGraphics())
                        {
                            tokens.FillEllipse(Brushes.Red, centerX - 165 + 47 * collumnnumber, centerY - 165 + 47 * rownumber, 45, 45);

                        }

                        turn = 2;

                    }else if (turn ==2)
                    {
                        using (Graphics tokens = this.CreateGraphics())
                        {
                            tokens.FillEllipse(Brushes.Green, centerX - 165 + 47 * collumnnumber, centerY - 165 + 47 * rownumber, 45, 45);

                        }
                        turn = 1;

                    }


                }
            }
        }

        private int CollumnNumber(Point Mouse)
        {
            for (int i = 0; i < collumns.Length; i++)
            {
                if ((Mouse.X >= collumns[i].X) && (Mouse.Y >= collumns[i].Y))
                {
                    if ((Mouse.X <= collumns[i].X + collumns[i].Width) && (Mouse.Y <= collumns[i].Y + collumns[i].Height))
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
            for (int j = 0; j < board.GetLength(1); j++) {  // Loop through columns

                using (Graphics tokens = this.CreateGraphics())
                {
                    tokens.FillEllipse(Brushes.DarkGray, centerX - 165 + 47 * j, centerY - 165 , 45, 45);

                }
            }
        }

        private void GameScreenPlayerVsPlayer_MouseMove(object sender, MouseEventArgs e)
        {
            int collumnnumber = CollumnNumber(e.Location);

            int centerX = ClientSize.Width / 2;
            int centerY = ClientSize.Height / 3;

            if (collumnnumber != -1)
            {
                isHovering = true;
                hoveredColumn = collumnnumber;
                

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
                    Color red = Color.FromArgb(5, Color.Red);
                    SolidBrush semiTransparentBrush = new SolidBrush(red);

                    if (turn== 1) {

                        tokens.FillEllipse(semiTransparentBrush, centerX - 165 + 47 * hoveredColumn, centerY - 165, 45, 45);

                    }
                    else if (turn == 2)
                    {
                        Color green = Color.FromArgb(5, Color.Green);
                        semiTransparentBrush.Color = green;
                        tokens.FillEllipse(semiTransparentBrush, centerX - 165 + 47 * hoveredColumn, centerY - 165, 45, 45);
                    }
                }


            }
            else
            {
                clearTopRow(centerX, centerY);
            }

        }
    }



}
