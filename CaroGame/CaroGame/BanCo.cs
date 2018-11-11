using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CaroGame
{
    class BanCo
    {
        private int _SoDong;
        private int _SoCot;


        public BanCo()
        {
            _SoDong = 0;
            _SoCot = 0;
        }
        public BanCo(int soDong, int soCot)
        {
            _SoDong = soDong;
            _SoCot = soCot;
        }

        public int SoDong { get => _SoDong; }
        public int SoCot { get => _SoCot; }

        public void VeBanCo(Graphics g)
        {
            for (int i = 0; i <= this.SoCot; i++)
            {
                g.DrawLine(CaroChess.pen, i * OCo.ChieuRong, 0, i * OCo.ChieuRong, _SoDong * OCo.ChieuCao);
            }
            for (int j = 0; j <= this.SoCot; j++)
            {
                g.DrawLine(CaroChess.pen, 0, j * OCo.ChieuCao, SoCot * OCo.ChieuRong, j * OCo.ChieuCao);
            }
        }

        public void VeQuanCo(Graphics g, Point point, TextureBrush mark)
        {
            g.FillEllipse(mark, point.X, point.Y, OCo.ChieuRong, OCo.ChieuCao);
        }
        public void XoaQuanCo(Graphics g,Point point, SolidBrush sb)
        {
            g.FillRectangle(sb, point.X + 1, point.Y + 1, OCo.ChieuRong - 2, OCo.ChieuCao - 2); 
        }
    }
}
