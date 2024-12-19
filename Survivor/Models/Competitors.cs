using System.ComponentModel.DataAnnotations;

namespace Survivor.Models
{ 
    public class Competitors : BaseModel// Yarışmacı
    {
        [Required(ErrorMessage ="İsim Zorunludur")]
        [MaxLength(50,ErrorMessage = "İsim 50 Karakterden Uzun Olamaz")]
        public string FirstName{ get; set; }

        [Required(ErrorMessage = "Soyad Zorunludur")]
        [MaxLength(50, ErrorMessage = "İsim 50 Karakterden Uzun Olamaz")]
        public string LastName{ get; set; }

        [Required]
        public int CategoryId { get; set; } 
        public Category Category { get; set; } // Navigation Property (Bir yarışmacının bir kategorisi)
    }
}
