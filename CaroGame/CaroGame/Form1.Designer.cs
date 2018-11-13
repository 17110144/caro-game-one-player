namespace CaroGame
{
    partial class frmCoCaro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCoCaro));
            this.btnPlayervsPlayer = new System.Windows.Forms.Button();
            this.btnPlayervsCom = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.pnlBanCo = new System.Windows.Forms.Panel();
            this.pctbMark = new System.Windows.Forms.PictureBox();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctbMark)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlayervsPlayer
            // 
            this.btnPlayervsPlayer.BackColor = System.Drawing.Color.White;
            this.btnPlayervsPlayer.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayervsPlayer.Location = new System.Drawing.Point(25, 426);
            this.btnPlayervsPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlayervsPlayer.Name = "btnPlayervsPlayer";
            this.btnPlayervsPlayer.Size = new System.Drawing.Size(185, 52);
            this.btnPlayervsPlayer.TabIndex = 0;
            this.btnPlayervsPlayer.Text = "P vs P";
            this.btnPlayervsPlayer.UseVisualStyleBackColor = false;
            this.btnPlayervsPlayer.Click += new System.EventHandler(this.btnPlayervsPlayer_Click);
            // 
            // btnPlayervsCom
            // 
            this.btnPlayervsCom.BackColor = System.Drawing.Color.White;
            this.btnPlayervsCom.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayervsCom.Location = new System.Drawing.Point(27, 510);
            this.btnPlayervsCom.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlayervsCom.Name = "btnPlayervsCom";
            this.btnPlayervsCom.Size = new System.Drawing.Size(183, 48);
            this.btnPlayervsCom.TabIndex = 1;
            this.btnPlayervsCom.Text = "P vs Com";
            this.btnPlayervsCom.UseVisualStyleBackColor = false;
            this.btnPlayervsCom.Click += new System.EventHandler(this.btnPlayervsCom_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.White;
            this.btnUndo.Font = new System.Drawing.Font("Cambria", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.ForeColor = System.Drawing.Color.Black;
            this.btnUndo.Location = new System.Drawing.Point(25, 346);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(4);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(185, 54);
            this.btnUndo.TabIndex = 4;
            this.btnUndo.Text = "UNDO";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // pnlBanCo
            // 
            this.pnlBanCo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlBanCo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlBanCo.Location = new System.Drawing.Point(233, 6);
            this.pnlBanCo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBanCo.Name = "pnlBanCo";
            this.pnlBanCo.Size = new System.Drawing.Size(670, 618);
            this.pnlBanCo.TabIndex = 5;
            this.pnlBanCo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBanCo_Paint);
            this.pnlBanCo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlBanCo_MouseClick);
            // 
            // pctbMark
            // 
            this.pctbMark.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pctbMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctbMark.Location = new System.Drawing.Point(27, 64);
            this.pctbMark.Name = "pctbMark";
            this.pctbMark.Size = new System.Drawing.Size(183, 176);
            this.pctbMark.TabIndex = 7;
            this.pctbMark.TabStop = false;
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.White;
            this.btnNewGame.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.Location = new System.Drawing.Point(27, 577);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(85, 38);
            this.btnNewGame.TabIndex = 8;
            this.btnNewGame.Text = "Chơi Mới";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.White;
            this.btnQuit.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(129, 578);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(81, 37);
            this.btnQuit.TabIndex = 9;
            this.btnQuit.Text = "Thoát";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // frmCoCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(915, 639);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.pctbMark);
            this.Controls.Add(this.pnlBanCo);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnPlayervsCom);
            this.Controls.Add(this.btnPlayervsPlayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCoCaro";
            this.Text = "Game Caro";
            this.Load += new System.EventHandler(this.frmCoCaro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctbMark)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlayervsPlayer;
        private System.Windows.Forms.Button btnPlayervsCom;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Panel pnlBanCo;
        private System.Windows.Forms.PictureBox pctbMark;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnQuit;
    }
}

