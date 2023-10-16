using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities
{
    public class Marka : IEntity
    {
        public int Id { get; set; }
        [StringLength(40)]
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş Bırakılmaz !")]
        public string Name { get; set; }
    }
}
