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
	public partial class SettingsMenu : Form
	{
		Color snake_color = Color.DarkOrange,
			food_color = Color.Lime;

		public SettingsMenu()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			numericUpDown1.Enabled = false;
			radioButton3.Checked = true;
			radioButton9.Checked = true;
			radioButton13.Checked = true;
			radioButton19.Checked = true;
		}

		private void RadioButton6_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton6.Checked)
				numericUpDown1.Enabled = true;
			else
				numericUpDown1.Enabled = false;
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			cd.ShowDialog();
			food_color = cd.Color;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			cd.ShowDialog();
			snake_color = cd.Color;
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			Settings.FoodColor = food_color;
			Settings.SnakeColor = snake_color;
			int field_size = 15,
				size_const = 22,
				speed = 350;
			bool theme = false;

			//-------Field Size----
			if (radioButton1.Checked)
				field_size = 5;
			else if (radioButton2.Checked)
				field_size = 10;
			else if (radioButton3.Checked)
				field_size = 15;
			else if (radioButton4.Checked)
				field_size = 20;
			else if (radioButton5.Checked)
				field_size = 25;
			else if (radioButton6.Checked)
				field_size = Convert.ToInt32(numericUpDown1.Value);
			//----------------------


			//-------Size Const-----
			if (radioButton7.Checked)
				size_const = 16;
			else if (radioButton8.Checked)
				size_const = 20;
			else if (radioButton9.Checked)
				size_const = 22;
			else if (radioButton10.Checked)
				size_const = 28;
			else if (radioButton11.Checked)
				size_const = 32;
			//----------------------


			//---------Speed--------
			if (radioButton12.Checked)
				speed = 250;
			else if (radioButton13.Checked)
				speed = 350;
			else if (radioButton14.Checked)
				speed = 500;
			else if (radioButton15.Checked)
				speed = 650;
			else if (radioButton16.Checked)
				speed = 750;
			else if (radioButton17.Checked)
				speed = 1000;
			else if (radioButton18.Checked)
				speed = 100;
			//----------------------


			//---------Theme--------
			if (radioButton19.Checked)
				theme = false;
			else if (radioButton20.Checked)
				theme = true;
			//----------------------

			Settings.FieldSize = field_size;
			Settings.SizeConst = size_const;
			Settings.Speed = speed;
			Settings.Theme = theme;

		}
	}
}
