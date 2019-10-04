using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
	public partial class LoseForm : Form
	{
		public LoseForm(int score, float time)
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterParent;

			label2.Text = "Score: " + score;
			label3.Text = "Time session: " + (int)time + "s";
			label1.Left = (this.Width - label1.Width) / 2;
			label2.Left = (this.Width - label2.Width) / 2;
			label3.Left = (this.Width - label3.Width) / 2;
			button1.Left = (this.Width - button1.Width) / 2;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
