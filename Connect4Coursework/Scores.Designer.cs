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
            label1 = new Label();
            button1 = new Button();
            panel1 = new TableLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(910, 108);
            label1.TabIndex = 2;
            label1.Text = "ScoreBoard";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderColor = Color.SteelBlue;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Showcard Gothic", 8.25F, FontStyle.Italic, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(812, 287);
            button1.Name = "button1";
            button1.Size = new Size(110, 62);
            button1.TabIndex = 4;
            button1.Text = "Back To Menu";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.ColumnCount = 4;
            panel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panel1.Location = new Point(175, 170);
            panel1.Name = "panel1";
            panel1.RowCount = 1;
            panel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
            panel1.Size = new Size(576, 449);
            panel1.TabIndex = 5;
            // 
            // Scores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.blue_screen_that_says_blue_it;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(934, 621);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Scores";
            Text = "Scores";
            Load += Scores_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button1;
        private TableLayoutPanel panel1;
    }
}