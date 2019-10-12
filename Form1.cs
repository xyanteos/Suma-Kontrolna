using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;



namespace sprawdzanie_sumy_kontrolnej
{
    
    public partial class Form1 : Form
    {
        public string plik1, plik2; 
        public string checkMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return Encoding.Default.GetString(md5.ComputeHash(stream));
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //string file1 = file (FBD.SelectedPath);
                textBox1.Text = ofd.FileName;
                checkBox2.Checked = true;
                plik1 = ofd.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //string file2 = Directory.GetDirectoryRoot(FBD.SelectedPath);
                textBox2.Text = ofd.FileName;
                checkBox1.Checked = true;
                plik2 = ofd.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hash1 = checkMD5(plik1);
            string hash2 = checkMD5(plik2);
            if(hash1 == hash2)
            {
                textBox3.Text = "Pliki są takie same!";
            }
            else
            {
                textBox3.Text = "Pliki NIE są takie same!";
            }
        }
    }
}
