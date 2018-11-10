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
        public frmCoCaro()
        {
            InitializeComponent();
            caroChess = new CaroChess();
            caroChess.KhoiTaoMangOco();
            grs = pnlBanCo.CreateGraphics();

           
        }

        private void frmCoCaro_Load(object sender, EventArgs e)
        {

        }

        private void pnlBanCo_Paint(object sender, PaintEventArgs e)
        {
            caroChess.VeBanCo(grs);
            caroChess.VeLaiQuanCo(grs);
        }

        private void pnlBanCo_MouseClick(object sender, MouseEventArgs e)
        {
            if (!caroChess.SanSang) return;
            caroChess.DanhCo(e.X, e.Y,grs);
            if (caroChess.KiemTraThang())
                caroChess.KetThucTroChoi();
        }

        private void btnPlayervsPlayer_Click(object sender, EventArgs e)
        {
            grs.Clear(pnlBanCo.BackColor);
            caroChess.StartPvsP(grs);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {          
            caroChess.Undo(grs);
        }
    }
}
