using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiEntities
{
    public class Personeller
    {
        public int PersonellerID { get; set; }
        public string TC { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public bool Cinsiyet { get; set; }
        public bool MedeniHali { get; set; }
        public string DogumYeri { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public string GorevTanimi { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public DateTime isGirisTarihi { get; set; }
    }
}
