using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomPassGenerator
{
    public partial class Form1 : Form
    {
        StreamWriter writ = new StreamWriter("passtext.txt",true);
        Random r = new Random();
        static string CharArray = "1234567890-=qwertyuiop[]asdfghjkl;'zxcvbnm,./QWERTYUIOP{}|ASDFGHJKL:ZXCVBNM<>?`~";
        char[] ChArray = CharArray.ToCharArray();
        int count;
        int pgencount=0;
        List<string> ChList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            count = Convert.ToInt32(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            pgencount++;
            richTextBox1.Text = "";
            for(int i =0; i < count; i++)
            {
                richTextBox1.Text += ChArray[r.Next(0, ChArray.Length)];
            }
            ChList.Add(richTextBox1.Text);
            writ.WriteLine(richTextBox1.Text);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pgencount >= ChList.Count-1)
            {
                richTextBox1.Text = ChList[ChList.Count-1];
            }
            else 
            {
                pgencount++;
                richTextBox1.Text = ChList[pgencount];
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pgencount <=0)
            {
                richTextBox1.Text = ChList[0];
            }
            else
            {
                pgencount--;
                richTextBox1.Text = ChList[pgencount];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(richTextBox1.Text);
            
        }
        
    }
}
