namespace Connect4Coursework
{
    partial class GameScreenPlayerVsPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(56, 92);
            label1.Name = "label1";
            label1.Size = new Size(211, 115);
            label1.TabIndex = 0;
            label1.Text = "Player 1\r\n\r\n2";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(671, 92);
            label2.Name = "label2";
            label2.Size = new Size(211, 115);
            label2.TabIndex = 1;
            label2.Text = "Player 2\r\n\r\n1";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 60;
            timer1.Tick += timer1_Tick;
            // 
            // GameScreenPlayerVsPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.blue_screen_that_says_blue_it;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(934, 621);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GameScreenPlayerVsPlayer";
            Text = "GameScreenPlayerVsPlayer";
            FormClosed += BackToMainMenu;
            Load += GameScreenPlayerVsPlayer_Load;
            ClientSizeChanged += GameScreenPlayerVsPlayer_ClientSizeChanged;
            Paint += GameScreenPlayerVsPlayer_Paint;
            MouseClick += GameScreenPlayerVsPlayer_MouseClick;
            MouseMove += GameScreenPlayerVsPlayer_MouseMove;
            ResumeLayout(false);
        }

        #endregion


        private Label label1;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}