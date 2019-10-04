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
	public partial class SnakeField : Form
	{ 
		List<BodyElement> body = new List<BodyElement>();
		List<Point> change_direction_points = new List<Point>();
		int start_x = 1,
			start_y = 1,
			size_const = 22,
			field_size = 15,
			score = 0,
			speed = 350;
		byte current_direction = 0;
		bool theme = false;
		float time_counter = 0.0f;
		Food food;
		Color snake_color;

		public SnakeField()
		{
			field_size = Settings.FieldSize;
			size_const = Settings.SizeConst;
			speed = Settings.Speed;
			theme = Settings.Theme;
			snake_color = Settings.SnakeColor;

			int size = field_size * size_const;

			InitializeComponent();

			timer1.Interval = speed;

			this.StartPosition = FormStartPosition.CenterScreen;
			this.FormBorderStyle = FormBorderStyle.None;
			this.Size = new Size(size, size);
			this.FormBorderStyle = FormBorderStyle.Sizable;

			if(theme == false)
			{
				this.BackColor = Color.GhostWhite;
				label1.BackColor = Color.GhostWhite;
				label1.ForeColor = Color.LightGray;
			}
			else if(theme == true)
			{
				this.BackColor = Color.FromArgb(50, 50, 65);
				label1.BackColor = Color.FromArgb(50, 50, 65);
				label1.ForeColor = Color.LightGray;
			}

			Font font = new Font("Consolas", (float)(field_size * size_const) * 0.5f);
			label1.Font = font;
			label1.Text = Convert.ToString(score);
			Point label_position = new Point((this.Width - label1.Width) / 2, (this.Height - label1.Height) / 2);
			label1.Location = label_position;


			BodyElement head = new BodyElement(size_const, this, new Point(start_x * size_const, start_y * size_const), snake_color);
			head.Direction = current_direction;
			body.Add(head);

			food = new Food(size_const, field_size, field_size, this);
			food.Spawn(body);
		}
		private void SnakeField_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Right && body[0].Direction != 2)
			{
				current_direction = 0;
				CheckMove();
			}
			else if (e.KeyCode == Keys.Down && body[0].Direction != 3)
			{
				current_direction = 1;
				CheckMove();
			}
			else if (e.KeyCode == Keys.Left && body[0].Direction != 0)
			{
				current_direction = 2;
				CheckMove();
			}
			else if (e.KeyCode == Keys.Up && body[0].Direction != 1)
			{
				current_direction = 3;
				CheckMove();
			}
		}

		private void CheckMove()
		{
			Point point = new Point(body[0].Position.X, body[0].Position.Y);
			change_direction_points.Add(point);
		}

		private void CheckFoodColision()
		{
			if(body[0].Position.X == food.Position.X && body[0].Position.Y == food.Position.Y)
			{
				Point new_part_pos = new Point();
				BodyElement last = body.Last();

				if(last.Direction == 0)
				{
					new_part_pos.X = last.Position.X - size_const;
					new_part_pos.Y = last.Position.Y;
				}
				else if(last.Direction == 1)
				{
					new_part_pos.X = last.Position.X;
					new_part_pos.Y = last.Position.Y - size_const;
				}
				else if(last.Direction == 2)
				{
					new_part_pos.X = last.Position.X + size_const;
					new_part_pos.Y = last.Position.Y;
				}
				else if(last.Direction == 3)
				{
					new_part_pos.X = last.Position.X;
					new_part_pos.Y = last.Position.Y + size_const;
				}

				BodyElement new_part = new BodyElement(size_const, this, new_part_pos, snake_color);
				new_part.Direction = last.Direction;
				body.Add(new_part);

				score++;

				food.Spawn(body);
			}
		}
		private void ChangeDirectionChecker()
		{
			for(int i = body.Count - 1; i > 0; i--)
			{
				for(int j = 0; j < change_direction_points.Count; j++)
				{
					if(body[i].Position.X == change_direction_points[j].X && body[i].Position.Y == change_direction_points[j].Y)
					{
						body[i].Direction = body[i - 1].Direction;
						if(i == body.Count - 1)
						{
							change_direction_points.RemoveAt(j);
							break;
						}
					}
				}
			}
		}

		private void EndGameForm()
		{
			timer1.Stop();
			LoseForm lf = new LoseForm(score, time_counter);
			lf.ShowDialog();
			this.Close();
		}

		private void Die()
		{
			for(int i = 1; i < body.Count; i++)
			{
				if(body[0].Position.X == body[i].Position.X && body[0].Position.Y == body[i].Position.Y)
				{
					EndGameForm();
				}
			}
		}

		private void OutsideCheck()
		{
			int size = field_size * size_const;

			if(body[0].Position.X >= size)
			{
				EndGameForm();
			}
			else if (body[0].Position.X < 0)
			{
				EndGameForm();
			}
			else if (body[0].Position.Y >= size)
			{
				EndGameForm();
			}
			else if (body[0].Position.Y < 0)
			{
				EndGameForm();
			}
			
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			time_counter += speed / 100.0f;

			if (score + 1 == field_size * field_size)
			{
				EndGameForm();
			}

			CheckFoodColision();

			label1.Text = Convert.ToString(score);
			Point label_position = new Point((this.Width - label1.Width) / 2, (this.Height - label1.Height) / 2);
			label1.Location = label_position;
			label1.SendToBack();
			body[0].Direction = current_direction;


			for (int i = body.Count - 1; i >= 0; i--)
			{
				body[i].Move();
			}

			Die();
			OutsideCheck();
			ChangeDirectionChecker();
		}
	}
}
