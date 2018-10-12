using System;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
	
        enum Direction { Right, Down, Left, Up };
        Direction direction = Direction.Right;
		bool sw,sw2 = false;
		bool isOpen = true;
		int count = 0;
		string msg0 = "Нелязя позвать больше одной формы";
        string msg1 = "Пустое поле ввода";
        

		private void button1_Click(object sender, EventArgs e)
		{
			count++;
			Form2 newForm = new Form2();

			if (count > 1)
			{
				isOpen = false;
				MessageBox.Show(msg0);
			}
			if (isOpen)
			{
				
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
            
            label1.Text = "( " + label1.Left.ToString() + "; " + label1.Top.ToString() + " )";
            switch (direction)
            {
                case Direction.Right:
                    label1.Left += 5;
                    break;
                case Direction.Up:
                    label1.Top -= 5;
                    break;
                case Direction.Down:
                    label1.Top += 5;
                    break;
                case Direction.Left:
                    label1.Left -= 5;
                    break;
                
            }

            if (label1.Top > ClientRectangle.Height - label1.Height)
			{
				direction = Direction.Left;
	 			label1.Top = ClientRectangle.Height - label1.Height;
                
            } 
            
            if (label1.Left > ClientRectangle.Width - label1.Width)
			{
				direction = Direction.Down;
                label1.Left = ClientRectangle.Width - label1.Width;
                
			}

		   if(label1.Top > ClientRectangle.Height - label1.Height)
			    {
				direction = Direction.Right;
				label1.Left = ClientRectangle.Width - label1.Width;
                
				}

           if (label1.Left > ClientRectangle.Width)
			{
                label1.Text = "( W: " + ClientRectangle.Width.ToString() + "; " + "labx: "+label1.Left.ToString() + "; " + "laby: "+label1.Top.ToString() + " )";
				direction = Direction.Up;
				label1.Top = ClientRectangle.Height - label1.Height;
               			
			}

             
          
        			//label1.ForeColor = Color.FromArgb(label1.Left * 255 / (ClientRectangle.Width - label1.Width), 0, 0);
						
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
            string str0;
            str0 = "Проверка.\r\n";
            textBox1.Text = str0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sw2 = true;
        }

   }
}
