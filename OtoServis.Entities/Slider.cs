using System.ComponentModel.DataAnnotations;

namespace OtoServis.Entities
{
    public class Slider:IEntity
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string? Baslik { get; set; }
        [StringLength(100)]
        public string? Aciklama { get; set; }
        [StringLength(40)]
        public string? Resim { get; set; }
        [StringLength(40)]
        public string? Link { get; set; }

    }
}
