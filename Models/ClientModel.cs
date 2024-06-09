using System.ComponentModel.DataAnnotations;

namespace BD_BACK.Models
{
    public class ClientModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
