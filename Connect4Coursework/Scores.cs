using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Label = System.Windows.Forms.Label;

namespace Connect4Coursework
{
    public partial class Scores : Form
    {
        private string encryptionSecretKey = "word";

        public Scores()
        {
            InitializeComponent();
        }

        private void Scores_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Scores_Load(object sender, EventArgs e)
        {
            int centerX = ClientSize.Width / 2 - panel1.Width / 2;
            int centerY = ClientSize.Height / 2 - panel1.Height / 2;

            panel1.Location = new Point(centerX, centerY);
            panel1.BackColor = Color.DarkGray;
            panel1.AutoScroll = true;
            LoadAndShow();
        }

        #region Load And Encrypt and show data
        private void LoadAndShow()
        {
            DoubleBuffered = true;

            string fullpath = Path.Combine(Application.UserAppDataPath, "scores.txt");
            string datatoload = "";

            StringBuilder sb = new StringBuilder();
            if (File.Exists(fullpath))
            {
                using (FileStream fileStream = new FileStream(fullpath, FileMode.Open))
                {
                    fileStream.Seek(0, SeekOrigin.Begin);
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        datatoload = reader.ReadToEnd();
                    }
                }
                datatoload = EncryptDecrypt(datatoload);

                string decrypteddata = JsonSerializer.Deserialize<string>(datatoload);
                string[] scores = decrypteddata.Split(',');

                panel1.RowCount -= 1;
                for (int i = 0; i < scores.Length; i += 4)
                {
                    panel1.RowCount += 1;
                    for (int j = i; j < i+4; j++)
                    {
                        // Create a Label for each data item
                        Label label = new Label();
                        label.Text = scores[j];
                        label.Font = new Font("Showcard Gothic", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
                        label.TextAlign = ContentAlignment.MiddleCenter;

                        label.Dock = DockStyle.Fill;

                        // Add the Label to the TableLayoutPanel

                        panel1.Controls.Add(label, j % 4, panel1.RowCount - 1);
                    }
                }
            }
            else
            {
                label1.Text = "No Data yet ";
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.Show();
        }
    }
}
