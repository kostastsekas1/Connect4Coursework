using System.Windows.Forms;

namespace Connect4Coursework
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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


        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Showcard Gothic", 36F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 70, 0, 0);
            label1.Size = new Size(934, 621);
            label1.TabIndex = 0;
            label1.Text = "CONNECT 4";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = Properties.Resources.blue_screen_that_says_blue_it;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Italic, GraphicsUnit.Point);
            button1.Location = new Point(367, 194);
            button1.MaximumSize = new Size(200, 70);
            button1.Name = "button1";
            button1.Size = new Size(200, 70);
            button1.TabIndex = 1;
            button1.Text = "Player VS Player";
            button1.UseVisualStyleBackColor = false;
            button1.Click += PlayerVSPlayer;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.Transparent;
            button2.BackgroundImage = Properties.Resources.blue_screen_that_says_blue_it;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatAppearance.BorderColor = Color.Black;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Italic, GraphicsUnit.Point);
            button2.Location = new Point(367, 282);
            button2.MaximumSize = new Size(200, 90);
            button2.Name = "button2";
            button2.Size = new Size(200, 70);
            button2.TabIndex = 2;
            button2.Text = "Player VS Computer";
            button2.UseVisualStyleBackColor = false;
            button2.Click += PlayerVsComputer;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.BackColor = Color.Transparent;
            button3.BackgroundImage = Properties.Resources.blue_screen_that_says_blue_it;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.FlatAppearance.BorderColor = Color.Black;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Italic, GraphicsUnit.Point);
            button3.Location = new Point(367, 370);
            button3.MaximumSize = new Size(200, 70);
            button3.Name = "button3";
            button3.Size = new Size(200, 70);
            button3.TabIndex = 3;
            button3.Text = "Scores";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ScoresShow;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.None;
            button4.BackColor = Color.Transparent;
            button4.BackgroundImage = Properties.Resources.blue_screen_that_says_blue_it;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.FlatAppearance.BorderColor = Color.Black;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Italic, GraphicsUnit.Point);
            button4.Location = new Point(367, 467);
            button4.MaximumSize = new Size(200, 90);
            button4.Name = "button4";
            button4.Size = new Size(200, 70);
            button4.TabIndex = 4;
            button4.Text = "Quit Game\r\n";
            button4.UseVisualStyleBackColor = false;
            button4.Click += QuitGame;
            // 
            // MainMenu
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackgroundImage = Properties.Resources.blue_screen_that_says_blue_it;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(934, 621);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Main Menu";
            FormClosed += QuitGameOnFormClosed;
            Load += MainMenu_Load;
            ResumeLayout(false);
        }

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}