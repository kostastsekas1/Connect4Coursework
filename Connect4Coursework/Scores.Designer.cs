namespace Connect4Coursework
{
    partial class Scores
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
            scoreboard = new RichTextBox();
            SuspendLayout();
            // 
            // scoreboard
            // 
            scoreboard.Location = new Point(120, 69);
            scoreboard.Name = "scoreboard";
            scoreboard.Size = new Size(621, 268);
            scoreboard.TabIndex = 0;
            scoreboard.Text = "";
            // 
            // Scores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.blue_screen_that_says_blue_it;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(934, 621);
            Controls.Add(scoreboard);
            Name = "Scores";
            Text = "Scores";
            FormClosing += Scores_FormClosing;
            Load += Scores_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox scoreboard;
    }
}