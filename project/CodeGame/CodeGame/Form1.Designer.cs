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
            // 
            // txbPlayerName
            // 
            this.txbPlayerName.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.txbPlayerName.Location = new System.Drawing.Point(848, 50);
            this.txbPlayerName.Name = "txbPlayerName";
            this.txbPlayerName.Size = new System.Drawing.Size(72, 20);
            this.txbPlayerName.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 609);
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
    }
}

