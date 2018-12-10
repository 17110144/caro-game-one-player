using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

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
        public static TextureBrush MarkX;
        public static TextureBrush MarkO;
        public static SolidBrush sbScreen;      //nút hình elip để vẽ đè lên 2 quân cờ khi dùng undo
        private OCo[,] MangOco;
        private BanCo BanCo;

        private STACK<OCo> _Stk;      //Stack tự xây dựng

        private int _LuotDi;
        private bool _SanSang;
        private KETTHUC ketThuc;
        private int _CheDoChoi;
        public static PictureBox p;

        public bool SanSang { get => _SanSang; }
        public int LuotDi { get => _LuotDi; set => _LuotDi = value; }
        public int CheDoChoi { get => _CheDoChoi; set => _CheDoChoi = value; }

        internal STACK<OCo> Stk { get => _Stk; set => _Stk = value; }

        public CaroChess()
        {
            pen = new Pen(Color.Black);
            MarkO = new TextureBrush(Image.FromFile("O.png"));
            MarkX = new TextureBrush(Image.FromFile("X.png"));
            p = new PictureBox();
            sbScreen = new SolidBrush(Color.FromArgb(224, 224, 224)); //nút có màu trùng với nền bàn cờ để chèn lên
            BanCo = new BanCo(20, 20);                                //khởi tạo một bàn cờ 20x20
            MangOco = new OCo[BanCo.SoDong, BanCo.SoCot];                  
            Stk = new STACK<OCo>();                                   //Ngăn sếp chứa các nước đã đi

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
        public bool DanhCo(int MouseX, int MouseY, Graphics g, PictureBox p)
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
                        BanCo.VeQuanCo(g, MangOco[Dong, Cot].ViTri, MarkX);
                        LuotDi = 2;
                        if (CheDoChoi == 2) p.Image = Image.FromFile("picO.png");
                        else p.Image = Image.FromFile("picO.png");
                        break;
                    }
                case 2:
                    {

                        MangOco[Dong, Cot].SoHuu = 2;
                        BanCo.VeQuanCo(g, MangOco[Dong, Cot].ViTri, MarkO);
                        LuotDi = 1;
                        if (CheDoChoi == 2) p.Image = Image.FromFile("picO.png");
                        else p.Image = Image.FromFile("picX.png");
                        break;
                    }
                default:
                    MessageBox.Show("Có lỗi!");
                    break;

            }
            //Lưu vết bước đi
            Stk.Push(MangOco[Dong, Cot]);

            return true;
        }

        public void VeLaiQuanCo(Graphics g)
        {

            for (int i = 0; i < Stk.Count(); i++)
            {
                if (Stk.A[i].SoHuu == 1)
                {
                    BanCo.VeQuanCo(g, Stk.A[i].ViTri, MarkX);
                }
                else if (Stk.A[i].SoHuu == 2)
                {
                    BanCo.VeQuanCo(g, Stk.A[i].ViTri, MarkO);
                }
            }
        }

        //Phương thức khởi động chế độ chơi 2 người
        public void StartPvsP(Graphics g)
        {
            this._SanSang = true;
            Stk = new STACK<OCo>();
            LuotDi = 1;
            CheDoChoi = 1;
            KhoiTaoMangOco();
            VeBanCo(g);
        }

        public void Undo(Graphics g)
        {
            if (CheDoChoi == 1)
            {
                if (Stk.Count() != 0)
                {
                    OCo oco = Stk.Pop();
                    MangOco[oco.Dong, oco.Cot].SoHuu = 0;
                    BanCo.XoaQuanCo(g, oco.ViTri, sbScreen);
                }
            }
            else
            {
                if (Stk.Count() >= 1)
                {
                    OCo oco = Stk.Pop();
                    MangOco[oco.Dong, oco.Cot].SoHuu = 0;
                    BanCo.XoaQuanCo(g, oco.ViTri, sbScreen);
                    OCo oco2 = Stk.Pop();
                    MangOco[oco2.Dong, oco2.Cot].SoHuu = 0;
                    BanCo.XoaQuanCo(g, oco2.ViTri, sbScreen);
                }
            }
        }

        #region Duyệt thắng

        public void KetThucTroChoi()
        {
            switch (ketThuc)
            {
                case KETTHUC.HoaCo:
                    MessageBox.Show("Hòa Cờ!");
                    break;
                case KETTHUC.Player1:
                    MessageBox.Show("Người chơi 1 thắng!");
                    break;
                case KETTHUC.Player2:
                    MessageBox.Show("Người chơi 2 thắng!");
                    break;
                case KETTHUC.COM:
                    MessageBox.Show("Máy thắng!");
                    break;
            }
            Stk.Clear();
            _SanSang = false;

        }

        public bool KiemTraThang()
        {
            if (Stk.Count() == BanCo.SoCot * BanCo.SoDong)
            {
                ketThuc = KETTHUC.HoaCo;
                return true;
            }

            for (int i = 0; i < Stk.Count(); i++)
            {
                if (DuyetDoc(Stk.A[i].Dong, Stk.A[i].Cot, Stk.A[i].SoHuu) || DuyetNgang(Stk.A[i].Dong, Stk.A[i].Cot, Stk.A[i].SoHuu) || DuyetCheoXuoi(Stk.A[i].Dong, Stk.A[i].Cot, Stk.A[i].SoHuu) || DuyetCheoNguoc(Stk.A[i].Dong, Stk.A[i].Cot, Stk.A[i].SoHuu))
                {
                    if (CheDoChoi == 1)
                    {
                        ketThuc = Stk.A[i].SoHuu == 1 ? KETTHUC.Player1 : KETTHUC.Player2;
                    }
                    else
                    {
                        ketThuc = Stk.A[i].SoHuu == 2 ? KETTHUC.Player1 : KETTHUC.COM;
                    }
                    return true;
                }
            }


            return false;
        }

        private bool DuyetDoc(int curDong, int curCot, int curSoHuu)
        {
            if (curDong > BanCo.SoDong - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (MangOco[curDong + Dem, curCot].SoHuu != curSoHuu)
                    return false;
            }
            if (curDong == 0 || curDong + Dem == BanCo.SoDong)
                return true;
            if (MangOco[curDong - 1, curCot].SoHuu == 0 || MangOco[curDong + Dem, curCot].SoHuu == 0)
                return true;
            return false;
        }
        private bool DuyetNgang(int curDong, int curCot, int curSoHuu)
        {
            if (curCot > BanCo.SoCot - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (MangOco[curDong, curCot + Dem].SoHuu != curSoHuu)
                    return false;
            }
            if (curCot == 0 || curCot + Dem == BanCo.SoCot)
                return true;
            if (MangOco[curDong, curCot - 1].SoHuu == 0 || MangOco[curDong, curCot + Dem].SoHuu == 0)
                return true;
            return false;
        }
        private bool DuyetCheoXuoi(int curDong, int curCot, int curSoHuu)
        {
            if (curDong > BanCo.SoDong - 5 || curCot > BanCo.SoCot - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (MangOco[curDong + Dem, curCot + Dem].SoHuu != curSoHuu)
                    return false;
            }
            if (curDong == 0 || curDong + Dem == BanCo.SoDong || curCot == 0 || curCot + Dem == BanCo.SoCot)
                return true;
            if (MangOco[curDong - 1, curCot - 1].SoHuu == 0 || MangOco[curDong + Dem, curCot + Dem].SoHuu == 0)
                return true;
            return false;
        }
        private bool DuyetCheoNguoc(int curDong, int curCot, int curSoHuu)
        {
            if (curDong < 4 || curCot > BanCo.SoCot - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (MangOco[curDong - Dem, curCot + Dem].SoHuu != curSoHuu)
                    return false;
            }
            if (curDong == 4 || curDong == BanCo.SoDong - 1 || curCot == 0 || curCot + Dem == BanCo.SoCot)
                return true;
            if (MangOco[curDong + 1, curCot - 1].SoHuu == 0 || MangOco[curDong - Dem, curCot + Dem].SoHuu == 0)
                return true;
            return false;
        }
        #endregion

        public void StartPvsCom(Graphics g)
        {
            this._SanSang = true;
            Stk = new STACK<OCo>();
            LuotDi = 1;
            CheDoChoi = 2;
            KhoiTaoMangOco();
            VeBanCo(g);
            KhoiDongCom(g);
        }
        #region AI
        private long[] MangDiemTanCong = new long[7] { 0, 9, 54, 162, 1458, 13112, 118008 };
        private long[] MangDiemPhongNgu = new long[7] { 0, 3, 27, 99, 729, 6561, 59049 };

        public void KhoiDongCom(Graphics g)
        {
            if (Stk.Count() == 0)
            {
                //Thiết lập máy đánh trước
                //DanhCo(BanCo.SoDong / 2 * OCo.ChieuCao + 1, BanCo.SoCot / 2 * OCo.ChieuRong + 1, g, p);
                //LuotDi = 2;

                //Thiết lập người đánh trước
                LuotDi = 2;
            }
            else
            {
                OCo oco = TimKiemNuocDi();
                DanhCo(oco.ViTri.X + 1, oco.ViTri.Y + 1, g, p);
                LuotDi = 2;
            }
        }
        private OCo TimKiemNuocDi()
        {
            OCo kq = new OCo();
            long DiemToiUu = 0;
            for (int i = 0; i < BanCo.SoDong; i++)
            {
                for (int j = 0; j < BanCo.SoCot; j++)
                {
                    if (MangOco[i, j].SoHuu == 0)
                    {
                        long DiemTanCong = DiemTC_DuyetDoc(i, j) + DiemTC_DuyetNgang(i, j) + DiemTC_DuyetCheoXuoi(i, j) + DiemTC_DuyetCheoNguoc(i, j);
                        long DiemPhongNgu = DiemPN_DuyetDoc(i, j) + DiemPN_DuyetNgang(i, j) + DiemPN_DuyetCheoXuoi(i, j) + DiemPN_DuyetCheoNguoc(i, j);

                        if (DiemPhongNgu <= DiemTanCong)
                        {
                            if (DiemToiUu <= DiemTanCong)
                            {
                                DiemToiUu = DiemTanCong;
                                kq = new OCo(MangOco[i, j].Dong, MangOco[i, j].Cot, MangOco[i, j].ViTri, MangOco[i, j].SoHuu);
                            }
                        }
                        else
                        {
                            if (DiemToiUu <= DiemPhongNgu)
                            {
                                DiemToiUu = DiemPhongNgu;
                                kq = new OCo(MangOco[i, j].Dong, MangOco[i, j].Cot, MangOco[i, j].ViTri, MangOco[i, j].SoHuu);

                            }
                        }
                    }
                }
            }
            return kq;
        }

        #region Điểm Tấn Công
        private long DiemTC_DuyetDoc(int curDong, int curCot)
        {
            long DiemTong = 0;
            long DiemTC = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && curDong + Dem < BanCo.SoDong; Dem++)
            {
                if (MangOco[curDong + Dem, curCot].SoHuu == 1)
                    SoQuanTa++;
                else if (MangOco[curDong + Dem, curCot].SoHuu == 2)
                {
                    SoQuanDich++;
                    DiemTong -= 9;
                    break;
                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && curDong - Dem >= 0; Dem++)
            {
                if (MangOco[curDong - Dem, curCot].SoHuu == 1)
                    SoQuanTa++;
                else if (MangOco[curDong - Dem, curCot].SoHuu == 2)
                {
                    DiemTong -= 9;
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2) return 0;
            DiemTC += MangDiemTanCong[SoQuanTa];
            DiemTC -= MangDiemTanCong[SoQuanDich];
            DiemTong += DiemTC;
            return DiemTong;
        }
        private long DiemTC_DuyetNgang(int curDong, int curCot)
        {
            long DiemTong = 0;
            long DiemTC = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && curCot + Dem < BanCo.SoCot; Dem++)
            {
                if (MangOco[curDong, curCot + Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (MangOco[curDong, curCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    DiemTong -= 9;
                    break;
                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && curCot - Dem >= 0; Dem++)
            {
                if (MangOco[curDong, curCot - Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (MangOco[curDong, curCot - Dem].SoHuu == 2)
                {
                    DiemTong -= 9;
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2) return 0;
            DiemTC += MangDiemTanCong[SoQuanTa];
            DiemTC -= MangDiemTanCong[SoQuanDich];
            DiemTong += DiemTC;
            return DiemTong;
        }
        private long DiemTC_DuyetCheoXuoi(int curDong, int curCot)
        {
            long DiemTong = 0;
            long DiemTC = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && curCot + Dem < BanCo.SoCot && curDong + Dem < BanCo.SoDong; Dem++)
            {
                if (MangOco[curDong + Dem, curCot + Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (MangOco[curDong + Dem, curCot + Dem].SoHuu == 2)
                {
                    DiemTong -= 9;
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && curCot - Dem >= 0 && curDong - Dem >= 0; Dem++)
            {
                if (MangOco[curDong - Dem, curCot - Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (MangOco[curDong - Dem, curCot - Dem].SoHuu == 2)
                {
                    DiemTong -= 9;
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2) return 0;
            DiemTC += MangDiemTanCong[SoQuanTa];
            DiemTC -= MangDiemPhongNgu[SoQuanDich + 1];
            DiemTong += DiemTC;
            return DiemTong;
        }
        private long DiemTC_DuyetCheoNguoc(int curDong, int curCot)
        {
            long DiemTong = 0;
            long DiemTC = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && curCot + Dem < BanCo.SoCot && curDong - Dem >= 0; Dem++)
            {
                if (MangOco[curDong - Dem, curCot + Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (MangOco[curDong - Dem, curCot + Dem].SoHuu == 2)
                {
                    DiemTong -= 9;
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && curCot - Dem >= 0 && curDong + Dem < BanCo.SoDong; Dem++)
            {
                if (MangOco[curDong + Dem, curCot - Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (MangOco[curDong + Dem, curCot - Dem].SoHuu == 2)
                {
                    DiemTong -= 9;
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2) return 0;
            DiemTC -= MangDiemPhongNgu[SoQuanDich + 1];
            DiemTC += MangDiemTanCong[SoQuanTa];
            DiemTong += DiemTC;
            return DiemTong;
        }
        #endregion


        #region Điểm Phòng Ngự
        private long DiemPN_DuyetDoc(int curDong, int curCot)
        {
            long DiemPN = 0;
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && curDong + Dem < BanCo.SoDong; Dem++)
            {
                if (MangOco[curDong + Dem, curCot].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (MangOco[curDong + Dem, curCot].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && curDong - Dem >= 0; Dem++)
            {
                if (MangOco[curDong - Dem, curCot].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (MangOco[curDong - Dem, curCot].SoHuu == 2)
                {
                    SoQuanDich++;

                }
                else
                    break;
            }
            if (SoQuanDich == 2) return 0;
            DiemPN += MangDiemPhongNgu[SoQuanDich];
            if (SoQuanDich > 0)
                DiemPN -= MangDiemTanCong[SoQuanTa] * 2;
            DiemTong += DiemPN;
            return DiemTong;
        }
        private long DiemPN_DuyetNgang(int curDong, int curCot)
        {
            long DiemPN = 0;
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && curCot + Dem < BanCo.SoCot; Dem++)
            {
                if (MangOco[curDong, curCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (MangOco[curDong, curCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;

                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && curCot - Dem >= 0; Dem++)
            {
                if (MangOco[curDong, curCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (MangOco[curDong, curCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            if (SoQuanTa == 2) return 0;

            DiemPN += MangDiemPhongNgu[SoQuanDich];
            if (SoQuanDich > 0)
                DiemPN -= MangDiemTanCong[SoQuanTa] * 2;
            DiemTong += DiemPN;
            return DiemTong;
        }
        private long DiemPN_DuyetCheoXuoi(int curDong, int curCot)
        {
            long DiemPN = 0;
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && curCot + Dem < BanCo.SoCot && curDong + Dem < BanCo.SoDong; Dem++)
            {
                if (MangOco[curDong + Dem, curCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (MangOco[curDong + Dem, curCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && curCot - Dem >= 0 && curDong - Dem >= 0; Dem++)
            {
                if (MangOco[curDong - Dem, curCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (MangOco[curDong - Dem, curCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            if (SoQuanTa == 2) return 0;
            DiemPN += MangDiemPhongNgu[SoQuanDich];
            if (SoQuanDich > 0)
                DiemPN -= MangDiemTanCong[SoQuanTa] * 2;
            DiemTong += DiemPN;
            return DiemTong;
        }
        private long DiemPN_DuyetCheoNguoc(int curDong, int curCot)
        {
            long DiemPN = 0;
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && curCot + Dem < BanCo.SoCot && curDong - Dem >= 0; Dem++)
            {
                if (MangOco[curDong - Dem, curCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (MangOco[curDong - Dem, curCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            for (int Dem = 1; Dem < 6 && curCot - Dem >= 0 && curDong + Dem < BanCo.SoDong; Dem++)
            {
                if (MangOco[curDong + Dem, curCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (MangOco[curDong + Dem, curCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            if (SoQuanTa == 2) return 0;
            DiemPN += MangDiemPhongNgu[SoQuanDich];
            if (SoQuanDich > 0)
                DiemPN -= MangDiemTanCong[SoQuanTa] * 2;
            DiemTong += DiemPN;
            return DiemTong;
        }
        #endregion


        #endregion
    }
}
