using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities
{
    public class Arac : IEntity
    {
        public int Id { get; set; }
        public int MarkaId { get; set; }
        [StringLength(40)]
        public string Renk { get; set; }
        [Display(Name = "Fiyatı")]
        public decimal Fiyati { get; set; }
        [StringLength(40)]
        [Display(Name = "Modeli")]
        public string Modeli { get; set; }
        [StringLength(40)]
        [Display(Name = "Kasa Tipi")]
        public string KasaTipi { get; set; }
        [Display(Name = "Model Yılı")]
        public int ModelYili { get; set; }
        [Display(Name = "Satışta Mı?")]
        public bool SatistaMi { get; set; }
        [Display(Name = "Anasayfa")]
        public bool Anasayfa { get; set; }
        public string Notlar { get; set; }
        [StringLength(100)]
        public string? Resim1 { get; set; }
        [StringLength(100)]
        public string? Resim2 { get; set; }
        [StringLength(100)]
        public string? Resim3 { get; set; }
        public virtual Marka? Marka { get; set; } //Araç sınıfı ile Marka sınıfı arasında bağlantı
    }
}
