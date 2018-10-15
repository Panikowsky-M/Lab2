using System;
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
      
		private void button1_Click(object sender, EventArgs e)
		{
			
			Form2 newForm = new Form2();

			if (count >= 1)
			{
				isOpen = false;
				MessageBox.Show(msg0);
			}
			if (isOpen)
			{
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
                    label1.Left += 5;
                    label1.Top = 0;
                    if (label1.Left >= ClientRectangle.Width - label1.Width)
			          {
				direction = Direction.Down;
				label1.Left = ClientRectangle.Width- label1.Width;
			          }
                    R = 0;
                    G = 255; //- label1.Left * 255 / (ClientRectangle.Width - label1.Width);
                    B = 0;
                    if (G < 0) G = 0;
                    if (G > 255) G = 255;
                    break;

                case Direction.Down:
                    label1.Top += 5;
                    label1.Left = ClientRectangle.Width - label1.Width;
                    if (label1.Top >= ClientRectangle.Height - label1.Height)
			    {
				direction = Direction.Left;
				label1.Top = ClientRectangle.Height - label1.Height;
				}
                    R = 0;
                    G = 0;
                    B = 255; //- label1.Top * 255 / (ClientRectangle.Height - label1.Height);
                    if (B < 0) B = 0;
                    if (B > 255) B = 255;
                    break;

                case Direction.Left:
                    label1.Left -= 5;
                    if (label1.Left <= 0)
			            { 
				direction = Direction.Up;
				label1.Left = 0;
			            }
                    R = 255;
                    G = 0;
                    B = 255;
                    if (R < 0) R = 0;
                    if (R > 255) R = 255;
                    break;

                case Direction.Up:
                    label1.Top -= 5;
                    if (label1.Top <= 0)
			           {
				direction = Direction.Right;
			    label1.Top = 0;
			         }
                    R = 255;
                    G = 255 - label1.Left * 255 / (ClientRectangle.Width - label1.Width);
                    B = 0;
                    if (G < 0) G = 0;
                    if (G > 255) G = 255;
                    break;
              }
            label1.ForeColor = System.Drawing.Color.FromArgb(R, G, B);
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
    }
}
