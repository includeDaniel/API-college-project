using System.ComponentModel.DataAnnotations;

namespace BD_BACK.Models
{
    public class ContactUsModel : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
