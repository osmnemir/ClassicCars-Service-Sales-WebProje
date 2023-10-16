using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities
{
    public class Kullanici:IEntity
    {
        public int Id { get; set; }

        [StringLength(40)]
        [Display(Name = "Ad"),Required(ErrorMessage ="{0} Boş Bırakılmaz !")]

        public string Adi { get; set; }
        [StringLength(40), Display(Name = "Soyad"),Required(ErrorMessage = "{0} Boş Bırakılmaz !")]
        public string Soyadi { get; set; }
        [StringLength(40)]
        public string Email { get; set; }
        [StringLength(40)]
        public string Telefon { get; set; }
        [StringLength(40)]
        public string KullaniciAdi { get; set; }
        [Display(Name = "Şifre") ,StringLength(40), Required(ErrorMessage = "{0} Boş Bırakılmaz !")]
        public string Sifre { get; set; }
        public bool AktifMi { get; set; }
        [Display(Name ="Eklenme Tarihi"),ScaffoldColumn(false)]
        public DateTime? EklenmeTarihi { get; set; }=DateTime.Now;
        [Display(Name = "Kullanıcı Rolü"), Required(ErrorMessage = "{0} Boş Bırakılmaz !")]
        public int RolId { get; set; }
        [Display(Name = "Kullanıcı Rolü")]
        public virtual Rol? Rol { get; set; }
        public Guid? UserGuid { get; set; } = Guid.NewGuid();
    }
}
