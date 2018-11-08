using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame
{
    class CaroChess
    {
        public static Pen pen;
        public static SolidBrush sbWhite;
        public static SolidBrush sbBlack;
        private OCo[,] _MangOco;
        private BanCo _BanCo;
        private List<OCo> _List_CacNuocDaDi;
        private int _LuotDi;

        internal OCo[,] MangOco { get => _MangOco; set => _MangOco = value; }
        internal BanCo BanCo { get => _BanCo; set => _BanCo = value; }
        internal List<OCo> List_CacNuocDaDi { get => _List_CacNuocDaDi; set => _List_CacNuocDaDi = value; }
        public int LuotDi { get => _LuotDi; set => _LuotDi = value; }

        public CaroChess()
        {
            pen = new Pen(Color.Black);
            sbWhite = new SolidBrush(Color.White);
            sbBlack = new SolidBrush(Color.Black);
            BanCo = new BanCo(20, 20);
            MangOco = new OCo[BanCo.SoDong, BanCo.SoCot];
            List_CacNuocDaDi = new List<OCo>();
            LuotDi = 1;
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

            if (MangOco[Dong, Cot].SoHuu != 0)
                return false;

            switch(LuotDi)
            {
                case 1:
                    {
                        MangOco[Dong, Cot].SoHuu = 1;
                        BanCo.VeQuanCo(g, MangOco[Dong, Cot].ViTri, sbBlack);
                        LuotDi = 2;
                        break;
                    }
                case 2:
                    {
                        MangOco[Dong, Cot].SoHuu = 2;
                        BanCo.VeQuanCo(g, MangOco[Dong, Cot].ViTri, sbWhite);
                        LuotDi = 1;
                        break;
                    }
                default:
                    MessageBox.Show("Có lỗi!");
                    break;

            }
                      
            List_CacNuocDaDi.Add(MangOco[Dong, Cot]);

            return true;
        }
        public void VeLaiQuanCo(Graphics g)
        {
            foreach(OCo oco in List_CacNuocDaDi)
            {
                if(oco.SoHuu==1)
                {
                    BanCo.VeQuanCo(g, oco.ViTri, sbBlack);
                }
                else if(oco.SoHuu == 2 )
                {
                    BanCo.VeQuanCo(g, oco.ViTri, sbWhite);
                }
            }
        }
    }
}
