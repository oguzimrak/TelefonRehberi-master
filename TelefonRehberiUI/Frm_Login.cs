using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelefonRehberiBLL;

namespace TelefonRehberiUI
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }
        BusinessLogicLayer bll = new BusinessLogicLayer();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            int returndeger = bll.SistemeGiris(txtKullaniciAdi.Text, txtSifre.Text);
            if (returndeger>0)
            {
                Frm_Menu frm = new Frm_Menu();
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");
            }
        }
    }
}
