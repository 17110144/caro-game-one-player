namespace GameCaro
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.pnlChessBoard = new System.Windows.Forms.Panel();
            this.pctbMark = new System.Windows.Forms.PictureBox();
            this.txbPlayerName = new System.Windows.Forms.TextBox();
            this.btnUnDo = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctbMark)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChessBoard
            // 
            this.pnlChessBoard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChessBoard.Location = new System.Drawing.Point(12, 12);
            this.pnlChessBoard.Name = "pnlChessBoard";
            this.pnlChessBoard.Size = new System.Drawing.Size(731, 595);
            this.pnlChessBoard.TabIndex = 0;
            // 
            // pctbMark
            // 
            this.pctbMark.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pctbMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctbMark.Location = new System.Drawing.Point(749, 76);
            this.pctbMark.Name = "pctbMark";
            this.pctbMark.Size = new System.Drawing.Size(296, 285);
            this.pctbMark.TabIndex = 2;
            this.pctbMark.TabStop = false;
            this.pctbMark.Click += new System.EventHandler(this.pctbMark_Click);
            // 
            // txbPlayerName
            // 
            this.txbPlayerName.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.txbPlayerName.Location = new System.Drawing.Point(848, 50);
            this.txbPlayerName.Name = "txbPlayerName";
            this.txbPlayerName.Size = new System.Drawing.Size(72, 20);
            this.txbPlayerName.TabIndex = 0;
            // 
            // btnUnDo
            // 
            this.btnUnDo.AccessibleName = "";
            this.btnUnDo.Location = new System.Drawing.Point(758, 390);
            this.btnUnDo.Name = "btnUnDo";
            this.btnUnDo.Size = new System.Drawing.Size(287, 76);
            this.btnUnDo.TabIndex = 3;
            this.btnUnDo.Text = "UnDo";
            this.btnUnDo.UseVisualStyleBackColor = true;
            this.btnUnDo.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(758, 496);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(287, 76);
            this.btnNewGame.TabIndex = 4;
            this.btnNewGame.Text = "NEW GAME";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1051, 609);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnUnDo);
            this.Controls.Add(this.txbPlayerName);
            this.Controls.Add(this.pctbMark);
            this.Controls.Add(this.pnlChessBoard);
            this.Name = "Form1";
            this.Text = "Game Caro LAN";
            ((System.ComponentModel.ISupportInitialize)(this.pctbMark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlChessBoard;
		private System.Windows.Forms.PictureBox pctbMark;
		private System.Windows.Forms.TextBox txbPlayerName;
        private System.Windows.Forms.Button btnUnDo;
        private System.Windows.Forms.Button btnNewGame;
    }
}

