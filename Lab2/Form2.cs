using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
	public partial class Form2 : Form
	{
        string msg1 = "Пустое поле ввода";
		public Form1 form1;
		public Form2()
		{
		    

			InitializeComponent();
		}

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.count--;
            form1.isOpen = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count0 = 0;

            string text0 = textBox1.Text;
            string[] spln = text0.Split('\n');
            foreach (var spl in spln)
            {
                count0++;
            }
          
            label1.Text = "Число строк: " + count0.ToString();

            if(spln[spln.Length-1]== "")
               {
                count0--;
                label1.Text = "Число строк: " + count0.ToString();
              }
            if (count0 == 0)
            {
                MessageBox.Show(msg1);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str0, str1, str2;
            str1 = "Проверка 2.\r\n";
            str2 = "Проверка 3.\r\n";
            str0 = "Проверка.\r\n";
            
            string[] textJ = new string[] { str0, str1, str2 };
            String strJ = String.Join("", textJ);
            textBox1.Text += strJ;
            if (textBox1.Lines[textBox1.Lines.Length - 1] != "")
                str0 = "\r\n" + str0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Lines.Length == 0)
            {
                MessageBox.Show(msg1);
                return;
            }

            string[] arr = new string[textBox1.Lines.Length - 1];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = textBox1.Lines[i + 1];
            }
            textBox1.Lines = arr;
        }
    }
}
