using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame
{
    public enum KETTHUC
    {
        HoaCo,
        Player1,
        Player2,
        COM        
    }
    class CaroChess
    {
        public static Pen pen;
        public static SolidBrush sbWhite;
        public static SolidBrush sbBlack;
        public static SolidBrush sbScreen;      //nút hình elip để vẽ đè lên 2 quân cờ khi dùng undo
        private OCo[,] MangOco;
        private BanCo BanCo;
        private Stack<OCo> stk_CacNuocDaDi;
        private int LuotDi;
        private bool _SanSang;
        private KETTHUC ketThuc;


        public bool SanSang { get => _SanSang; }

        public CaroChess()
        {
            pen = new Pen(Color.Black);
            sbWhite = new SolidBrush(Color.White);
            sbBlack = new SolidBrush(Color.Black);
            sbScreen = new SolidBrush(Color.FromArgb(0, 192, 100));
            BanCo = new BanCo(20, 20);
            MangOco = new OCo[BanCo.SoDong, BanCo.SoCot];
            stk_CacNuocDaDi = new Stack<OCo>();
            LuotDi = 1;
        }
        public void VeBanCo(Graphics g)
        {
            BanCo.VeBanCo(g);
        }

        public void KhoiTaoMangOco()
        {
            for (int i = 0; i < BanCo.SoDong; i++)
            {
                for (int j = 0; j < BanCo.SoCot; j++)
                {
                    MangOco[i, j] = new OCo(i, j, new Point(j * OCo.ChieuRong, i * OCo.ChieuCao), 0);
                }
            }
        }
        public bool DanhCo(int MouseX, int MouseY, Graphics g)
        {
            if (MouseX % OCo.ChieuRong == 0 || MouseY % OCo.ChieuCao == 0) return false;     //không cho người chơi đánh ngay chính đường biên

            int Cot = MouseX / OCo.ChieuRong;
            int Dong = MouseY / OCo.ChieuCao;

            if (MangOco[Dong, Cot].SoHuu != 0)
                return false;

            switch (LuotDi)
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
            
            stk_CacNuocDaDi.Push(MangOco[Dong, Cot]);

            return true;
        }
        public void VeLaiQuanCo(Graphics g)
        {
            foreach (OCo oco in stk_CacNuocDaDi)
            {
                if (oco.SoHuu == 1)
                {
                    BanCo.VeQuanCo(g, oco.ViTri, sbBlack);
                }
                else if (oco.SoHuu == 2)
                {
                    BanCo.VeQuanCo(g, oco.ViTri, sbWhite);
                }
            }
        }

        //Phương thức khởi động chế độ chơi 2 người
        public void StartPvsP(Graphics g)
        {
            this._SanSang = true;
            stk_CacNuocDaDi = new Stack<OCo>();          
            KhoiTaoMangOco();
            VeBanCo(g);
        }

        public void Undo(Graphics g)
        {   
            if(stk_CacNuocDaDi.Count != 0)
            {
                OCo oco = stk_CacNuocDaDi.Pop();
                MangOco[oco.Dong, oco.Cot].SoHuu = 0;
                BanCo.XoaQuanCo(g, oco.ViTri, sbScreen);              
            }                    
        }    
    }
}
