﻿namespace Connect4Coursework
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
            Player1Label = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            Player1Score = new Label();
            Player2Score = new Label();
            Player2Label = new Label();
            reset = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // Player1Label
            // 
            Player1Label.Anchor = AnchorStyles.None;
            Player1Label.BackColor = Color.Transparent;
            Player1Label.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Italic, GraphicsUnit.Point);
            Player1Label.Location = new Point(85, 75);
            Player1Label.Name = "Player1Label";
            Player1Label.Size = new Size(203, 33);
            Player1Label.TabIndex = 0;
            Player1Label.Text = "Player 1\r\n";
            Player1Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 60;
            timer1.Tick += timer1_Tick;
            // 
            // Player1Score
            // 
            Player1Score.Anchor = AnchorStyles.None;
            Player1Score.BackColor = Color.Transparent;
            Player1Score.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Italic, GraphicsUnit.Point);
            Player1Score.Location = new Point(85, 108);
            Player1Score.Name = "Player1Score";
            Player1Score.Size = new Size(203, 33);
            Player1Score.TabIndex = 2;
            Player1Score.Text = "0";
            Player1Score.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Player2Score
            // 
            Player2Score.Anchor = AnchorStyles.None;
            Player2Score.BackColor = Color.Transparent;
            Player2Score.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Italic, GraphicsUnit.Point);
            Player2Score.Location = new Point(660, 108);
            Player2Score.Name = "Player2Score";
            Player2Score.Size = new Size(198, 33);
            Player2Score.TabIndex = 4;
            Player2Score.Text = "0";
            Player2Score.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Player2Label
            // 
            Player2Label.Anchor = AnchorStyles.None;
            Player2Label.BackColor = Color.Transparent;
            Player2Label.Font = new Font("Showcard Gothic", 15.75F, FontStyle.Italic, GraphicsUnit.Point);
            Player2Label.Location = new Point(660, 75);
            Player2Label.Name = "Player2Label";
            Player2Label.Size = new Size(198, 33);
            Player2Label.TabIndex = 3;
            Player2Label.Text = "Player 2";
            Player2Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // reset
            // 
            reset.Anchor = AnchorStyles.None;
            reset.Location = new Point(420, 586);
            reset.Name = "reset";
            reset.Size = new Size(110, 23);
            reset.TabIndex = 5;
            reset.Text = "Reset Board";
            reset.UseVisualStyleBackColor = true;
            reset.Click += resetButton_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = SystemColors.ActiveCaption;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Showcard Gothic", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            button1.Location = new Point(420, 484);
            button1.Name = "button1";
            button1.Size = new Size(110, 44);
            button1.TabIndex = 6;
            button1.Text = "Undo";
            button1.UseVisualStyleBackColor = false;
            button1.Click += UndoButton;
            // 
            // GameScreenPlayerVsPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.blue_screen_that_says_blue_it;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(934, 621);
            Controls.Add(button1);
            Controls.Add(reset);
            Controls.Add(Player2Score);
            Controls.Add(Player2Label);
            Controls.Add(Player1Score);
            Controls.Add(Player1Label);
            Name = "GameScreenPlayerVsPlayer";
            Text = "Four In A Row";
            FormClosed += BackToMainMenu;
            Load += GameScreenPlayerVsPlayer_Load;
            Paint += GameScreenPlayerVsPlayer_Paint;
            MouseClick += GameScreenPlayerVsPlayer_MouseClick;
            MouseMove += GameScreenPlayerVsPlayer_MouseMove;
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private System.Windows.Forms.Timer timer1;

        private Label Player1Score;
        private Label Player1Label;

        private Label Player2Score;
        private Label Player2Label;
        private Button reset;
        private Button button1;
    }
}