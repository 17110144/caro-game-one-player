using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGame
{
    class OCo
    {
        private const int chieuRong = 25;
        private const int chieuCao = 25;

        private int _Dong;
        private int _Cot;
        private Point _ViTri;
        private int _SoHuu;

        public int Dong { get => _Dong; set => _Dong = value; }
        public int Cot { get => _Cot; set => _Cot = value; }
        public Point ViTri { get => _ViTri; set => _ViTri = value; }
        public int SoHuu { get => _SoHuu; set => _SoHuu = value; }

        public static int ChieuRong => chieuRong;

        public static int ChieuCao => chieuCao;

        public OCo(int dong, int cot, Point vitri, int sohuu)
        {
            this.Dong = dong;
            this.Cot = cot;
            this.ViTri = vitri;
            this.SoHuu = sohuu;
        }

    }
}
