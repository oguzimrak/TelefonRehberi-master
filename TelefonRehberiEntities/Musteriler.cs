using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiEntities
{
    public class Musteriler
    {
        public int MusterilerID { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriSoyadi { get; set; }
        public bool Cinsiyet { get; set; }
        public bool MedeniHali { get; set; }
        public string SirketAdi { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int Sayisi { get; set; }
        public decimal Fiyat { get; set; }
        public string Adres { get; set; }
    }
}
