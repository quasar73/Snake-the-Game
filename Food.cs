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
	class Food
	{
		Panel food = new Panel();
		int X_edge, Y_edge, size_const;

		public Point Position
		{
			get
			{
				return food.Location;
			}
		}

		public Food(int size_const, int X_edge, int Y_edge, SnakeField sf)
		{
			this.X_edge = X_edge;
			this.Y_edge = Y_edge;
			this.size_const = size_const;
			food.Size = new Size(size_const, size_const);
			food.BackColor = Settings.FoodColor;
			sf.Controls.Add(food);
		}

		public void Spawn(List<BodyElement> body)
		{
			Random rand = new Random();
			bool ok = true;
			Point pos;

			do
			{
				pos = new Point(rand.Next(X_edge) * size_const, rand.Next(Y_edge) * size_const);
				ok = true;

				for (int i = 0; i < body.Count; i++)
				{
					if (body[i].Position.X == pos.X && body[i].Position.Y == pos.Y)
					{
						ok = false;
						break;
					}

				}
			} while (ok == false);

			food.Location = pos;
		}
	}
}
