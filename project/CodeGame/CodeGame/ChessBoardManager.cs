using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
	//Hàm xử lý bàn cờ caro
	public class ChessBoardManager
	{

		// Properties
		private Panel chessBoard;	//Khai báo Panel bàn cờ

		public Panel ChessBoard	
		{
			get { return chessBoard; }
			set { chessBoard = value; }
		}

		private List<Player> player;		//Khai báo một danh sách người chơi

		public List<Player> Player
		{
			get { return player; }
			set { player = value; }
		}

		private int currentPlayer;          //Biến ghi nhớ người chơi hiện tại 
											//( curentPlayer = 0 : là người chơi thứ nhất, = 1 : người chơi thứ 2)

		public int CurrentPlayer
		{
			get { return currentPlayer; }
			set { currentPlayer = value; }
		}

		private TextBox playerName;			//Chứa đựng tên người chơi, đổi theo currentPlayer

		public TextBox PlayerName
		{
			get { return playerName; }
			set { playerName = value; }
		}

		private PictureBox playerMark;		//Ký hiệu để biết đến lượt ai đánh

		public PictureBox PlayerMark
		{
			get { return playerMark; }
			set { playerMark = value; }
		}

		private List<List<Button>> matrix;  //Khai báo ra 2 List lồng nhau, để chứa dữ liệu cho các button cho dễ xử lý (tương tự Như trên Matrix)

		public List<List<Button>> Matrix
		{
			get { return matrix; }
			set { matrix = value; }
		}



		

		//Xử lý, khởi tạo
		public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox mark)
		{
			this.ChessBoard = chessBoard;
			this.PlayerName = playerName;
			this.PlayerMark = mark;

			this.Player = new List<Player>()
			{
				new Player("Computer", Image.FromFile("X.png")),
				new Player("You", Image.FromFile("O.png"))
			};

			CurrentPlayer = 0;	 //Mặc định người thứ nhất đi trước ( X đi trước )

			ChangePlayer();		//Đổi người
		}

		

		public void DrawChessBoard()
		{
			Matrix = new List<List<Button>>();      //Khởi tạo 2 list lồng nhau


			Button oldButton = new Button()
			{
				Width = 0, Location = new Point(0, 0)   //Khởi tạo nút đầu làm mốc
			};	
			
			//Sử dụng hai vòng lặp lồng nhau để tạo ra bàn cờ, mỗi bàn cờ là một button
			for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)	//Đi hết hàng
			{
				Matrix.Add(new List<Button>());     //Tạo ra một mảng mới để lưu lại

				for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)	//Đi hết cột
				{
					Button btn = new Button()
					{
						Width = Cons.CHESS_WIDTH,		//Tạo ra các nút có chiều rộng là cons.CHESS_WIDTH, chiều cao là cons.CHESS_HEIGHT
						Height = Cons.CHESS_HEIGHT,
						Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y), //Tạo nên button tiếp theo dựa vào oldButton
						BackgroundImageLayout = ImageLayout.Stretch,    //Định dạng lại ảnh cho vừa với PictureBox
						Tag = i.ToString()          //Lưu lại hàng của button

					};

					btn.Click += btn_Click;		//Tạo event Click

					//Thêm button vào bàn phím
					ChessBoard.Controls.Add(btn);

					Matrix[i].Add(btn); //Add tất cả button trên một dòng vào


					oldButton = btn;	//gán Button mới được tạo thành button cũ để tạo ra các button tiếp theo 
				}
				//Hết một hàng, khởi tạo lại hàng mới
				oldButton.Location = new Point(0, oldButton.Location.Y + Cons.CHESS_HEIGHT);
				oldButton.Width = 0;
				oldButton.Height = 0;
			}
		}

		void btn_Click(object sender, EventArgs e)		//Event click cho button
		{
			Button btn = sender as Button;		//Ép kiểu lại với button

			if (btn.BackgroundImage != null)	//Kiểm tra xem button này đã được Click chưa
				return;		//đã được đánh, không được đánh lên nửa

			// Đổi background button theo người đánh
			Mark(btn);

			//Đổi người
			ChangePlayer();

			if (isEndGame(btn))
			{
				EndGame();
			}

		}

		private void EndGame()
		{
			if (CurrentPlayer == 1)
				CurrentPlayer = 0;
			else
				CurrentPlayer = 1;

			MessageBox.Show(player[currentPlayer].Name + " Win!!!", "Chiến thắng!");

		}



		private void Mark(Button btn)
		{
			btn.BackgroundImage = Player[CurrentPlayer].Mark;		//Đổi ký hiệu X O theo người chơi hiện tại.

			if (CurrentPlayer == 1)		//Sau mỗi lần đánh, đổi người chơi.
				CurrentPlayer = 0;
			else
				CurrentPlayer = 1;
		}

		private void ChangePlayer()		///Hàm đổi người chơi
		{
			PlayerName.Text = Player[CurrentPlayer].Name;		//Đổi tên và ký hiệu dựa trên current player

			PlayerMark.Image = Player[CurrentPlayer].Mark;
		}
		private bool isEndGame(Button btn)
		{
			return (isEndHorizontal(btn) || isEndVertical(btn) || isEndPrimary(btn) || isEndSub(btn));
		}

		private Point GetChessPoint(Button btn)     //Lấy tọa độ của button ra
		{
			int vertical = Convert.ToInt32(btn.Tag);    //Chuyển Tag về int, lưu lại vị trí hàng của button
			int horizontal = Matrix[vertical].IndexOf(btn); //lưu lại vị trí cột của button

			Point point = new Point(horizontal, vertical);

			return point;
		}

        //các hàm kiểm tra thắng
		private bool isEndHorizontal(Button btn)
		{
			Point point = GetChessPoint(btn);

			int countLeft = 0;
			for (int i = point.X; i >= 0; i--)
			{
				if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
				{
					countLeft++;
				}
				else
					break;
			}

			int countRight = 0;
			for (int i = point.X + 1; i < Cons.CHESS_BOARD_WIDTH; i++)
			{
				if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
				{
					countRight++;
				}
				else
					break;
			}

			return countLeft + countRight == 5;
		}
		private bool isEndVertical(Button btn)
		{
			Point point = GetChessPoint(btn);

			int countTop = 0;
			for (int i = point.Y; i >= 0; i--)
			{
				if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
				{
					countTop++;
				}
				else
					break;
			}

			int countBottom = 0;
			for (int i = point.Y + 1; i < Cons.CHESS_BOARD_HEIGHT; i++)
			{
				if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
				{
					countBottom++;
				}
				else
					break;
			}

			return countTop + countBottom == 5;
		}
		private bool isEndPrimary(Button btn)
		{
			Point point = GetChessPoint(btn);

			int countTop = 0;
			for (int i = 0; i <= point.X; i++)
			{
				if (point.X - i < 0 || point.Y - i < 0)
					break;

				if (Matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
				{
					countTop++;
				}
				else
					break;
			}

			int countBottom = 0;
			for (int i = 1; i <= Cons.CHESS_BOARD_WIDTH - point.X; i++)
			{
				if (point.Y + i >= Cons.CHESS_BOARD_HEIGHT || point.X + i >= Cons.CHESS_BOARD_WIDTH)
					break;

				if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
				{
					countBottom++;
				}
				else
					break;
			}

			return countTop + countBottom == 5;
		}
		private bool isEndSub(Button btn)
		{
			Point point = GetChessPoint(btn);

			int countTop = 0;
			for (int i = 0; i <= point.X; i++)
			{
				if (point.X + i > Cons.CHESS_BOARD_WIDTH || point.Y - i < 0)
					break;

				if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
				{
					countTop++;
				}
				else
					break;
			}

			int countBottom = 0;
			for (int i = 1; i <= Cons.CHESS_BOARD_WIDTH - point.X; i++)
			{
				if (point.Y + i >= Cons.CHESS_BOARD_HEIGHT || point.X - i < 0)
					break;

				if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
				{
					countBottom++;
				}
				else
					break;
			}

			return countTop + countBottom == 5;
		}
	}
}
