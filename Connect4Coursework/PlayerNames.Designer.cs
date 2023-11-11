namespace Connect4Coursework
{
    partial class PlayerNames
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
            Player1Name = new TextBox();
            Player2Name = new TextBox();
            label2 = new Label();
            label3 = new Label();
            StartButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(12, 59);
            label1.Name = "label1";
            label1.Size = new Size(74, 23);
            label1.TabIndex = 0;
            label1.Text = "Player1 : ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Player1Name
            // 
            Player1Name.Anchor = AnchorStyles.None;
            Player1Name.Location = new Point(92, 61);
            Player1Name.Name = "Player1Name";
            Player1Name.Size = new Size(286, 22);
            Player1Name.TabIndex = 1;
            // 
            // Player2Name
            // 
            Player2Name.Anchor = AnchorStyles.None;
            Player2Name.Location = new Point(92, 97);
            Player2Name.Name = "Player2Name";
            Player2Name.Size = new Size(286, 22);
            Player2Name.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Showcard Gothic", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(12, 95);
            label2.Name = "label2";
            label2.Size = new Size(74, 23);
            label2.TabIndex = 2;
            label2.Text = "Player2 : ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(108, 18);
            label3.Name = "label3";
            label3.Size = new Size(181, 23);
            label3.TabIndex = 4;
            label3.Text = "Enter Player Names";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StartButton
            // 
            StartButton.Anchor = AnchorStyles.None;
            StartButton.BackColor = Color.Transparent;
            StartButton.BackgroundImage = Properties.Resources.blue_screen_that_says_blue_it;
            StartButton.BackgroundImageLayout = ImageLayout.Stretch;
            StartButton.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            StartButton.FlatAppearance.BorderSize = 0;
            StartButton.Location = new Point(160, 165);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(93, 23);
            StartButton.TabIndex = 5;
            StartButton.Text = "Start ";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click;
            // 
            // PlayerNames
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.blue_screen_that_says_blue_it;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(390, 200);
            Controls.Add(StartButton);
            Controls.Add(label3);
            Controls.Add(Player2Name);
            Controls.Add(label2);
            Controls.Add(Player1Name);
            Controls.Add(label1);
            Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            MaximumSize = new Size(406, 239);
            MinimumSize = new Size(406, 239);
            Name = "PlayerNames";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PlayerNames";
            FormClosing += PlayerNames_FormClosing;
            Load += PlayerNames_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button StartButton;
        public TextBox Player1Name;
        public TextBox Player2Name;
    }
}