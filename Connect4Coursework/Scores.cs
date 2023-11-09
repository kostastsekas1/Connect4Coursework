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
            MainMenu menu = new MainMenu();
            menu.Show();
        }

        private void Scores_Load(object sender, EventArgs e)
        {
            string fullpath = Path.Combine(Application.UserAppDataPath, "scores.txt");
            string datatoload = "";


            if (File.Exists(fullpath))
            {
                using (FileStream fileStream = new FileStream(fullpath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        datatoload = reader.ReadToEnd();
                    }
                }
                datatoload = EncryptDecrypt(datatoload);

                string decrypteddata = JsonSerializer.Deserialize<string>(datatoload);


                scoreboard.Text = decrypteddata;
            }
            else
            {
                scoreboard.Text = "No Data yet ";
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
    }
}
