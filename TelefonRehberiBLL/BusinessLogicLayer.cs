using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberiDLL;
using TelefonRehberiEntities;


namespace TelefonRehberiBLL
{
    public class BusinessLogicLayer
    {
        DatabaseLogicLayer dll;
        //ctor tab tab constructor class
        public BusinessLogicLayer()
        {
            dll = new DatabaseLogicLayer();
        }
        /// <summary>
        /// Rehbere kayıt ekler
        /// </summary>
        /// <param name="isim"></param>
        /// <param name="soyisim"></param>
        /// <param name="email"></param>
        /// <param name="webadres"></param>
        /// <param name="cep1"></param>
        /// <param name="cep2"></param>
        /// <param name="ev1"></param>
        /// <param name="ev2"></param>
        /// <param name="is1"></param>
        /// <param name="is2"></param>
        /// <param name="kayit_tarihi"></param>
        /// <param name="aciklama"></param>
        /// <param name="adres"></param>
        /// <returns></returns>
        public int VERIKAYDET(string isim, string soyisim, string email, string webadres, string cep1, string cep2, string ev1, string ev2, string is1, string is2, string kayit_tarihi,string aciklama, string adres)
        {
            if (!string.IsNullOrWhiteSpace(isim) && !string.IsNullOrWhiteSpace(cep1))
            {
                RehberKayit r1 = new RehberKayit();
                r1.Adi = isim;
                r1.Soyadi = soyisim;
                r1.Email = email;
                r1.WebAdresi = webadres;
                r1.CepNo1 = cep1;
                r1.CepNo2 = cep2;
                r1.EvTelefonu1 = ev1;
                r1.EvTelefonu2 = ev2;
                r1.IsTelefonu1 = is1;
                r1.IsTelefonu2 = is2;
                r1.KayitTarihi = Convert.ToDateTime(kayit_tarihi);
                r1.Aciklama = aciklama;
                r1.Adres = adres;


                return dll.kaydet(r1);
            }
            else
            {
                return -1;//eksik parametre hatası
            }

        }

        /*Rehber güncelle*/
        public int VERIGUNCELLE(int Id, string isim, string soyisim, string email, string webadres, string cep1, string cep2, string ev1, string ev2, string is1, string is2, string aciklama, string adres)
        {
            
                RehberKayit r1 = new RehberKayit();
                r1.KisilerID = Convert.ToInt32(Id);
                r1.Adi = isim;
                r1.Soyadi = soyisim;
                r1.Email = email;
                r1.WebAdresi = webadres;
                r1.CepNo1 = cep1;
                r1.CepNo2 = cep2;
                r1.EvTelefonu1 = ev1;
                r1.EvTelefonu2 = ev2;
                r1.IsTelefonu1 = is1;
                r1.IsTelefonu2 = is2;
                //r1.KayitTarihi = Convert.ToDateTime(kayit_tarihi);
                r1.Aciklama = aciklama;
                r1.Adres = adres;


                return dll.guncelle(r1);
          
        }

        public int PERSONELGUNCELLE(int Id, string tc,string isim, string soyisim, string cinsiyet,string medenihali,string dogumyeri,string dogumtarihi,string gorevtanimi, string email, string ceptelefon, string adres, string isgirisTarihi)
        {

            Personeller per = new Personeller();
            per.PersonellerID = Convert.ToInt32(Id);
            per.TC = tc;
            per.PersonelAdi = isim;
            per.PersonelSoyadi = soyisim;
            per.Cinsiyet = Convert.ToBoolean(cinsiyet);
            per.MedeniHali = Convert.ToBoolean(medenihali);
            per.DogumYeri = dogumyeri;
            per.DogumTarihi = Convert.ToDateTime(dogumtarihi);
            per.Telefon = ceptelefon;
            per.GorevTanimi = gorevtanimi;
            per.Email = email;
            per.Adres = adres;
            per.isGirisTarihi = Convert.ToDateTime(isgirisTarihi);


            return dll.guncellePer(per);

        }

