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
    public partial class Frm_Personeller : Form
    {
        public Frm_Personeller()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();

            int sonuc = bll.PERSONELKAYDET(mtbTc.Text, txtPerAdi.Text, txtPerSoyadi.Text,Cinsiyet(rdbErkek,rdbKadin),MedeniHali(rdbEvli,rdbBekar), cmbDogumYeri.Text, dateDogumTarihi.Text, mtbTelefon.Text, cmbGorevTanimi.Text, txtEmail.Text, txtAdres.Text, dateIsGirisTarihi.Text);
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
            return false;
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

        private void Frm_Personeller_Load(object sender, EventArgs e)
        {
            listeDoldur();
            //dataGridView1.Columns["WebAdresi"].Visible = false;
        }
        void listeDoldur()
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            List<Personeller> perListesi = bll.PersonelListele();
            dataGridView1.DataSource = perListesi;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();

            int sonuc = bll.PERSONELGUNCELLE(perID ,mtbTc.Text, txtPerAdi.Text, txtPerSoyadi.Text, Cinsiyet(rdbErkek, rdbKadin).ToString(), MedeniHali(rdbEvli, rdbBekar).ToString(), cmbDogumYeri.Text, dateDogumTarihi.Text, mtbTelefon.Text, cmbGorevTanimi.Text, txtEmail.Text, txtAdres.Text, dateIsGirisTarihi.Text);
            if (sonuc > 0)
            {
                listeDoldur();
                MessageBox.Show("GÜNCELLEME BAŞARILI");
                perID = 0;
            }
            else
            {
                MessageBox.Show("GÜNCELLEME başarısız");
            }
        }
        int perID;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            mtbTc.Text = dataGridView1.CurrentRow.Cells["TC"].Value.ToString();
            txtPerAdi.Text = dataGridView1.CurrentRow.Cells["PersonelAdi"].Value.ToString();
            txtPerSoyadi.Text = dataGridView1.CurrentRow.Cells["PersonelSoyadi"].Value.ToString();   
            cmbDogumYeri.Text = dataGridView1.CurrentRow.Cells["DogumYeri"].Value.ToString();
            dateDogumTarihi.Text = dataGridView1.CurrentRow.Cells["DogumTarihi"].Value.ToString();
            mtbTelefon.Text = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString();
            cmbGorevTanimi.Text = dataGridView1.CurrentRow.Cells["GorevTanimi"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
            //dateIsGirisTarihi.Text = dataGridView1.CurrentRow.Cells["isGirisTarihi"].Value.ToString();
            perID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonellerID"].Value.ToString());

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
