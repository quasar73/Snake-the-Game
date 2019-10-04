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
	class Settings
	{
		public static Color SnakeColor
		{
			get;
			set;
		}
		public static Color FoodColor
		{
			get;
			set;
		}
		public static int SizeConst
		{
			get;
			set;
		}
		public static int FieldSize
		{
			get;
			set;
		}
		public static int Speed
		{
			get;
			set;
		}
		public static bool Theme
		{
			get;
			set;

		}
	}
}
