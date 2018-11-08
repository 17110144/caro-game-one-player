using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame
{
    static class Program
    {
        public static Pen pen;
        [STAThread]
        static void Main()
        {
            pen = new Pen(Color.Black);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmCoCaro());
        }
    }
}
