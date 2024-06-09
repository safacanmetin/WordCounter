using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WordCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string fileContent = "";


        private void button3_Click(object sender, EventArgs e)
        {
            string filePath;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Text files (*.txt)|*.txt";
                dialog.ShowDialog();
                filePath = dialog.FileName;
            }

            if (File.Exists(filePath))
            {
                try
                {
                    fileContent = File.ReadAllText(filePath);
                    textBox3.Text = "Your file is added.";
                    textBox3.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("File not found.");
            }

            int wordCount = CountWords(fileContent);

            int lineCount = CountLines(fileContent);

            textBox1.Text = $"Word count: {wordCount}";
            textBox1.Visible = true;
            textBox2.Text = $"Line count: {lineCount}";
            textBox2.Visible = true;

        }

        private int CountWords(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            int count = 0;
            bool inWord = false;
            foreach (char c in text)
            {
                if (char.IsWhiteSpace(c))
                {
                    inWord = false;
                    count++;
                }
                else if (!inWord)
                {
                    inWord = true;
                }
            }

            return count-2;
        }

        private int CountLines(string text)
        {
            return text.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Length;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
