using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberiEntities;

namespace TelefonRehberiDLL
{
    public class DatabaseLogicLayer
    {
        //bu kısım veritabanı işlemleri yapmak için kullanılacaktır
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter reader;
        int returnValues=0;

        //ctor +tab0yapıcı metot
        public DatabaseLogicLayer()
        {
            //yapıcı metot
            //con = new SqlConnection("Data Source=304-L12;Initial Catalog=TelefonRehberiDB;User ID=sa;Password=1234");
            con = new SqlConnection("Data Source=304-L12;Initial Catalog=TelefonRehberiDB;User ID=sa;Password=1234");
            //BaglantiAcKapat();
        }

        public void BaglantiAcKapat()
        {
            if (con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                con.Close();
            }
        }
        public int kaydet(RehberKayit R)
        {
            try
            {
                cmd = new SqlCommand("insert into Kisiler(Adi,Soyadi,Email,WebAdresi,CepNo1,CepNo2,EvTelefonu1,EvTelefonu2,IsTelefonu1,IsTelefonu2,KayitTarihi,Aciklama,Adres)values(@adi, @soyadi, @email, @webadres, @cep1, @cep2, @ev1,@ev2, @is1, @is2, @kayit_tarihi, @aciklama, @adres)",con);
                cmd.Parameters.AddWithValue("@adi", R.Adi);
                cmd.Parameters.AddWithValue("@soyadi", R.Soyadi);
                cmd.Parameters.AddWithValue("@email", R.Email);
                cmd.Parameters.AddWithValue("@webadres", R.WebAdresi);
                cmd.Parameters.AddWithValue("@cep1", R.CepNo1);
                cmd.Parameters.AddWithValue("@cep2", R.CepNo2);
                cmd.Parameters.AddWithValue("@ev1", R.EvTelefonu1);
                cmd.Parameters.AddWithValue("@ev2", R.EvTelefonu2);
                cmd.Parameters.AddWithValue("@is1", R.IsTelefonu1);
                cmd.Parameters.AddWithValue("@is2", R.IsTelefonu2);
                cmd.Parameters.AddWithValue("@kayit_tarihi", SqlDbType.DateTime).Value=R.KayitTarihi;
                cmd.Parameters.AddWithValue("@aciklama", R.Aciklama);
                cmd.Parameters.AddWithValue("@adres", R.Adres);
                BaglantiAcKapat();
                returnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
               
            }
            finally
            {
                BaglantiAcKapat();
            }
            return returnValues;
        }
        public int guncelle(RehberKayit Rg)
        {
            try
            {
                cmd = new SqlCommand("update Kisiler set Adi=@adi,Soyadi=@soyadi,Email=@email,WebAdresi=@webadres,CepNo1=@cep1,CepNo2=@cep2,EvTelefonu1=@ev1,EvTelefonu2=@ev2,IsTelefonu1=@is1,IsTelefonu2=@is2,Aciklama=@aciklama,Adres=@adres where KisilerID=@Id", con);
                cmd.Parameters.AddWithValue("@adi", Rg.Adi);
                cmd.Parameters.AddWithValue("@soyadi", Rg.Soyadi);
                cmd.Parameters.AddWithValue("@email", Rg.Email);
                cmd.Parameters.AddWithValue("@webadres", Rg.WebAdresi);
                cmd.Parameters.AddWithValue("@cep1", Rg.CepNo1);
                cmd.Parameters.AddWithValue("@cep2", Rg.CepNo2);
                cmd.Parameters.AddWithValue("@ev1", Rg.EvTelefonu1);
                cmd.Parameters.AddWithValue("@ev2", Rg.EvTelefonu2);
                cmd.Parameters.AddWithValue("@is1", Rg.IsTelefonu1);
                cmd.Parameters.AddWithValue("@is2", Rg.IsTelefonu2);
                //cmd.Parameters.AddWithValue("@kayit_tarihi", SqlDbType.DateTime).Value = Rg.KayitTarihi;
                cmd.Parameters.AddWithValue("@aciklama", Rg.Aciklama);
                cmd.Parameters.AddWithValue("@adres", Rg.Adres);
                cmd.Parameters.AddWithValue("@Id", Rg.KisilerID);
                BaglantiAcKapat();
                returnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                BaglantiAcKapat();
            }
            return returnValues;
        }
        public SqlDataReader RehberListesi()
        {
            cmd = new SqlCommand("Select *from Kisiler", con);
            BaglantiAcKapat();
            return cmd.ExecuteReader();
        }
        public int SistemGiris(Kullanicilar k)
        {
            try
            {
                cmd = new SqlCommand("Select *from Kullanicilar where KullaniciAdi =@kAdi and KullaniciSifre =@kSifre",con);
                cmd.Parameters.AddWithValue("@kAdi", k.KullaniciAdi);
                cmd.Parameters.AddWithValue("@kSifre", k.KullaniciSifre);
                BaglantiAcKapat();
                returnValues = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {

               
            }
            finally
            {
                BaglantiAcKapat();
            }
            return returnValues;
        }
        public int PersonelKayit(Personeller per)
        {
            try
            {
                cmd = new SqlCommand("insert into Personeller (Tc,PersonelAdi,PersonelSoyadi,Cinsiyet,MedeniHali,DogumYeri,DogumTarihi,Telefon,GorevTanimi,Email,Adres,isGirisTarihi) values (@tc,@pAdi,@pSoyadi,@cinsiyet,@medenihali,@dogumYeri,@dogumTarihi,@telefon,@gorevTanimi,@email,@adres,@isGirisTarihi)  ", con);
                cmd.Parameters.AddWithValue("@Tc", per.TC);
                cmd.Parameters.AddWithValue("@pAdi", per.PersonelAdi);
                cmd.Parameters.AddWithValue("@pSoyadi", per.PersonelSoyadi);
                cmd.Parameters.AddWithValue("@cinsiyet", per.Cinsiyet);
                cmd.Parameters.AddWithValue("@medenihali", per.MedeniHali);
                cmd.Parameters.AddWithValue("@dogumYeri", per.DogumYeri);
                cmd.Parameters.AddWithValue("@dogumTarihi", SqlDbType.DateTime).Value = per.DogumTarihi;
                cmd.Parameters.AddWithValue("@telefon", per.Telefon);
                cmd.Parameters.AddWithValue("@gorevTanimi", per.GorevTanimi);
                cmd.Parameters.AddWithValue("@email", per.Email);
                cmd.Parameters.AddWithValue("@adres", per.Adres);
                cmd.Parameters.AddWithValue("@isGirisTarihi", SqlDbType.DateTime).Value = per.isGirisTarihi;
                BaglantiAcKapat();
                returnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                BaglantiAcKapat();
            }
            return returnValues;
        }
        public int guncellePer(Personeller per)
        {
            try
            {
                cmd = new SqlCommand("update Personeller set TC=@tc,PersonelAdi=@adi,PersonelSoyadi=@soyadi,Cinsiyet=@cinsiyet,MedeniHali=@medenihali,DogumYeri=@dogumyeri,DogumTarihi=@dogumtarihi,Telefon=@telefon,GorevTanimi=@gorevtanimi,Email=@email,Adres=@adres,isGirisTarihi=@isgiristarihi where PersonellerID=@Id", con);
                cmd.Parameters.AddWithValue("@tc", per.TC);
                cmd.Parameters.AddWithValue("@adi", per.PersonelAdi);
                cmd.Parameters.AddWithValue("@soyadi", per.PersonelSoyadi);
                cmd.Parameters.AddWithValue("@cinsiyet", per.Cinsiyet);
                cmd.Parameters.AddWithValue("@medenihali", per.MedeniHali);
                cmd.Parameters.AddWithValue("@dogumyeri", per.DogumYeri);
                cmd.Parameters.AddWithValue("@dogumtarihi", SqlDbType.DateTime).Value = per.DogumTarihi;
                cmd.Parameters.AddWithValue("@telefon", per.Telefon);
                cmd.Parameters.AddWithValue("@gorevtanimi", per.GorevTanimi);
                cmd.Parameters.AddWithValue("@email", per.Email);
                cmd.Parameters.AddWithValue("@adres", per.Adres);
                cmd.Parameters.AddWithValue("@isgiristarihi", SqlDbType.DateTime).Value = per.isGirisTarihi;
                cmd.Parameters.AddWithValue("@Id", per.PersonellerID);
                BaglantiAcKapat();
                returnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                BaglantiAcKapat();
            }
            return returnValues;
        }
        public SqlDataReader PersonelListesi()
        {
            cmd = new SqlCommand("Select *from Personeller", con);
            BaglantiAcKapat();
            return cmd.ExecuteReader();
        }
        public int MusteriKayit(Musteriler m)
        {
            try
            {
                cmd = new SqlCommand("insert into Musteriler(MusteriAdi,MusteriSoyadi,Cinsiyet,MedeniHali,SirketAdi,Telefon,Email,KayitTarihi,Sayisi,Fiyat,Adres)values(@mAdi, @mSoyadi, @cinsiyet, @medeniHali, @sirketAdi, @telefon, @email, @kayitTarihi,@sayisi ,@fiyat, @adres) ", con);
                cmd.Parameters.AddWithValue("@mAdi", m.MusteriAdi);
                cmd.Parameters.AddWithValue("@mSoyadi", m.MusteriSoyadi);
                cmd.Parameters.AddWithValue("@cinsiyet", m.Cinsiyet);
                cmd.Parameters.AddWithValue("@medenihali", m.MedeniHali);
                cmd.Parameters.AddWithValue("@sirketAdi", m.SirketAdi);
                cmd.Parameters.AddWithValue("@telefon", m.Telefon);
                cmd.Parameters.AddWithValue("@email", m.Email);
                cmd.Parameters.AddWithValue("@kayitTarihi", SqlDbType.DateTime).Value = m.KayitTarihi;     
                cmd.Parameters.AddWithValue("@sayisi", m.Sayisi);
                cmd.Parameters.AddWithValue("@fiyat", m.Fiyat);
                cmd.Parameters.AddWithValue("@adres", m.Adres);
                BaglantiAcKapat();
                returnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                BaglantiAcKapat();
            }
            return returnValues;
        }
        public int MusteriGuncelle(Musteriler mu)
        {
            try
            {
                cmd = new SqlCommand("update Musteriler set MusteriAdi=@adi,MusteriSoyadi=@soyadi,Cinsiyet=@cinsiyet,MedeniHali=@medenihali,SirketAdi=@sirketadi,Telefon=@telefon,Email=@email,Sayisi=@sayisi,Fiyat=@fiyat,Adres=@adres where MusterilerID=@Id", con);
                cmd.Parameters.AddWithValue("@adi", mu.MusteriAdi);
                cmd.Parameters.AddWithValue("@soyadi", mu.MusteriSoyadi);
                cmd.Parameters.AddWithValue("@cinsiyet", mu.Cinsiyet);
                cmd.Parameters.AddWithValue("@medenihali", mu.MedeniHali);
                cmd.Parameters.AddWithValue("@sirketadi", mu.SirketAdi);
                cmd.Parameters.AddWithValue("@telefon", mu.Telefon);
                cmd.Parameters.AddWithValue("@email", mu.Email);
                //cmd.Parameters.AddWithValue("@kayittarihi", SqlDbType.DateTime).Value = mu.KayitTarihi;
                cmd.Parameters.AddWithValue("@sayisi", mu.Sayisi);
                cmd.Parameters.AddWithValue("@fiyat", mu.Fiyat);
                cmd.Parameters.AddWithValue("@adres", mu.Adres);
                cmd.Parameters.AddWithValue("@Id", mu.MusterilerID);
                BaglantiAcKapat();
                returnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                BaglantiAcKapat();
            }
            return returnValues;
        }
        public SqlDataReader MusteriListesi()
        {

            cmd = new SqlCommand("Select *from Musteriler", con);
            BaglantiAcKapat();
            return cmd.ExecuteReader();
        }
        public int rehberSil(RehberKayit Rg)
        {
            try
            {
                cmd = new SqlCommand("delete from Kisiler where KisilerID=@Id", con);                
                cmd.Parameters.AddWithValue("@Id", Rg.KisilerID);
                BaglantiAcKapat();
                returnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                BaglantiAcKapat();
            }
            return returnValues;
        }

    }
}
