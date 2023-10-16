using System.ComponentModel.DataAnnotations;

namespace OtoServis.WebUI.Models
{
    public class CustomerLoginViewModel
    {
        [StringLength(40)]
        public string Email { get; set; }


        [Display(Name = "Şifre"), StringLength(40), Required(ErrorMessage = "{0} Boş Bırakılmaz !")]
        public string Sifre { get; set; }
    }
}
