using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiEntities
{
    public class RehberKayit
    {
        public int KisilerID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string WebAdresi { get; set; }
        public string CepNo1 { get; set; }
        public string CepNo2 { get; set; }
        public string EvTelefonu1 { get; set; }
        public string EvTelefonu2 { get; set; }
        public string IsTelefonu1 { get; set; }
        public string IsTelefonu2 { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Aciklama { get; set; }
        public string Adres { get; set; }

    }
}
