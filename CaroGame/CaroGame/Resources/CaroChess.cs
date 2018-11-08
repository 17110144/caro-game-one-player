using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGame
{
    class CaroChess
    {
        public static Pen pen;
        public static SolidBrush sbWhite;
        public static SolidBrush sbBlack;

        private OCo[,] _MangOco;
        private BanCo _BanCo;

        internal OCo[,] MangOco { get => _MangOco; set => _MangOco = value; }
        internal BanCo BanCo { get => _BanCo; set => _BanCo = value; }

        public CaroChess()
        {
            pen = new Pen(Color.Black);
            sbWhite = new SolidBrush(Color.White);
            sbBlack = new SolidBrush(Color.Black);
            BanCo = new BanCo(20, 20);
            MangOco = new OCo[BanCo.SoDong, BanCo.SoCot];
        }
        public void VeBanCo(Graphics g)
        {
            BanCo.VeBanCo(g);
        }

        public void KhoiTaoMangOco()
        {
            for(int i=0;i < BanCo.SoDong;i++)
            {
                for(int j=0;j<BanCo.SoCot; j++)
                {
                    MangOco[i,j]=new OCo(i,j,new Point(j*OCo.ChieuRong,i*OCo.ChieuCao),0);
                }
            }
        } 
        public bool DanhCo(int MouseX,int MouseY, Graphics g)
        {
            if (MouseX % OCo.ChieuRong == 0 || MouseY % OCo.ChieuCao == 0) return false;     //không cho người chơi đánh ngay chính đường biên
            int Cot = MouseX / OCo.ChieuRong;
            int Dong = MouseY / OCo.ChieuCao;          
            BanCo.VeQuanCo(g, MangOco[Dong, Cot].ViTri, sbBlack);
            return true;
        }
    }
}
