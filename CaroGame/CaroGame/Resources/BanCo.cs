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
        public BanCo(int soDong,int soCot)
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
                g.DrawLine(Program.pen, i * OCo._ChieuRong, 0, i * OCo._ChieuRong, _SoDong * OCo._ChieuCao);
            }
            for (int j = 0; j <= this.SoCot; j++)
            {
                g.DrawLine(Program.pen, 0, j * OCo._ChieuCao, SoCot * OCo._ChieuRong, j * OCo._ChieuCao);
            }
        }
    }
}
