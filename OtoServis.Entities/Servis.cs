using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities
{
    public class Servis:IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Servis Geliş Tarihi")]
        public DateTime ServiseGelisTarihi { get; set; }
        [StringLength(40)]
        [Display(Name = "Araç Sorunu"), Required(ErrorMessage = "{0} Boş Bırakılmaz !")]
        public string AracSorunu { get; set; }
        [Display(Name = "Servis Ücreti"), Required(ErrorMessage = "{0} Boş Bırakılmaz !")]
        public decimal ServisUcreti { get; set; }
        [Display(Name = "Servisten çıkış tarihi")]
        public DateTime ServistenCikisTarihi { get; set; }
        [Display(Name = "Yapılan işlemler")]
        public string YapilanIslemler { get; set; }
        [Display(Name = "Garanti kapsamında mı?")]
        public bool GarantiKapsamindaMi { get; set; }
        [StringLength(15)]
        [Display(Name = "Araç Plaka No"), Required(ErrorMessage = "{0} Boş Bırakılmaz !")]
        public string AracPlaka { get; set; }
        [StringLength(40), Required(ErrorMessage = "{0} Boş Bırakılmaz !")]
        public string Marka { get; set; }
        [StringLength(40)]
        public string? Model { get; set; }
        [StringLength(40)]
        [Display(Name = "Kasa Tipi")]
        public string? KasaTipi { get; set; }
        [Display(Name = "Şase No")]
        public string? SaseNo { get; set; }
        public string Notlar { get; set; }
    }
}
