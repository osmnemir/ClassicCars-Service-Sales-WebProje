using System.ComponentModel.DataAnnotations;

namespace OtoServis.Entities
{
    public class Rol:IEntity
    {
        public int Id { get; set; }
        [StringLength(40)]
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş Bırakılmaz !")]

        public string Adi { get; set; }
    }
}
