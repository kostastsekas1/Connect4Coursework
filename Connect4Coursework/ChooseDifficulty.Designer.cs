namespace Connect4Coursework
{
    partial class ChooseDifficulty
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
            label1 = new Label();
            button1 = new Button();
            StartButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.MaximumSize = new Size(366, 41);
            label1.Name = "label1";
            label1.Size = new Size(366, 41);
            label1.TabIndex = 0;
            label1.Text = "Choose Difficulty";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.MediumTurquoise;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(120, 121);
            button1.Name = "button1";
            button1.Size = new Size(131, 48);
            button1.TabIndex = 1;
            button1.Text = "Easy";
            button1.UseVisualStyleBackColor = false;
            button1.Click += EasyButtonClick;
            // 
            // StartButton
            // 
            StartButton.Anchor = AnchorStyles.None;
            StartButton.BackColor = Color.Transparent;
            StartButton.BackgroundImage = Properties.Resources.blue_screen_that_says_blue_it;
            StartButton.BackgroundImageLayout = ImageLayout.Stretch;
            StartButton.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            StartButton.FlatAppearance.BorderSize = 0;
            StartButton.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            StartButton.Location = new Point(138, 270);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(93, 23);
            StartButton.TabIndex = 6;
            StartButton.Text = "Back";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += BackButton_Click;
            // 
            // ChooseDifficulty
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.blue_screen_that_says_blue_it;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(390, 305);
            Controls.Add(StartButton);
            Controls.Add(button1);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChooseDifficulty";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Choose Difficulty";
            FormClosing += ChooseDifficulty_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button StartButton;
    }
}