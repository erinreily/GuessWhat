using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessWhat
{

    public partial class Form1 : Form
    {
        string goalWord = "";
        string[] words =
        {
            "birds", "pairs", "strong", "treat", "blond",
            "needs", "ninja", "strut", "quill", "quick",
            "seven", "quiet", "preen", "paint", "beans",
            "pills", "joint", "apple", "stand", "bears",
            "brown", "beat", "awry", "nods", "pots",
            "bean", "back", "alto", "star", "pant",
            "jots", "tear", "tilt", "tile", "quit",
            "nice", "neat", "joke", "peel", "agile",
            "nose", "stick"
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void loadWords(string[] arr)
        {
            scrambleArray(arr);
            int i = 0;
            foreach (Control control in Controls)
            {
                if (control.Name.Contains("word"))
                {
                    if(control.ForeColor.Name == "Control")
                    {
                        control.ForeColor = Color.FromName("ControlText");
                    }
                    control.Text = words[i];
                    i++;
                }
            }
        }

        private void scrambleArray(string[] arr)
        {
            Random rnd = new Random();
            int j, k;
            string temp;
            for (int i = 0; i < 30; i++)
            {
                j = rnd.Next(42);
                k = rnd.Next(42);

                temp = arr[j];
                arr[j] = arr[k];
                arr[k] = temp;
            }
        }

        private void flip(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.ForeColor.Name == "ControlText")
            {
                button.ForeColor = Color.FromName("Control");
            }
            else
            {
                button.ForeColor = Color.FromName("ControlText");
            }
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            loadWords(words);
            Random rnd = new Random();
            goalWord = words[rnd.Next(42)];
        }

        private void helpButton_Click_1(object sender, EventArgs e)
        {

        }

        private void print(string text)
        {
            label1.Text = text;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (textBox1.TextLength == 1)
                {
                    if (goalWord.Contains(textBox1.Text))
                    {
                        print("Yes, it contains the letter '" + textBox1.Text + "'.");
                    }
                    else
                    {
                        print("No, it does not contain the letter '" + textBox1.Text + "'.");
                    }
                }
                else
                {
                    print("Only one letter allowed.");
                }
            }
            else if (radioButton2.Checked)
            {
                if (goalWord.Length == numericUpDown1.Value)
                {
                    print("Yes, it is " + goalWord.Length + " letters long.");
                }
                else
                {
                    print("No, it it not " + numericUpDown1.Value + " letters long.");
                }
            }
            else if (radioButton3.Checked)
            {
                if (goalWord == textBox3.Text)
                {
                    print("Yes, the word is " + goalWord + ". Congratulations! You won!");
                }
                else
                {
                    print("No, the word isn't " + textBox3.Text + ", try again.");
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
