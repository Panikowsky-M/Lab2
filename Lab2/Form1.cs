using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
	
        enum Direction { Right, Down, Left, Up };
        Direction direction = Direction.Right;
		bool sw,sw2 = false;
		public bool isOpen = true;
		public int count = 0;
		string msg0 = "Нелязя позвать больше одной формы";
        string msg1 = "Пустое поле ввода";
        

		private void button1_Click(object sender, EventArgs e)
		{
			
			

            if (count >= 1)
            {
                isOpen = false;
                MessageBox.Show(msg0);
            }
            if (isOpen)
			{
                Form2 newForm = new Form2();
                count++;
                newForm.Show();
				newForm.form1 = this;
			}
		}

		public Form1()
        {
			
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int R = 0, G = 0, B = 0;
            switch (direction)
            {
                case Direction.Right:
                    label1.Left += 10;
                    label1.Top = 0;
                    if(label1.Right >= ClientRectangle.Width)
                    {
                        
                           direction = Direction.Down;

                            label1.Left = ClientRectangle.Width - label1.Width;
                   
                    }
                    R = 255;
                    G = 255 - label1.Left * 255 / (ClientRectangle.Width - label1.Width);
                    B = 0;
                    if (G > 255)
                        G = 255;
                    if (G < 0)
                        G = 0;
                    break;
                case Direction.Down:
                    label1.Top += 10;
                    label1.Left = ClientRectangle.Width - label1.Width;
                    if (label1.Top >= ClientRectangle.Height - label1.Height)
                    {
                        direction = Direction.Left;
                        label1.Top = ClientRectangle.Height - label1.Height;

                    }
                    break;
                case Direction.Left:
                    label1.Left -= 10;
                    label1.Top = ClientRectangle.Height - label1.Height;
                    if(label1.Left <= 0)
                    {
                        direction = Direction.Up;
                        label1.Left = 0;
                    }
                    break;
                case Direction.Up:
                    label1.Top -= 10;
                    label1.Left = 0;
                    if(label1.Top <= 0)
                    {
                        direction = Direction.Right;
                        label1.Top = 0;
                    }
                    break;
            }
              

			label1.ForeColor = Color.FromArgb(R,G,B);
			  
			
			
		}
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		             {
			                   sw = false; timer1.Start(); 
		             }

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		           {
			                   sw = true; timer1.Stop();
		           }

		private void button2_Click(object sender, EventArgs e)
		{
			int count2 = 0;
            
            string text0 = textBox1.Text;
            string[] spln = text0.Split('\n');
            foreach (var spl in spln)
            { 
                count2++;
            }
            if(spln[spln.Length-1]=="")
                count2--;
            label2.Text = "Число строк: " + count2.ToString();
            if (count2 == 0)
            {
                MessageBox.Show(msg1);
                return;
            }
            
		}
        

        private void button3_Click(object sender, EventArgs e)
        {
            string str0, str1, str2;
            str1 = "Проверка 2.\r\n";
            str2 = "Проверка 3.\r\n";
            str0 = "Проверка.\r\n";
            if (textBox1.Lines[textBox1.Lines.Length - 1] != "")
                str0 = "\r\n" + str0;
            string[] textJ = new string[] { str0,str1,str2 };
            String strJ = String.Join("",textJ);
            textBox1.Text += strJ;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Lines.Length == 0)
            {
                MessageBox.Show(msg1);
                return;
            }

            string [] arr = new string[textBox1.Lines.Length-1];
            for(int i = 0; i<arr.Length; i++)
            {
                arr[i] = textBox1.Lines[i + 1];
            }
            textBox1.Lines = arr;
        }
    }
}
