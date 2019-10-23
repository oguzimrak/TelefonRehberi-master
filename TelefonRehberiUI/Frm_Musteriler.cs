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
    public partial class Frm_Musteriler : Form
    {
        public Frm_Musteriler()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)        
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();

            int sonuc = bll.MUSTERIKAYDET(txtPerAdi.Text, txtPerSoyadi.Text, Cinsiyet(rdbErkek, rdbKadin), MedeniHali(rdbEvli, rdbBekar), txtSirketAdi.Text, mtbTelefon.Text,txtEmail.Text,  datekayitTarihi.Text, Convert.ToInt32(txtSayisi.Text), Convert.ToInt32(txtFiyat.Text), txtAdres.Text);
            if (sonuc > 0)
            {
                MessageBox.Show("Rehbere başarılı bir şekilde eklendi");
            }
            else
            {
                MessageBox.Show("Kayıt başarısız");
            }
        }
        bool Cinsiyet(RadioButton rdb_erkek, RadioButton rdb_kadin)
        {
            if (rdb_erkek.Checked == true)
            {
                return true;
            }
            if (rdb_kadin.Checked == true)
            {
                return true;
            }
            return true;
        }
        bool MedeniHali(RadioButton rdb_evli, RadioButton rdb_bekar)
        {
            if (rdb_evli.Checked == true)
            {
                return true;
            }
            if (rdb_bekar.Checked == true)
            {
                return true;
            }
            return false;
        }
        int musID;
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();

            int sonuc = bll.MUSTERIGUNCELLE(musID, txtPerAdi.Text, txtPerSoyadi.Text, Cinsiyet(rdbErkek, rdbKadin), MedeniHali(rdbEvli, rdbBekar), txtSirketAdi.Text ,mtbTelefon.Text, txtEmail.Text, int.Parse(txtSayisi.Text), decimal.Parse(txtFiyat.Text), txtAdres.Text);
            if (sonuc > 0)
            {
                listeDoldur();
                MessageBox.Show("GÜNCELLEME BAŞARILI");
                musID = 0;
            }
            else
            {
                MessageBox.Show("GÜNCELLEME başarısız");
            }
        }
        void listeDoldur()
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            List<Musteriler> musListesi = bll.MusteriListele();
            dataGridView1.DataSource = musListesi;
        }

        private void Frm_Musteriler_Load(object sender, EventArgs e)
        {
            listeDoldur();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtPerAdi.Text = dataGridView1.CurrentRow.Cells["MusteriAdi"].Value.ToString();
            txtPerSoyadi.Text = dataGridView1.CurrentRow.Cells["MusteriSoyadi"].Value.ToString();
            txtSirketAdi.Text = dataGridView1.CurrentRow.Cells["SirketAdi"].Value.ToString();
            mtbTelefon.Text = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
            txtSayisi.Text = dataGridView1.CurrentRow.Cells["Sayisi"].Value.ToString();
            txtFiyat.Text = dataGridView1.CurrentRow.Cells["Fiyat"].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
            //dateIsGirisTarihi.Text = dataGridView1.CurrentRow.Cells["isGirisTarihi"].Value.ToString();
            musID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MusterilerID"].Value.ToString());

            bool cins_sonuc = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Cinsiyet"].Value.ToString());
            if (cins_sonuc)
            {
                rdbErkek.Checked = true;
            }
            else
            {
                rdbKadin.Checked = true;
            }
            bool cins_sonuc2 = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["MedeniHali"].Value.ToString());
            if (cins_sonuc)
            {
                rdbBekar.Checked = true;
            }
            else
            {
                rdbEvli.Checked = true;
            }
        }
    }
}
