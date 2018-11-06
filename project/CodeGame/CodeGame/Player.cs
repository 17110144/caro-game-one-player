using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
	public class Player
	{
		private string name;    // Tên người chơi

		public string Name	
		{
			get { return name; }
			set { name = value; }
		}

		private Image mark;		//Ký hiệu: X or O

		public Image Mark
		{
			get { return mark; }
			set { mark = value; }
		}

		public Player(string name, Image mark)		//Hàm khởi tạo 1 player
		{
			this.Name = name;
			this.Mark = mark;
		}
	}
}
