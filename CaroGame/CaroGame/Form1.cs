using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame
{
    public partial class frmCoCaro : Form
    {
        private CaroChess caroChess;
        private Graphics grs;
        private PictureBox p;

        public frmCoCaro()
        {
            InitializeComponent();
            caroChess = new CaroChess();
            caroChess.KhoiTaoMangOco();
            grs = pnlBanCo.CreateGraphics();
            p = pctbMark;
           
        }

        private void frmCoCaro_Load(object sender, EventArgs e)
        {
            grs.Clear(pnlBanCo.BackColor);
        }

        private void pnlBanCo_Paint(object sender, PaintEventArgs e)
        {
            caroChess.VeBanCo(grs);
            caroChess.VeLaiQuanCo(grs);
        }

        private void pnlBanCo_MouseClick(object sender, MouseEventArgs e)
        {
            if (!caroChess.SanSang) return;
            if(caroChess.DanhCo(e.X, e.Y,grs,p))
            {
                if (caroChess.KiemTraThang())
                    caroChess.KetThucTroChoi();
                else
                {
                    if (caroChess.CheDoChoi == 2)
                    {
                        caroChess.KhoiDongCom(grs);
                        if (caroChess.KiemTraThang())
                            caroChess.KetThucTroChoi();
                    }
                }
            }
        }

        private void btnPlayervsPlayer_Click(object sender, EventArgs e)
        {
            grs.Clear(pnlBanCo.BackColor);
            caroChess.StartPvsP(grs);
        }
        private void btnPlayervsCom_Click(object sender, EventArgs e)
        {
            grs.Clear(pnlBanCo.BackColor);
            caroChess.StartPvsCom(grs);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {           
            caroChess.Undo(grs);
            if(caroChess.CheDoChoi == 1)
            {
                if (caroChess.LuotDi == 1)
                {
                    caroChess.LuotDi = 2;
                    pctbMark.Image = Image.FromFile("picO.png");
                }
                else
                {
                    caroChess.LuotDi = 1;
                    pctbMark.Image = Image.FromFile("picX.png");
                }
            }


        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            grs.Clear(pnlBanCo.BackColor);
        }

    }
}
