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
using TelefonRehberiEntities;


namespace TelefonRehberiUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            int sonuc = bll.VERIKAYDET(txtAdi.Text,txtSoyadi.Text,txtEmail.Text,txtWebadres.Text,mtbcepTel1.Text,mtbcepTel2.Text,mtbevTel1.Text,mtbevTel2.Text,mtbisTel1.Text,mtbisTel2.Text,DateTime.Now.ToString(),txtAciklama.Text,txtAdres.Text);
            if (sonuc>0)
            {
                listeDoldur();
                MessageBox.Show("Rehbere başarılı bir şekilde eklendi");
            }
            else
            {
                MessageBox.Show("Kayıt başarısız");
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            int sonucGuncel = bll.VERIGUNCELLE(ID,txtAdi.Text, txtSoyadi.Text, txtEmail.Text, txtWebadres.Text, mtbcepTel1.Text, mtbcepTel2.Text, mtbevTel1.Text, mtbevTel2.Text, mtbisTel1.Text, mtbisTel2.Text, txtAciklama.Text, txtAdres.Text);
            if (sonucGuncel > 0)
            {
                listeDoldur();
                MessageBox.Show("GÜNCELLEME BAŞARILI!!");
                ID = 0;

            }
            else
            {
                MessageBox.Show("GÜNCELLEME başarısız");
            }
        }
        int ID;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtAdi.Text = dataGridView1.CurrentRow.Cells["Adi"].Value.ToString();
            txtSoyadi.Text = dataGridView1.CurrentRow.Cells["Soyadi"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
            txtWebadres.Text = dataGridView1.CurrentRow.Cells["WebAdresi"].Value.ToString();
            mtbcepTel1.Text = dataGridView1.CurrentRow.Cells["CepNo1"].Value.ToString();
            mtbcepTel2.Text = dataGridView1.CurrentRow.Cells["CepNo2"].Value.ToString();
            mtbevTel1.Text = dataGridView1.CurrentRow.Cells["EvTelefonu1"].Value.ToString();
            mtbevTel2.Text = dataGridView1.CurrentRow.Cells["EvTelefonu2"].Value.ToString();
            mtbisTel1.Text = dataGridView1.CurrentRow.Cells["IsTelefonu1"].Value.ToString();
            mtbisTel2.Text = dataGridView1.CurrentRow.Cells["IsTelefonu2"].Value.ToString();
            txtAciklama.Text = dataGridView1.CurrentRow.Cells["Aciklama"].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
            ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["KisilerID"].Value.ToString());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listeDoldur();
            dataGridView1.Columns["WebAdresi"].Visible = false;
        }
        void listeDoldur()
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            List<RehberKayit> rListesi = bll.RehberiListele();
            dataGridView1.DataSource = rListesi;
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (Control item in tabPage1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            int sonuc = bll.RehberSil(ID);
            if (sonuc>0)
            {
                listeDoldur();
                MessageBox.Show("Kayıt silindi!");
                ID = 0;

            }
            else if (ID==0)
            {
                MessageBox.Show("Seçim yapmadınız!!!!");
            }
            else
            {
                MessageBox.Show("Silme başarısız!");
            }
        }
    }
}
