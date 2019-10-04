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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterScreen;
			
			label1.Left = (this.Width - label1.Width) / 2;
			button1.Left = (this.Width - button1.Width) / 2;
			button2.Left = (this.Width - button2.Width) / 2;
			button3.Left = (this.Width - button3.Width) / 2;

			Settings.FoodColor = Color.Lime;
			Settings.SnakeColor = Color.DarkOrange;
			Settings.Speed = 350;
			Settings.SizeConst = 22;
			Settings.FieldSize = 15;
			Settings.Theme = false;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			SnakeField sf = new SnakeField();
			sf.ShowDialog();
			this.Show();
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			this.Hide();
			SettingsMenu sm = new SettingsMenu();
			sm.ShowDialog();
			this.Show();
		}
	}
}
