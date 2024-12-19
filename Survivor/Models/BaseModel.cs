using System.ComponentModel.DataAnnotations;

namespace Survivor.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedDate {  get; set; } = DateTime.Now;

        [Required]
        public bool IsDeleted { get; set; }
    }
}
