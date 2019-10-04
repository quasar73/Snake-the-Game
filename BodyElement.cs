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
	class BodyElement
	{
		Panel part = new Panel();
		byte direction = 0;
		int size_const;

		public BodyElement(int size_const, SnakeField sf, Point pos, Color snake_color)
		{
			this.size_const = size_const;
			part.Size = new Size(size_const, size_const);
			part.BackColor = snake_color;
			part.Location = pos;
			sf.Controls.Add(part);
		}

		public void Move()
		{
			if (direction == 0)
				part.Left += size_const;
			else if (direction == 1)
				part.Top += size_const;
			else if (direction == 2)
				part.Left -= size_const;
			else
				part.Top -= size_const;
		}

		public Point Position
		{
			get
			{
				return part.Location; 
			}
			set
			{
				part.Location = value;
			}
		}

		public byte Direction
		{
			get
			{
				return this.direction;
			}
			set
			{
				this.direction = value;
			}
		}
	}
}
