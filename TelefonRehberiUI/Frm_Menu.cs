using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonRehberiUI
{
    public partial class Frm_Menu : Form
    {
        public Frm_Menu()
        {
            InitializeComponent();
        }

        private void rehberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frmRehber = new Form1();
            frmRehber.MdiParent = this;
            frmRehber.Show();
        }

        private void personellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Personeller frmper = new Frm_Personeller();
            frmper.MdiParent = this;
            frmper.Show();
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Musteriler frmMus = new Frm_Musteriler();
            frmMus.MdiParent = this;
            frmMus.Show();
        }
    }
}
