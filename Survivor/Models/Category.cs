using System.ComponentModel.DataAnnotations;

namespace Survivor.Models
{
    public class Category : BaseModel
    {
        [Required(ErrorMessage ="Kategori Adı Zorunludur")]
        [MaxLength(50, ErrorMessage ="Kategori ismi 50 den uzun olamaz")]
        public string Name { get; set; }

        public List<Competitors> Competitors { get; set; } // bir kategorinin birden fazla yarışmacısı olabilir
    }
}
