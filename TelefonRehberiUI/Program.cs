using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonRehberiUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new Frm_Personeller());
            //Application.Run(new Frm_Musteriler());
            //Application.Run(new Frm_Menu());
            Application.Run(new Frm_Login());
        }
    }
}