        public List<RehberKayit> RehberiListele()
        {
            //List<string> listeleme = new List<string>();
            List<RehberKayit> rehList = new List<RehberKayit>();
            try
            {
                SqlDataReader reader = dll.RehberListesi();
                while (reader.Read())
                {
                    rehList.Add(new RehberKayit()
                    {
                        KisilerID = reader.IsDBNull(0) ? int.Parse("") : reader.GetInt32(0),
                        Adi=reader.IsDBNull(1)?string.Empty:reader.GetString(1),
                        Soyadi = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Email = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        WebAdresi = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        CepNo1 = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        CepNo2 = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        EvTelefonu1 = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        EvTelefonu2 = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        IsTelefonu1 = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                        IsTelefonu2 = reader.IsDBNull(10) ? string.Empty : reader.GetString(10),
                        KayitTarihi = reader.IsDBNull(11) ? DateTime.Parse("") : reader.GetDateTime(11),
                        Aciklama = reader.IsDBNull(12) ? string.Empty : reader.GetString(12),
                        Adres = reader.IsDBNull(13) ? string.Empty : reader.GetString(13)
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return rehList;
        }

        public List<Personeller> PersonelListele() {
            List<Personeller> perList = new List<Personeller>();
            try
            {
                SqlDataReader reader = dll.PersonelListesi();
                while (reader.Read())
                {
                    perList.Add(new Personeller()
                    {
                        PersonellerID = reader.IsDBNull(0) ? int.Parse("") : reader.GetInt32(0),
                        TC=reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        PersonelAdi = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        PersonelSoyadi = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Cinsiyet = reader.IsDBNull(4) ? bool.Parse("") : reader.GetBoolean(4),
                        MedeniHali = reader.IsDBNull(5) ? bool.Parse("") : reader.GetBoolean(5),
                        DogumYeri = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        DogumTarihi = reader.IsDBNull(7) ? DateTime.Parse("") : reader.GetDateTime(7),
                        Telefon = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        GorevTanimi = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                        Email = reader.IsDBNull(10) ? string.Empty : reader.GetString(10),
                        Adres = reader.IsDBNull(11) ? string.Empty : reader.GetString(11)                                            
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return perList;
        }

        public List<Musteriler> MusteriListele()
        {
            List<Musteriler> musList = new List<Musteriler>();
            try
            {
                SqlDataReader reader = dll.MusteriListesi();
                while (reader.Read())
                {
                    musList.Add(new Musteriler()
                    {
                        MusterilerID = reader.IsDBNull(0) ? int.Parse("") : reader.GetInt32(0),
                        MusteriAdi = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        MusteriSoyadi = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Cinsiyet = reader.IsDBNull(3) ? bool.Parse("") : reader.GetBoolean(3),
                        MedeniHali = reader.IsDBNull(4) ? bool.Parse("") : reader.GetBoolean(4),
                        SirketAdi = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Telefon = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        Email = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        KayitTarihi = reader.IsDBNull(8) ? DateTime.Parse("") : reader.GetDateTime(8),
                        Sayisi = reader.IsDBNull(9) ? int.Parse("") : reader.GetInt32(9),
                        Fiyat = reader.IsDBNull(10) ? decimal.Parse("") : reader.GetDecimal(10),
                        Adres = reader.IsDBNull(11) ? string.Empty : reader.GetString(11)
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return musList;
        }

        public int SistemeGiris(string kadi,string ksifre)
        {
            if (!string.IsNullOrWhiteSpace(kadi) && !string.IsNullOrWhiteSpace(ksifre))
            {
                return dll.SistemGiris(new Kullanicilar()
                {
                    KullaniciAdi=kadi,
                    KullaniciSifre=ksifre
                });
            }
            else
            {
                return -1;
            }
        }

        public int PERSONELKAYDET(string Tc,string isim, string soyisim,  bool cinsiyet ,bool medenihali,string dogumyeri, string dogumTarihi, string telefon, string gorevtanimi, string email, string adres, string isGirisTarihi)
        {
            if (!string.IsNullOrWhiteSpace(isim) && !string.IsNullOrWhiteSpace(telefon))
            {
                Personeller per = new Personeller();
                per.TC = Tc;
                per.PersonelAdi = isim;
                per.PersonelSoyadi = soyisim;
                per.Cinsiyet = cinsiyet;
                per.MedeniHali = medenihali;
                per.DogumYeri = dogumyeri;
                per.DogumTarihi = Convert.ToDateTime(dogumTarihi);
                per.Telefon = telefon;
                per.GorevTanimi = gorevtanimi;
                per.Email = email;
                per.Adres = adres;
                per.isGirisTarihi = Convert.ToDateTime(isGirisTarihi);
                return dll.PersonelKayit(per);
            }
            else
            {
                return -1;//eksik parametre hatası
            }

        }

        public int MUSTERIKAYDET(string isim, string soyisim, bool cinsiyet, bool medenihali, string sirketAdi, string telefon,string email, string kayitTarihi,int sayisi,decimal fiyat,string adres)
        {
            if (!string.IsNullOrWhiteSpace(isim) && !string.IsNullOrWhiteSpace(telefon) && !string.IsNullOrWhiteSpace(cinsiyet.ToString()) && !string.IsNullOrWhiteSpace(medenihali.ToString()))
            {
                Musteriler m = new Musteriler();
                m.MusteriAdi = isim;
                m.MusteriSoyadi = soyisim;
                m.Cinsiyet = cinsiyet;
                m.MedeniHali = medenihali;
                m.SirketAdi = sirketAdi;
                m.Telefon = telefon;
                m.Email = email;
                m.KayitTarihi = Convert.ToDateTime(kayitTarihi);
                m.Sayisi = Convert.ToInt32(sayisi);
                m.Fiyat = Convert.ToDecimal(fiyat);              
                m.Adres = adres;
                return dll.MusteriKayit(m);
            }
            else
            {
                return -1;//eksik parametre hatası
            }

        }

        public int MUSTERIGUNCELLE(int Id,string isim, string soyisim, bool cinsiyet, bool medenihali, string sirketAdi, string telefon, string email, int sayisi, decimal fiyat, string adres)
        {
            Musteriler r1 = new Musteriler();
            r1.MusterilerID = Convert.ToInt32(Id);
            r1.MusteriAdi = isim;
            r1.MusteriSoyadi = soyisim;
            r1.Cinsiyet = cinsiyet;
            r1.MedeniHali = medenihali;
            r1.SirketAdi = sirketAdi;
            r1.Telefon = telefon;
            r1.Email = email;
            //r1.KayitTarihi = Convert.ToDateTime(kayitTarihi);
            r1.Sayisi = sayisi;
            r1.Fiyat = fiyat;
            r1.Adres = adres;


            return dll.MusteriGuncelle(r1);
        }

        public int RehberSil(int Id)
        {
            try
            {
                if (Id>0)
                {
                    return dll.rehberSil(new RehberKayit()
                    {
                        KisilerID = Id
                    }); 
                }
                else
                {
                    return -1;
                }

            }
            catch (Exception)
            {

                throw;
            }
           
            
        }
    }
}
